using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablesDataStructure
{
    public class HashTables
    {
        public void FindFrequency()
        {
            string Sentence = "To be or not to be";
            Dictionary<string, int> frequency = GetWordFrequency(Sentence);
            Console.WriteLine("");
        }
        public static Dictionary<string,int> GetWordFrequency(string sentence)
        {
            Dictionary<string,int>wordFrequency = new Dictionary<string,int>();
            string[] words = sentence.Split(" ");
            foreach (string word in words)
            {
                if(wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }
            return wordFrequency;
        }
    }
}
