using System;
using System.Collections.Generic;
using System.Text;

namespace SZTF2_NagyHazi
{
    delegate void MoneyDisplay(double money);
    class Webshop
    {
        public LinkedList<BatmanArsenal> webshopItems = new LinkedList<BatmanArsenal>();

        BruceWayne bruce;

        public void Init()
        {
            webshopItems.Insert(new Vehicles("Batmobile", 100000, 90, "Diesel"));
            webshopItems.Insert(new Vehicles("Batmobile with AI", 130000, 95, "Gasoline"));
            webshopItems.Insert(new Vehicles("Batbike", 50000, 50, "Diesel"));
            webshopItems.Insert(new Vehicles("Batcopter", 200000, 75, "Kerosine"));
            webshopItems.Insert(new Tools("Batarang", 5000, 6, 0.5));
            webshopItems.Insert(new Tools("Explosive Batarang", 8000, 9, 0.6));
            webshopItems.Insert(new Tools("Exploding Gel", 10000, 10, 2));
            webshopItems.Insert(new Tools("Grapple Gun", 6000, 9, 4));
            webshopItems.Insert(new Tools("Parachute", 12000, 5, 7.5));
            webshopItems.Insert(new Tools("Taser", 2000, 7, 3.5));
        }

        public void ShowStock(ListDisplay method)
        {
            webshopItems.PrintNodes(method);
        }

        public void SetBudget(double budget)
        {
            bruce = new BruceWayne(budget);
        }

        public void AddMoney(int money)
        {
            bruce.Budget += money;
        }

        public void CurrentMoney(MoneyDisplay money)
        {
            MoneyDisplay _money = money;
            _money?.Invoke(bruce.Budget);
        }

        public void PurchasedItems(ListDisplay method)
        {
            bruce.purchasedItems.PrintNodes(method);
        }

        public void BuyItem(string name)
        {
            if (webshopItems.Find(name).Price<=bruce.Budget)
            {
                bruce.purchasedItems.Insert(webshopItems.Find(name));
                bruce.Budget -= webshopItems.Find(name).Price;
                webshopItems.Delete(name);
            }
            else
            {
                throw new BudgetTooLowException("You don't have enough money to buy this item: " + name);
            }
            
        }

        public void InsertNewVehicle(string name, int price, int usefulness, string fuelType)
        {
            Vehicles item = new Vehicles(name, price,usefulness,fuelType);
            webshopItems.Insert(item);
        }

        public void InsertNewTool(string name, int price, int usefulness, double weight)
        {
            Tools item = new Tools(name, price, usefulness, weight);
            webshopItems.Insert(item);
        }
        public void DeleteItem(string itemName)
        {
            webshopItems.Delete(itemName);
        }

        public void PurchaseItem(string itemName)
        {
            bruce.Budget -= webshopItems.Find(itemName).Price;
            bruce.purchasedItems.Insert(webshopItems.Find(itemName));
            webshopItems.Delete(itemName);
        }

        public void Offer(ListDisplay offerDisplay)
        {
            ListDisplay _offerDisplay = offerDisplay;
            BinarySearchTree<BatmanArsenal, double> offer = new BinarySearchTree<BatmanArsenal, double>();
            int min = int.MaxValue;
            foreach (var item in webshopItems)
            {
                if (min>item.Price)
                {
                    min = item.Price;
                }
            }
            if (min>bruce.Budget)
            {
                throw new BudgetTooLowException("You can't purchase any items, because your budget is too low");
            }

            int itemCount = webshopItems.Count();
            int[,] pricesAndUse = GetPriceAndUsefulness();
            int[,] knapsack = new int[itemCount + 1, (int)bruce.Budget + 1];
            for (int i = 0; i <= itemCount; i++)
            {
                for (int j = 0; j <= bruce.Budget; j++)
                {
                    if (i==0 || j==0)
                    {
                        knapsack[i, j] = 0;
                    }
                    else if (j>=pricesAndUse[0,i])
                    {
                        knapsack[i, j] = Math.Max(knapsack[i - 1, j], knapsack[i - 1, j - pricesAndUse[0, i]] + pricesAndUse[1, i]);
                    }
                    else
                    {
                        knapsack[i, j] = knapsack[i - 1, j];
                    }
                }
            }
            int maxUsefulness = knapsack[itemCount, (int)bruce.Budget];
            

            int budget = (int)bruce.Budget;
            for (int i = itemCount; i > 0 && maxUsefulness > 0; i--)
            {
                if (maxUsefulness != knapsack[i - 1, budget])
                {
                    int iterator = 0;
                    foreach (var item in webshopItems)
                    {
                        iterator++;
                        if (i==iterator)
                        {
                            offer.Insert(item, item.Price);
                        }
                    }
                    maxUsefulness -=pricesAndUse[1, i];
                    budget -=pricesAndUse[0, i];
                }  
            }
            int position = 1;
            foreach (var item in offer)
            {
                _offerDisplay(item,position);
                position++;
            }
        }

        public int[,] GetPriceAndUsefulness()
        {
            int itemCount = webshopItems.Count();
            int[,] prices = new int[2, itemCount + 1];
            int idx = 1;

            prices[0, 0] = 0;
            prices[0, 1] = 0;
            foreach (var item in webshopItems)
            {
                prices[0, idx] = item.Price;
                prices[1, idx] = item.Usefulness;
                idx++;
            }
            return prices;
        }
    }
}
