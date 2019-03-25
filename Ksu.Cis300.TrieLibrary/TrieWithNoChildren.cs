using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _hasEmptyString;
        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="s">string to be added with a trie with no children</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }
        /// <summary>
        /// Contains string
        /// </summary>
        /// <param name="s">String to be seen to be contained</param>
        /// <returns></returns>

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
