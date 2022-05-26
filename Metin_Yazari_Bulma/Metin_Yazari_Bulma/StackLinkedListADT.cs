using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public abstract class StackLinkedListADT
    {
        public abstract void Push(string value);
        public abstract string Pop();
        public abstract bool IsEmpty();
        public abstract string Peek();
    }

    public class Node
    {
        public string Data;
        public Node Next;
    }
}
