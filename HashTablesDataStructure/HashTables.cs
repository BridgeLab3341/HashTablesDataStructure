using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTablesDataStructure
{
    public class HashTable<TKey, TValue>
    {
        private readonly LinkedList<MyMapNode<TKey, TValue>>[] buckets;
        private const int DefaultCapacity = 10;
        public HashTable()
        {
            buckets=new LinkedList<MyMapNode<TKey, TValue>>[DefaultCapacity];
        }
        private int GetBucketIndex(TKey key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % buckets.Length;
            return index;
        }
        public TValue Get(TKey key)
        {
            int index = GetBucketIndex(key);
            LinkedList<MyMapNode<TKey, TValue>> bucket = buckets[index];
            if (bucket != null)
            {
                foreach (var node in bucket)
                {
                    if (node.Key.Equals(key))
                    {
                        return node.Value;
                    }
                }
            }
            return default(TValue);
        }
        public void Add(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);

            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<MyMapNode<TKey, TValue>>();
            }

            LinkedList<MyMapNode<TKey, TValue>> bucket = buckets[index];
            foreach (var node in bucket)
            {
                if (node.Key.Equals(key))
                {
                    node.Value = value;
                    return;
                }
            }
            bucket.AddLast(new MyMapNode<TKey, TValue>(key, value));
        }
        public void Remove(TKey key)
        {
            int index = GetBucketIndex(key);

            LinkedList<MyMapNode<TKey, TValue>> bucket = buckets[index];
            if (bucket != null)
            {
                LinkedListNode<MyMapNode<TKey, TValue>> currentNode = bucket.First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        bucket.Remove(currentNode);
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
            
