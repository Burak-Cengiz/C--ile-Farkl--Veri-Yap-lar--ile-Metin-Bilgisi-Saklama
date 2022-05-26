using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class HeapSort
    {
        public string[] dizi;
        public HeapSort(string[] dizi)
        {
            this.dizi = dizi;
        }
        public string[] Sort()
        {
            Heap h = new Heap(dizi.Length);
            string[] sorted = new string[dizi.Length];
            //Heap Ağacı Oluştur (nlog(n))
            foreach (var item in dizi)
            {
                if (item != null)
                    h.Insert(item);
                else
                    break;
            }
                
            int i = 0;
            //Ağaçtaki maksimum elemanı al ve
            //yeni diziye ekle (nlog(n))
            while (!h.IsEmpty())
                sorted[i++] = h.RemoveMax().Deger;
            return sorted;
        }

    }
}
