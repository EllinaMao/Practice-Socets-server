
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Practice_Socets_server
{
    public class Server
    {
        public delegate void ServerHandler(string message);
        public event ServerHandler? ServerRecieveMessage;
        private SynchronizationContext? ui = null;
        private Socket _clientSocket = null; //client
        public string StopWord = "<Bye>";

        public event Action? ClientConnected;

        private void Log(string msg)
        {
            if (ui != null)
                ui.Post(d => ServerRecieveMessage?.Invoke(msg), null);
            else
                ServerRecieveMessage?.Invoke(msg);
        }
        public Server(SynchronizationContext ui_ = null)
        {

            this.ui = ui_;
        }
        public void ThreadForReceive(object param)////дочерний поток занимается общением с клиентом
        {
            Socket handler = (Socket)param;//////сокет которій поймал сервер
            try
            {
                string client = null;
                string data = null;
                byte[] bytes = new byte[1024];//buffer

                // Получим от клиента DNS-имя хоста.
                // Метод Receive получает данные от сокета и заполняет массив байтов, переданный в качестве аргумента
                int bytesRec = handler.Receive(bytes); // Возвращает фактически считанное число байтов
                client = Encoding.UTF8.GetString(bytes, 0, bytesRec); // конвертируем массив байтов в строку
                client += "(" + handler.RemoteEndPoint.ToString() + ")";////Возвращает удаленную конечную точку.
                while (true)
                {
                    bytesRec = handler.Receive(bytes); // принимаем данные, переданные клиентом. Если данных нет, поток блокируется
                    if (bytesRec == 0)
                    {
                        break;
                    }
                    data = Encoding.UTF8.GetString(bytes, 0, bytesRec); // конвертируем массив байтов в строку                  

                    Log(data);
                    if (data.IndexOf(StopWord) > -1) // если клиент отправил эту команду, то заканчиваем обработку сообщений
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Log(ex.Message.ToString());
            }
            finally
            {
                try
                {
                    handler.Shutdown(SocketShutdown.Both);
                }
                catch { }
                handler.Close();
            }
        }

        //  ожидать запросы на соединение будем в отдельном потоке
        public void ThreadForAccept(string host = "127.0.0.1", int port = 4000)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint ipEndPoint = new IPEndPoint(ip, port);

                // потоковый сокет
                Socket sListener = new Socket(AddressFamily.InterNetwork /*схема адресации*/, SocketType.Stream /*тип сокета*/, ProtocolType.Tcp /*протокол*/ );

                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                Log("We are started. Waiting client to connect");

                _clientSocket = sListener.Accept();
                Log("Client connected.");
                ui?.Post(d => ClientConnected?.Invoke(), null);

                // Closing listening so only one will connect
                sListener.Close();
                Thread thread = new Thread(new ParameterizedThreadStart(ThreadForReceive));
                thread.IsBackground = true;
                thread.Start(_clientSocket);
            }
            catch (Exception ex)
            {
                Log("Сервер: " + ex.Message);
            }

        }

        public void Send(string msg_)
        {
            try
            {
                if (_clientSocket == null || !_clientSocket.Connected) { return; }

                byte[] msg = Encoding.UTF8.GetBytes(msg_!);
                _clientSocket.Send(msg);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }



    }
}

