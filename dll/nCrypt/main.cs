using System;
using System.Collections.Generic;
using System.Text;

namespace nCrypt
{
    public class nCipher
    {
        private readonly string[] _codes = new string[]
        {
            "2391", "1574", "3059", "3894", "3176", "2542", "1269", "3765", "2124", "0586",
            "4023", "3267", "3451", "0778", "1938", "4082", "1675", "2760", "1023", "3610",
            "2250", "3344", "0509", "3908", "1427", "2816",
            "1985", "3684", "1599", "2991", "2213", "3730", "1286", "4004", "1720", "3579"
        };

        private readonly Dictionary<char, string> _eM;
        private readonly Dictionary<string, char> _eMRev;

        public nCipher()
        {
            _eM = new Dictionary<char, string>();
            _eMRev = new Dictionary<string, char>();

            for (int i = 0; i < 26; i++)
            {
                char c = (char)('A' + i);
                _eM[c] = _codes[i];
                _eMRev[_codes[i]] = c;
            }

            for (int i = 0; i < 10; i++)
            {
                char c = (char)('0' + i);
                _eM[c] = _codes[26 + i];
                _eMRev[_codes[26 + i]] = c;
            }
        }

        public string Encrypt(string plainText)
        {
            var sb = new StringBuilder();

            foreach (char c in plainText)
            {
                if (c == ' ')
                {
                    sb.Append("\\;");
                }
                else
                {
                    char upper = char.ToUpper(c);
                    if (_eM.ContainsKey(upper))
                    {
                        sb.Append(_eM[upper]);
                        sb.Append(";");
                    }
                    else
                    {
                        sb.Append(c);
                        sb.Append(";");
                    }
                }
            }

            if (sb.Length > 0 && sb[sb.Length - 1] == ';')
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public string Decrypt(string cipherText)
        {
            var sb = new StringBuilder();

            string[] tokens = cipherText.Split(';');

            foreach (var token in tokens)
            {
                if (token == "\\")
                {
                    sb.Append(' ');
                }
                else if (_eMRev.ContainsKey(token))
                {
                    sb.Append(_eMRev[token]);
                }
                else
                {
                    sb.Append(token);
                }
            }

            return sb.ToString();
        }
    }
}
