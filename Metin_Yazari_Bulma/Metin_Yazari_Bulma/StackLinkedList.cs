using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class StackLinkedList : StackLinkedListADT
    {
        public int itemcount;
        public StackLinkedList(int itemCount)
        {
            this.itemcount = itemCount;
        }

        private Node top;

        private int _count = 0;
        public int Count
        {
            get { return _count; }
        }

        public override bool IsEmpty()
        {
            return _count == 0 ? true : false;
        }

        public override string Peek()
        {
            if (!(this.IsEmpty()))
            {
                return top.Data;
            }
            else
            {
                throw new Exception("Hata: stack boş");
            }

        }

        public override string Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Hata: Stack boş");
            }
            else
            {
                string data = top.Data;
                top = top.Next;
                _count--;
                return data;
            }

        }

        public override void Push(string value)
        {

            if (this.itemcount == _count)
            {
                throw new Exception("Hata Stack dolu");
            }
            else
            {
                if(value != "")
                {
                    Node item = top;

                    top = new Node()
                    {
                        Data = value,
                        Next = item
                    };
                    _count++;
                }
                
            }

        }
    }
}
