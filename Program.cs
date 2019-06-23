using System;
using System.Collections;
using System.Collections.Generic;

namespace OnlineGroceryStory
{
    public class OnlineOrder 
    {
        private double amount = 0;
        List<StructProductPackage> ProductPackages;
        List<StructOrders> Orders;

        public struct StructProductPackage
            {
                public int ID;
                public string code;
                public int Packs;
                public double price;
                public string name;
            };


            public struct StructOrders
            {
                public string PackageID;
                public int Packs;
                public double amount;
            };


            public void Init()
            {
                ProductPackages = new List<StructProductPackage>();
                ProductPackages.Add(new StructProductPackage() { ID = 1, Packs = 3, code = "SH3", price = 2.99 });
                ProductPackages.Add(new StructProductPackage() { ID = 2, Packs = 5, code = "SH3", price = 4.49 });
                ProductPackages.Add(new StructProductPackage() { ID = 3, Packs = 4, code = "YT2", price = 4.95 });
                ProductPackages.Add(new StructProductPackage() { ID = 4, Packs = 10, code = "YT2", price = 9.95 });
                ProductPackages.Add(new StructProductPackage() { ID = 5, Packs = 15, code = "YT2", price = 13.95 });
                ProductPackages.Add(new StructProductPackage() { ID = 6, Packs = 3, code = "TR", price = 2.95 });
                ProductPackages.Add(new StructProductPackage() { ID = 7, Packs = 5, code = "TR", price = 4.45 });
                ProductPackages.Add(new StructProductPackage() { ID = 8, Packs = 9, code = "TR", price = 7.99 });

                Orders = new List<StructOrders>();
            }


            //To find the number of packs to meet the number of order
            public void PacksNumber(int orderquantity, int[] packs, string ProductCode)
            {
                int outputquantity = orderquantity;
                int n = packs.Length;
                int[] packsNum = new int[orderquantity + 1];//Storing the minimal packs number 
                int[] packsValue = new int[orderquantity + 1];//the packs Value
                packsNum[0] = 0;

                for (int i = 1; i <= orderquantity; i++)
                {
                    int minNum = i;//i packs，need the minimal number of packs
                    int usedPacks = 0;//this order, the number of need for packs
                    for (int j = 0; j < n; j++)
                    {
                        if (i >= packs[j])//the order number is larger than packs number
                        {
                            if (packsNum[i - packs[j]] + 1 <= minNum && (i == packs[j] || packsValue[i - packs[j]] != 0))//the need of packs number is decreased 
                            {
                                minNum = packsNum[i - packs[j]] + 1;//refresh
                                usedPacks = packs[j];//refresh
                            }
                        }
                    }
                    packsNum[i] = minNum;
                    packsValue[i] = usedPacks;
                }

                //Output
                if (packsValue[orderquantity] == 0)
                    Console.WriteLine("Each order should contain the minimal number of packs or type the correct item ID");

                else
                {
                    Console.WriteLine("Order detail");
                   // double amount = 0;
                    string tempproductCode = "";
                    while (orderquantity > 0)
                    {
                        foreach (var product in ProductPackages)
                        {
                         
                            if(product.code== ProductCode && product.Packs == packsValue[orderquantity])
                            {
                                amount += product.price;
                                Console.WriteLine(packsValue[orderquantity].ToString() + " " + product.code + " " + product.price +"$");
                                tempproductCode = product.code;
                            }

                        }
                        orderquantity -= packsValue[orderquantity];
                    }
                     Console.WriteLine(outputquantity.ToString() + " "+ tempproductCode + " " + amount + "$");
                }


                
            }

            public double Amount
             {
                get { return amount; }
             }


            public ArrayList GetPackageNumbers(string code)
            {
                ArrayList al = new ArrayList();
                foreach (var PK in ProductPackages)
                {
                    if (PK.code == code)
                    {
                        al.Add(PK.Packs);
                    }

                }
                return al;
            }

            public void PlaceOrder(string ProductCode, int quantity)
            {
                var alist = GetPackageNumbers(ProductCode);
                int[] str = alist.ToArray(typeof(int)) as int[];

                PacksNumber(quantity, str, ProductCode);
            }

        }

        class Program
        {
            public static void Main(string[] args)
            {
                //input order
                Console.WriteLine("input Item ID:");
                string ItemID = Console.ReadLine();

                Console.WriteLine("input quantity:");
                int quantity =Convert.ToInt32(Console.ReadLine()) ;

                OnlineOrder i = new OnlineOrder();
                i.Init();
                i.PlaceOrder(ItemID, quantity);
               
            }

        }
    }

    
