using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metin_Yazari_Bulma
{
    public abstract class QueueADT
    {
        public abstract bool isEmpty();
        public abstract void push(KelimeSayi value);
        public abstract KelimeSayi pop();
        
        
    }
}
