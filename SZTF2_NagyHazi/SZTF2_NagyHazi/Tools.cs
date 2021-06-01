using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class Tools: BatmanArsenal
    {
        double weight;
        public Tools(string name, int price, int usefulness, double weight) :base(name, price, usefulness)
        {
            this.Weight = weight;
        }

        public double Weight { get => weight; set => weight = value; }
    }
}
