using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public class HashMap
    {
        public int maxSize;
        public int count;
        public HashEntry[] table;
        public LinkedList[] linkedList;
        public HashMap(int Size)
        {
            this.maxSize = Size;    
            table = new HashEntry[maxSize];
            linkedList = new LinkedList[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
            for (int i = 0; i < maxSize; i++)
            {
                linkedList[i] = new LinkedList();
            }
        }
        public int hash(string s)
        {
            int hash = 0;
            if (s != null)
            {
                foreach (char c in s)
                {
                    hash = (hash + (c - 'A'));
                }
                hash = hash % maxSize;
            }
            
            return hash;
        }
        public int retrieve(string key)
        {
            int hash = this.hash(key);
            if(table[hash] != null && table[hash].getkey() != key)
            {
                if (linkedList[hash].Search(key))
                    return hash;
                else
                    throw new Exception("Böyle bir kelime bulunamadı!");
            }
            if (table[hash] == null)
            {
                throw new Exception("Böyle bir kelime bulunamadı!");
            }
            else
            {
               return hash;
            }
        }
        public void insert(string key, string data)
        {
            
            int hash = this.hash(key);
            if(hash > 0)
            {
                if(table[hash] != null && table[hash].getkey() != key)
                {
                    linkedList[hash].InsertFirst(table[hash].getkey(),table[hash].getdata());
                    linkedList[hash].InsertLast(key,data);
                }
                else
                    table[hash] = new HashEntry(key, data);

                count++;
            }
            
        }
        
        public bool remove(string key)
        {
            int hash = this.hash(key);
      
            if(table[hash] != null && table[hash].getkey() != key)
            {
                linkedList[hash].Remove(key);
                
                count--;
                return true;
            }
            else if(table[hash] == null)
            {
                return false;
            }              
            else
            {
                table[hash] = null;
                count--;
                return true;
            }
            
        }
       
       
       
    }
}
