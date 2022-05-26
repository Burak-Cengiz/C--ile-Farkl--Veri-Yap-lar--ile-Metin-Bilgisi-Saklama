using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metin_Yazari_Bulma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StackLinkedList StackKelime = new StackLinkedList(1000);
        StackLinkedList StackCumle = new StackLinkedList(1000);
        PriortyQueue priortyQueue = new PriortyQueue(1000);
        Heap Heap = new Heap(1000);
        HashMap hash = new HashMap(1000);
        
        public string Text;
        public char[] Chars;
        public string[] TextDizi;
        public string[] TextCumle = new string[50];
        public string[] tmpText = new string[500];
        public string[] SortingText;
        HeapSort HeapSort;

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.Title = "txt Dosyası Seçiniz..";

            file.ShowDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                
                string DosyaYolu = file.FileName;
                string DosyaAdi = file.SafeFileName;
                txtBxFilePath.Text = DosyaYolu;
                var filee = file.OpenFile();
                StreamReader reader = new StreamReader(filee);
                string line;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    TextCumle[i] = line;
                    TextCumle[i] = TextCumle[i].ToLower();
                    Text += TextCumle[i];
                    i++;
                }                              
              
            }         
            Text = Text.ToLower();
            TextDizi = Text.Split();
            
        }

        private void btnStackAktar_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach (string t in TextDizi)
            {
                Chars = new char[t.Length];
                int i = 0;
                int j = 0;
                
                foreach (char c in t)
                {

                    if (!Char.IsPunctuation(c))
                    {
                        Chars[i] = c;
                        i++;
                        j++;
                    }
                    else if (j != 0)
                    {
                        break;
                    }
                }
                string metin = "";
                foreach (char c in Chars)
                {
                    if (c != '\0')
                        metin += c;
                }
                
                StackKelime.Push(metin);

                if(metin != "")
                {
                    tmpText[k] = metin;
                    k++;
                }
                    
            }
            HeapSort = new HeapSort(tmpText);

            foreach (string s in TextCumle)
            {
                if(s != null)
                {
                    Chars = new char[s.Length];
                    int i = 0;
                   

                    foreach (char c in s)
                    {

                        if (!Char.IsPunctuation(c))
                        {
                            Chars[i] = c;
                            i++;
                           
                        }
                        else 
                        {
                            continue;
                        }

                    }
                    string metin = "";
                    foreach (char c in Chars)
                    {
                        if (c != '\0')
                            metin += c;
                    }

                    StackCumle.Push(metin);
                }
                
            }
          
            MessageBox.Show("Başarıyla Stack'e Aktarıldı!!");

            lblDegiskenCumleValue.Text = CumleSayisi(TextCumle).ToString();

            txtBxCumleKelimeSayi.Text = Cumle_KelimeBul(TextCumle);

            lblOrtalamaKValue.Text = OrtKelimeSayi(TextCumle, TextDizi).ToString();

            lblToplamKelimeSayi.Text = ToplamKelimeSayi(TextDizi).ToString();
            
        }

        public int CumleSayisi(string[] dizi)
        {
            int cumleSayisi = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] != null)
                    cumleSayisi++;
                else
                    break;
            }
            return cumleSayisi;
        }

        public string Cumle_KelimeBul(string[] dizi)
        {
            string tmp = "";
            string[] Metin;
            int KelimeSayi;
            for (int i = 0; i < dizi.Length; i++)
            {
                if(dizi[i] != null)
                {
                    Metin = new string[dizi[i].Length];
                    Metin = dizi[i].Split();
                    KelimeSayi = Metin.Length;
                    tmp += i + 1 + ".Cumledeki Kelime Sayisi: " + (KelimeSayi-1) + "  ";
                }
                
            }

            return tmp;
        }
        public int OrtKelimeSayi(string[] Cumle,string[] Kelime)
        {
            int OrtalamaKelime = Kelime.Length;
            OrtalamaKelime = OrtalamaKelime / CumleSayisi(Cumle);
            return OrtalamaKelime;
        }
        public int ToplamKelimeSayi(string[] dizi)
        {
            int toplam = 0;

            foreach (var s in dizi)
                toplam++;

            return toplam;
        }
        private void btnHeapAktar_Click(object sender, EventArgs e)
        {
            foreach (string item in tmpText)
            {
                if (item != null)
                {
                    Heap.Insert(item);
                }
                else
                    break;
            }

            SortingText = HeapSort.Sort();

            MessageBox.Show("Başarıyla Heap'e Aktarıldı!");
           
        }


        public void EnCokKullanilanKelimeBul(string[] dizi)
        {
            string kelime = "";
            int sayac = 1;
            for (int i = 0; i < dizi.Length-1; i++)
            {
                if (dizi[i] == dizi[i + 1])
                {
                    sayac++;
                }
                else
                {
                    KelimeSayi kelimeSayi = new KelimeSayi();
                    kelimeSayi.kelime = dizi[i];
                    kelimeSayi.kelimeSayi = sayac;
                    priortyQueue.push(kelimeSayi);
                    sayac = 1;
                }
                    
            }
            
        }

        private void btnKelimeSayiBul_Click(object sender, EventArgs e)
        {
            EnCokKullanilanKelimeBul(SortingText);
            string tmp = "";
            for (int i = 0; i < 20; i++)
            {
                KelimeSayi kelimesayi = new KelimeSayi();
                kelimesayi = priortyQueue.pop();
                tmp += " En çok kullanılan "+ (i+1) + ". kelime : " + kelimesayi.kelime + ": " + kelimesayi.kelimeSayi.ToString() + Environment.NewLine;
            }
            txtBxKelimeSayilari.Text = tmp;

            foreach (string s in SortingText)
            {
                hash.insert(s, s);
            }
        }

        private void btnHashTblo_Click(object sender, EventArgs e)
        {
            

            HashTblo();
           
        }

        public void HashTblo()
        {
            txtBxHashTblo.Clear();
            for (int i = 100; i < 200; i++)
            {
                string tmp = "";
                if (hash.table[i] == null)
                    continue;
                             
                if (hash.linkedList[i].Head != null)
                    tmp += hash.linkedList[i].DisplayElements();
                else
                    tmp = hash.table[i].getdata();

                txtBxHashTblo.Text += i + ".indiste " + "-- " + tmp + " --" + " bulunuyor!" + Environment.NewLine;
            }
        }
       

        private void btnHashAra_Click(object sender, EventArgs e)
        {
            try
            {
                txtBxIndis.Text = hash.retrieve(txtBxIndis2.Text).ToString();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        }

        private void btnHastSil_Click(object sender, EventArgs e)
        {

            if (hash.remove(txtBxSilinecekKelime.Text))
                MessageBox.Show("Başarıyla Silindi!");
            else
                MessageBox.Show("Böyle bir kelime bulunamadı!");
                      
            HashTblo();
        }
    }
}
