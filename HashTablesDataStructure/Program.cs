namespace HashTablesDataStructure
{
    class Program
    {
        public static void Main(string[] args)
        {
            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";

            HashTable<string,int> wordFrequency = GetWordFrequency(paragraph);
            Console.WriteLine("Word Frequency (Before Removal):");
            PrintWordFrequency(wordFrequency);
            string wordToRemove = "avoidable";
            RemoveWord(wordFrequency, wordToRemove);
            Console.WriteLine("\nWord Frequency (After Removal):");
            PrintWordFrequency(wordFrequency);
        }
        static HashTable<string, int> GetWordFrequency(string phrase)
        {
            HashTable<string, int> wordFrequency = new HashTable<string, int>();

            string[] words = phrase.Split(' ');

            foreach (string word in words)
            {
                string cleanedWord = word.Trim().ToLower();

                if (!string.IsNullOrEmpty(cleanedWord))
                {
                    int frequency = wordFrequency.Get(cleanedWord);
                    wordFrequency.Add(cleanedWord, frequency + 1);
                }
            }

            return wordFrequency;
        }
        static void RemoveWord(HashTable<string, int> wordFrequency, string wordToRemove)
        {
            wordFrequency.Remove(wordToRemove);
        }

        static void PrintWordFrequency(HashTable<string, int> wordFrequency)
        {
            foreach (var entry in wordFrequency)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
