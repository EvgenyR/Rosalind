using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    class MyTrieNode<V> where V : class
    {

        /// <summary>
        /// The value stored by this node. If not null then the node terminates a string.
        /// </summary>
        public V Value { get; set; }

        public bool IncreaseCounter { get; set; }

        /// <summary>
        /// Get the key which was associated with this node.
        /// </summary>
        public Char Key { get; private set; }

        public int ID { get; set; }

        /// <summary>
        /// Get the parent of this node.
        /// </summary>
        public MyTrieNode<V> Parent { get; private set; }

        private Dictionary<Char, MyTrieNode<V>> children;

        /// <summary>
        /// Create an empty node with no children and null value.
        /// </summary>
        /// <param name="parent">Parent node of this node.</param>
        public MyTrieNode(MyTrieNode<V> parent, Char key, int id)
        {
            this.Key = key;
            this.Value = null;
            this.ID = id;
            this.Parent = parent;
            this.children = new Dictionary<Char, MyTrieNode<V>>();
        }

        /// <summary>
        /// Get a child of this node which is associated with a key.
        /// </summary>
        /// <param name="key">Key associated with the child of interest.</param>
        /// <returns>The child or null if no child is associated with the given key.</returns>
        public MyTrieNode<V> GetChild(char key)
        {
            if (children.ContainsKey(key))
            {
                return children[key];
            }
            return null;
        }

        /// <summary>
        /// Check whether or not this node terminates a string and stores a value.
        /// </summary>
        /// <returns>Whether node stores a value.</returns>
        public bool IsTerminater()
        {
            return Value != null;
        }

        /// <summary>
        /// Get the number of children this node has.
        /// </summary>
        /// <returns>Number of children.</returns>
        public int NumChildren()
        {
            return children.Count;
        }

        /// <summary>
        /// Check whether or not this node has any children.
        /// </summary>
        /// <returns>True if node does not have children, false otherwise.</returns>
        public bool IsLeaf()
        {
            return NumChildren() == 0;
        }

        /// <summary>
        /// Check whether or not one of the children of this node uses the given key.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if a child with given key exists, false otherwise.</returns>
        public bool ContainsKey(char key)
        {
            return children.ContainsKey(key);
        }

        /// <summary>
        /// Add a child node associated with a key to this node and return the node.
        /// </summary>
        /// <param name="key">Key to associated with the child node.</param>
        /// <returns>If given key already exists then return the existing child node, else return the new child node.</returns>
        public MyTrieNode<V> AddChild(char key, int id)
        {
            if (children.ContainsKey(key))
            {
                return children[key];
            }
            else
            {
                MyTrieNode<V> newChild = new MyTrieNode<V>(this, key, id);
                newChild.IncreaseCounter = true;
                children.Add(key, newChild);
                //string s = this.ID + " " + newChild.ID + " " + newChild.Key;
                //Helper.WriteSingleStringToTextFile(s);

                if (key == '$' && children.Count() > 1)
                {
                    int z = 0;
                }

                return newChild;
            }
        }

        /// <summary>
        /// Remove the child of a node associated with a key along with all its descendents.
        /// </summary>
        /// <param name="key">The key associated with the child to remove.</param>
        public void RemoveChild(char key)
        {
            children.Remove(key);
        }

        /// <summary>
        /// Get a list of values contained in this node and all its descendants.
        /// </summary>
        /// <returns>A List of values.</returns>
        public List<V> PrefixMatches()
        {
            if (IsLeaf())
            {
                if (IsTerminater())
                {
                    return new List<V>(new V[] { Value });
                }
                else
                {
                    return new List<V>();
                }
            }
            else
            {
                List<V> values = new List<V>();
                foreach (MyTrieNode<V> node in children.Values)
                {
                    values.AddRange(node.PrefixMatches());
                }

                if (IsTerminater())
                {
                    values.Add(Value);
                }

                return values;
            }
        }

    }
}
