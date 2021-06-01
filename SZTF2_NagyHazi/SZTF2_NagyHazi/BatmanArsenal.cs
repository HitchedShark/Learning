using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    abstract class BatmanArsenal: IArsenal
    {
        int price;
        int usefulness;
        double value;
        string name;

        public BatmanArsenal(string name, int price, int usefulness)
        {
            this.price = price;
            this.usefulness = usefulness;
            this.name = name;
            this.value = (double)usefulness / (double)price;

        }

        public int Price { get => price; set => price = value; }
        public int Usefulness { get => usefulness; set => usefulness = value; }
        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
