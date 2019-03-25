using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {

        private bool _containsString;
        private ITrie _onlyChild;
        private char _label;
        public TrieWithOneChild(string s, bool b)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _containsString = b;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }
        /// <summary>
        /// Add(string)
        /// </summary>
        /// <param name="s">string to be added</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s.Equals(""))
            {
                _containsString = true;
                return this;
            }
            else if (s[0].Equals(_label))
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _containsString, _label, _onlyChild);
            }
        }
        /// <summary>
        /// Contains method. Three cases;
        /// </summary>
        /// <param name="s"> string to be passed in</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _containsString;
            }
            if (s[0].Equals(_label))
            {
                return _onlyChild.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
