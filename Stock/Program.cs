using System;

namespace Stock
{
    class Program
    {
        double Balance = 5000.0;
        double Total = 0;
        double[,] Portfolio = new double[4, 2];
        double ASDF = 200.0;
        double QWER = 100.0;
        double VBNM = 2000.0;
        double TYUI = 50.0;
        int DaysPassed = 1;

        void BuyStock(int StockName, double Amount)
        {
            double StockPrice = 0;
            switch (StockName)
            {
                case 1:
                    StockPrice = ASDF;
                    break;
                case 2:
                    StockPrice = QWER;
                    break;
                case 3:
                    StockPrice = VBNM;
                    break;
                case 4:
                    StockPrice = TYUI;
                    break;
            }

            StockName -= 1;
            Total = StockPrice * Amount;

            if (Total > Balance)
                Console.WriteLine("Insufficient Balance!");
            else if (StockName < 1 && StockName > 4)
                Console.WriteLine("Invalid stockname!");
            else
            {
                Balance -= StockPrice * Amount;
                Portfolio[StockName, 0] += Total;
                Portfolio[StockName, 1] += Amount;
            }
        }

        void SellStock(int StockName, double Amount)
        {
            double StockPrice = 0;
            switch (StockName)
            {
                case 1:
                    StockPrice = ASDF;
                    break;
                case 2:
                    StockPrice = QWER;
                    break;
                case 3:
                    StockPrice = VBNM;
                    break;
                case 4:
                    StockPrice = TYUI;
                    break;
            }

            StockName -= 1;
            Total = StockPrice * Amount;

            if (Portfolio[StockName, 0] == 0)
                Console.WriteLine("Empty Location!");
            else if (StockName < 0 && StockName > 3)
                Console.WriteLine("Invalid Location!");
            else if (Portfolio[StockName, 1] < Amount)
                Console.WriteLine("Selling ammount cannot be bigger than your owned amount!");
            else
            {
                if (Portfolio[StockName, 1] == Amount)
                {
                    Portfolio[StockName, 0] = 0;
                    Portfolio[StockName, 1] = 0;
                    Balance += StockPrice * Amount;
                }
                else
                {
                    Portfolio[StockName, 0] -= Total;
                    Portfolio[StockName, 1] -= Amount;
                    Balance += StockPrice * Amount;
                }
            }
        }

        void ShowAccount()
        {
            Console.WriteLine("-----Account-----");
            Console.WriteLine("Balance: " + Balance + "$");
            Console.WriteLine("Stocks:");
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("[ASDF] | Total: " + Portfolio[i, 0] + "$" + " Amount: " + Portfolio[i, 1]);
                        break;
                    case 1:
                        Console.WriteLine("[QWER] | Total: " + Portfolio[i, 0] + "$" + " Amount: " + Portfolio[i, 1]);
                        break;
                    case 2:
                        Console.WriteLine("[VBNM] | Total: " + Portfolio[i, 0] + "$" + " Amount: " + Portfolio[i, 1]);
                        break;
                    case 3:
                        Console.WriteLine("[TYUI] | Total: " + Portfolio[i, 0] + "$" + " Amount: " + Portfolio[i, 1]);
                        break;
                }

            }
            Console.WriteLine("-----------------");
        }

        void NextDay()
        {
            for (int i = 0; i < 4; i++)
            {
                Random Rand = new Random();
                double Percentage = Rand.Next(1, 11);
                double UpOrDown = Rand.Next(0, 2);
                //Console.WriteLine(Percentage + " " + UpOrDown);
                switch (i)
                {
                    case 0:
                        if (UpOrDown == 1)
                        {
                            //Console.WriteLine("If Case" + i);
                            ASDF += ASDF * (Percentage / 100);
                        }
                        else
                        {
                            //Console.WriteLine("Else Case" + i);
                            ASDF -= ASDF * (Percentage / 100);
                        }
                        break;
                    case 1:
                        if (UpOrDown == 1)
                        {
                            QWER += QWER * (Percentage / 100);
                            //Console.WriteLine("If Case" + i);
                        }
                        else
                        {
                            QWER -= QWER * (Percentage / 100);
                            //Console.WriteLine("Else Case" + i);
                        }
                        break;
                    case 2:
                        if (UpOrDown == 1)
                        {
                            VBNM += VBNM * (Percentage / 100);
                            //Console.WriteLine("If Case" + i);
                        }
                        else
                        {
                            VBNM -= VBNM * (Percentage / 100);
                            //Console.WriteLine("Else Case" + i);
                        }
                        break;
                    case 3:
                        if (UpOrDown == 1)
                        {
                            TYUI += TYUI * (Percentage / 100);
                            //Console.WriteLine("If Case" + i);
                        }
                        else
                        {
                            TYUI -= TYUI * (Percentage / 100);
                            //Console.WriteLine("Else Case" + i);
                        }
                        break;
                }
            }
            DaysPassed++;
        }

        void ShowMenu()
        {
            //Console.WriteLine("STOCK EXCHANGE");
            Console.WriteLine("Day " + DaysPassed);
            Console.WriteLine("--------------");
            Console.WriteLine("ASDF(1): " + ASDF);
            Console.WriteLine("QWER(2): " + QWER);
            Console.WriteLine("VBNM(3): " + VBNM);
            Console.WriteLine("TYUI(4): " + TYUI);
            Console.WriteLine("--------------");
            Console.WriteLine("1. Show Account");
            Console.WriteLine("2. Buy Stock");
            Console.WriteLine("3. Sell Stock");
            Console.WriteLine("4. Next Day");
            Console.WriteLine("0. Exit");
            Console.Write("Option:");
        }

        static void Main(string[] args)
        {
            Program P = new Program();
            int Option = 0;
            do
            {
                P.ShowMenu();
                Option = Convert.ToInt32(Console.ReadLine());

                switch (Option)
                {
                    case 1:
                        P.ShowAccount();
                        break;
                    case 2:
                        Console.WriteLine("Stock Name: ");
                        int BuyStockOption = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Buy Amount:");
                        double BuyAmount = Convert.ToDouble(Console.ReadLine());
                        P.BuyStock(BuyStockOption, BuyAmount);
                        P.ShowAccount();
                        break;
                    case 3:
                        P.ShowAccount();
                        Console.WriteLine("Stock Name: ");
                        int StockName = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Sell Amount: ");
                        double SellAmount = Convert.ToDouble(Console.ReadLine());
                        P.SellStock(StockName, SellAmount);
                        break;
                    case 4:
                        P.NextDay();
                        break;
                }
            } while (Option != 0);
        }
    }
}