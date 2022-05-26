using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class LinkedList : LinkedListADT
    {
        public override string DisplayElements()
        {
            string temp = "";

            Nodee item = Head;

            while (item.Next != null)
            {
                temp += item.Data.ToString();
                temp += " >> ";
                item = item.Next;
            }
            temp += item.Data.ToString();
            return temp;
        }

        public override void InsertFirst(string key,string value)
        {
            Nodee item = new Nodee()
            {
                Data = value,
                key = key,
                
            };

            if (Head == null)
            {
                Head = item;

            }
            else
            {
                item.Next = Head;
                Head = item;
            }

            Count++;
        }

        public override void InsertLast(string key,string value)
        {
            Nodee item = new Nodee()
            {
                key = key,
                Data = value,
            };

            if (Head == null)
            {
                InsertFirst(key,value);
            }
            else
            {
                Nodee tmpHead = Head;

                while (tmpHead.Next != null)
                {
                    tmpHead = tmpHead.Next;
                }

                
                tmpHead.Next = item;
                item.Next = null;

            }
            Count++;
        }

        public override void Remove(string key)
        {
            Nodee item = Head;

            while(item != null)
            {
                
                if (item.Next.key == key)
                    break;

                item = item.Next;
            }

            Nodee tmpitem = item.Next.Next;
            item.Next = null;
            item.Next = tmpitem;
            
        }

        public override void RemoveFirst()
        {
            Nodee item = Head.Next;

            Head = null;
            Head = item;
            Count--;
        }

        public override bool Search(string key)
        {
            Nodee item = Head;

            while(item != null)
            {
                if (item.key == key)
                    break;

                item = item.Next;
            }

            if (item == null)
                return false;
            else
                return true;
        }
    }
}
