using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    public class MyTrie<V> where V : class
    {

        private MyTrieNode<V> root;
        private int counter = 1;

        /// <summary>
        /// Matcher object for matching prefixes of strings to the strings stored in this trie.
        /// </summary>
        public IMyPrefixMatcher<V> Matcher { get; private set; }

        /// <summary>
        /// Create an empty trie with an empty root node.
        /// </summary>
        public MyTrie()
        {
            this.root = new MyTrieNode<V>(null, '\0', counter);
            //this.root.Value = counter;
            counter++;
            this.Matcher = new MyPrefixMatcher<V>(this.root);
        }

        /// <summary>
        /// Put a new key value pair, overwriting the existing value if the given key is already in use.
        /// </summary>
        /// <param name="key">Key to search for value by.</param>
        /// <param name="value">Value associated with key.</param>
        public void Put(string key, V value)
        {
            MyTrieNode<V> node = root;
            
            //suffix trie
            key = key + "$";

            foreach (char c in key)
            {
                node.IncreaseCounter = false;
                node = node.AddChild(c, counter);
                if (node.IncreaseCounter) counter++;
                node.IncreaseCounter = false;
            }
            node.Value = value;
        }

        /// <summary>
        /// Remove the value that a key leads to and any redundant nodes which result from this action.
        /// Clears the current matching process.
        /// </summary>
        /// <param name="key">Key of the value to remove.</param>
        public void Remove(string key)
        {
            MyTrieNode<V> node = root;
            foreach (char c in key)
            {
                node = node.GetChild(c);
            }
            node.Value = null;

            //Remove all ancestor nodes which don't lead to a value.
            while (node != root && !node.IsTerminater() && node.NumChildren() == 0)
            {
                char prevKey = node.Key;
                node = node.Parent;
                node.RemoveChild(prevKey);
            }

            Matcher.ResetMatch();
        }

    }
	
}
