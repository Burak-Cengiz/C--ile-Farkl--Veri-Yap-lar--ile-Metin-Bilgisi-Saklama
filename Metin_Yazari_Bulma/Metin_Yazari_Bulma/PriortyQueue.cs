using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class PriortyQueue : QueueADT
    {
        private KelimeSayi[] Queue;
        private int front = -1;

        private int size = 0;
        private int count = 0;
        public PriortyQueue(int size)
        {
            this.size = size;
            Queue = new KelimeSayi[size];
        }

        public override bool isEmpty()
        {
            return count == 0;
        }

        public override KelimeSayi pop()
        {
            if (this.isEmpty())
            {
                throw new Exception("Queue boş");
            }
            KelimeSayi temp = Queue[front];
            Queue[front] = null;
            front--;
            count--;
            return temp;
        }

        public override void push(KelimeSayi value)
        {
            if (count == size)
            {
                throw new Exception("Queue dolu");
            }
            if (isEmpty())
            {
                front++;
                Queue[front] = value;
                count++;
            }
            else
            {
                int i;
                
                for (i = count - 1; i >= 0; i--)
                {
                    if (value.kelimeSayi < Queue[i].kelimeSayi)
                        Queue[i + 1] = Queue[i];
                    else
                        break;
                }
                Queue[i + 1] = value;
                front++;
                count++;
            }
        }
    }
}
