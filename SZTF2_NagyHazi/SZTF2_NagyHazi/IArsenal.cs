using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    interface IArsenal
    {
        public int Price { get; set; }
        public int Usefulness { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
