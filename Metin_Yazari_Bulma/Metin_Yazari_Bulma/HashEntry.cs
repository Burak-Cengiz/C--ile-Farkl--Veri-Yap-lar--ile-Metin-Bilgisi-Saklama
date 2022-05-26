using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class HashEntry
    {
        private string key;
        private string data;
        public HashEntry(string key, string data)
        {
            this.key = key;
            this.data = data;
        }
        public string getkey()
        {
            return key;
        }
        public string getdata()
        {
            return data;
        }
    }
}
