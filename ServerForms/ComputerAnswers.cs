using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotAnswers
{
    public static class ComputerAnswers
    {
        private static readonly Random rand = new Random();
        private static readonly List<string> botPhrases = new List<string>
        {
            "Please, tell me more",
            "You know i love you?",
            "Okay, I can undarstand this",
            "Socks?",
            "Can i think about this?",
            "Do you like to know about Warhammer lore?",
            "Understandable, have a nice day",
            "One, two, three",
            "I love Japanice music",
            "Sorry im a dumb-dumb~",
            "<Bye>"
        };
        public static string GetRandomAnswer()
        {
            int index = rand.Next(0, botPhrases.Count);
            return botPhrases[index];
        }
    }
}
