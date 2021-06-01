using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    class BruceWayne
    {
        double budget;
        public LinkedList<BatmanArsenal> purchasedItems;
        public BruceWayne(double budget)
        {
            this.budget = budget;
            purchasedItems = new LinkedList<BatmanArsenal>();
        }
        public double Budget { get => budget; set => budget = value; }
    }
}
