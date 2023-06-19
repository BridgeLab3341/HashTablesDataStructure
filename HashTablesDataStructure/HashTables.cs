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
        public class HashMapNode<K, V>
        {
            private int size;
            private LinkedList<KeyValue<K, V>>[] items;
            public HashMapNode(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValuePair<K, V>>[size];
            }
            public int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValuePair<K, V>> linkedlist = GetLinkedList(position);
                KeyValuePair<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
                linkedlist.AddLast(item);
            }
            public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedlist = items[position];
                if (linkedlist == null)
                {
                    linkedlist = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedlist;
                }
                return linkedlist;
            }
            public V Get(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedlis = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedlis)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
                return default(V);
            }
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> LinkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> founditem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in LinkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        founditem = item;
                    }
                }
                if (itemFound)
                {
                    LinkedList.Remove(founditem);
                }
            }
            public void Display()
            {
                foreach (var linkedList in items)
                {
                    if (linkedList != null)
                        foreach (KeyValue<K, V> keyvalue in linkedList)
                        {
                            Console.WriteLine(keyvalue.Key + " " + keyvalue.Value);
                        }
                }
            }
        }
}
