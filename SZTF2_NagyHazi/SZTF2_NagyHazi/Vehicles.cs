using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class Vehicles: BatmanArsenal
    {
        string fuelType;
        public Vehicles(string name, int price, int usefulness, string fuelType) : base(name, price, usefulness)
        {
            this.FuelType = fuelType;
        }

        public string FuelType { get => fuelType; set => fuelType = value; }
    }
}
