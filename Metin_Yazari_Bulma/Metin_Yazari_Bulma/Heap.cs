using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class Heap
    {
        public int currentSize;
        public int maxSize;
        public HeapDugumu[] heapArray;

        public Heap(int size)
        {
            heapArray = new HeapDugumu[size];
            this.maxSize = size;
        }

        public bool IsEmpty()
        { return currentSize == 0; }



        public bool Insert(string value)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }

        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            int check = string.Compare(heapArray[parent].Deger, bottom.Deger);
            while (index > 0 && check > 0)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
                check = string.Compare(heapArray[parent].Deger, bottom.Deger);
            }
            heapArray[index] = bottom;
        }

        public HeapDugumu RemoveMax()
        {
            HeapDugumu root = heapArray[0];


            heapArray[0] = heapArray[--currentSize];
            heapArray[currentSize] = null;

            MoveToDown(0);
            return root;
        }

        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                int check=0;

                if(heapArray[rightChild] != null && heapArray[leftChild] != null)
                {
                    check = string.Compare(heapArray[leftChild].Deger, heapArray[rightChild].Deger);
                }
                

                if (rightChild < currentSize && check > 0)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                int check2 = string.Compare(top.Deger, heapArray[largerChild].Deger);
                if (check2 == -1)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }

    }
}
