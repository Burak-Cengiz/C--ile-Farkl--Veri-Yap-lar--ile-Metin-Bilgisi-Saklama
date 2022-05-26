using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public abstract class LinkedListADT
    {
        public Nodee Head;
        public int Count = 0;
        public abstract void InsertFirst(string key,string value);
        public abstract void InsertLast(string key,string value);
        public abstract string DisplayElements();
        
        public abstract void Remove(string key);
        public abstract void RemoveFirst();
        public abstract bool Search(string key);
               

    }
    public class Nodee
    {
        public string key;
        public string Data;
        public Nodee Next;
    }
}
