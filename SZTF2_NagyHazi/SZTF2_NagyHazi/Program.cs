using System;

namespace SZTF2_NagyHazi
{
    class Program
    {
        static void WebshopItems(BatmanArsenal arsenal, int position)
        {
            if (position==1)
            {
                Console.WriteLine("Items in the webshop:");
            }
            switch (arsenal)
            {
                case Vehicles v:
                    Console.WriteLine("Name: " + v.Name + ", Price: $" + v.Price + ", Usefulness: " + v.Usefulness + ", FuelType: " + v.FuelType);
                    break;
                case Tools t:
                    Console.WriteLine("Name: " + t.Name + ", Price: $" + t.Price + ", Usefulness: " + t.Usefulness + ", Weight: " + t.Weight);
                    break;
            }
        }
        static void PurchasedItems(BatmanArsenal arsenal, int position)
        {
            if (position == 1)
            {
                Console.WriteLine("Items you purchased:");
            }
            switch (arsenal)
            {
                case Vehicles v:
                    Console.WriteLine("Name: " + v.Name + ", Price: $" + v.Price + ", Usefulness: " + v.Usefulness + ", FuelType: " + v.FuelType);
                    break;
                case Tools t:
                    Console.WriteLine("Name: " + t.Name + ", Price: $" + t.Price + ", Usefulness: " + t.Usefulness + ", Weight: " + t.Weight);
                    break;
            }
        }
        static void OfferedItems(BatmanArsenal arsenal, int position)
        {
            if (position == 1)
            {
                Console.WriteLine("Items offered to you:");
            }
            switch (arsenal)
            {
                case Vehicles v:
                    Console.WriteLine("Name: " + v.Name + ", Price: $" + v.Price + ", Usefulness: " + v.Usefulness + ", FuelType: " + v.FuelType);
                    break;
                case Tools t:
                    Console.WriteLine("Name: " + t.Name + ", Price: $" + t.Price + ", Usefulness: " + t.Usefulness + ", Weight: " + t.Weight);
                    break;
            }
        }
        static void Budget(double money)
        {
            Console.WriteLine("Your current budget is: $" + money);
        }
        static void Main(string[] args)
        {
            Run();
            Console.Read();
        }

        static void Run()
        {
            Webshop webshop = new Webshop();
            webshop.Init();
           
            Console.WriteLine("Please enter your Budget: ");
            CommandList();
            string[] data = System.IO.File.ReadAllLines(@"C:\Users\Mali\source\repos\SZTF2_NagyHazi\SZTF2_NagyHazi\bin\Debug\netcoreapp3.1\commands.txt");
            webshop.SetBudget(Convert.ToInt32(data[0]));
            string command = "";
            int commandIterator = 1;
            while (command != "Exit" || commandIterator < data.Length)
            {
                try
                {
                    string[] commands = data[commandIterator].Split(':');
                    command = commands[0];
                    switch (command)
                    {
                        case "Add":
                            if (commands[4] is string)
                            {
                                webshop.InsertNewVehicle(commands[1], Convert.ToInt32(commands[2]), Convert.ToInt32(commands[3]), commands[4]);
                            }
                            else
                            {
                                webshop.InsertNewTool(commands[1], Convert.ToInt32(commands[2]), Convert.ToInt32(commands[3]), Convert.ToDouble(commands[4]));
                            }
                            break;
                        case "Delete":
                            try
                            {
                                webshop.DeleteItem(commands[1]);
                            }
                            catch (NoSuchItemException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            
                            break;
                        case "Offer":
                            try
                            {
                                webshop.Offer(OfferedItems);
                            }
                            catch (BudgetTooLowException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "Buy":
                            try
                            {
                                webshop.BuyItem(commands[1]);
                            }
                            catch (BudgetTooLowException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (NoSuchItemException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "Purchased":
                            try
                            {
                                webshop.PurchasedItems(PurchasedItems);
                            }
                            catch (NoNodesToPrintException)
                            {
                                Console.WriteLine("There are no purchased items yet");
                            }
                            break;
                        case "Addmoney":
                            webshop.AddMoney(Convert.ToInt32(commands[1]));
                            break;
                        case "List":
                            try
                            {
                                webshop.ShowStock(WebshopItems);
                            }
                            catch (NoNodesToPrintException)
                            {
                                Console.WriteLine("There are no items in the webshop");
                            }
                            break;
                        case "Budget":
                            webshop.CurrentMoney(Budget);
                            break;
                        case "Exit":
                            break;
                        default:
                            throw new NotValidCommandException("Not a valid command!");
                    }
                }
                catch (NotValidCommandException e)
                {
                    Console.WriteLine(e.Message);
                }
                commandIterator++;
            }
           
        }
        static void CommandList()
        {
            Console.WriteLine("Enter a command");
            Console.WriteLine("Possible commands: List, Budget, Add, Delete, Offer, Buy, Addmoney, Purchased, Exit\n");
            Console.WriteLine("If you want to list the contents of the webshop typ: List");
            Console.WriteLine("If you want to view how much money you have type: Budget");
            Console.WriteLine("If you want to add a vehicle you have to give its \nname, price, usefulness and fuel type like so: Add:name:price:usefulness:fueltype");
            Console.WriteLine("If you want to add a tool you have to give its \nname, price, usefulness and weight like so: Add:name:price:usefulness:weight");
            Console.WriteLine("If you want to delete an item you have to give its name, like so: Delete:name");
            Console.WriteLine("If you want to view the best possibe combination of items type: Offer");
            Console.WriteLine("If you want to buy an item you have to give its name, like so: Buy:name");
            Console.WriteLine("If you want to view your purchased items type: Purchased");
            Console.WriteLine("If you want to add money to your budget you havet give the ammont, like so: Addmoney:ammount\n");

        }
    }
}
