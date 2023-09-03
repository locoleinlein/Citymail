using Citymail1.Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace Citymail1
{
    class Program
    {
        static Dictionary<string, DeliveryUnit> deliveryUnitDictionary = new Dictionary<string, DeliveryUnit>();

        static List<Package> packageList = new List<Package>();

        static int packageId = 0;

        static void Main(string[] args)
        {
            string correctUsername = "1";
            string correctPassword = "1";
            string usernameInput;
            string passwordInput;

            bool invalidInput;

            CursorVisible = false;

            LogInView(correctUsername, correctPassword, out usernameInput, out passwordInput);
            
            do
            {
                MainMenyView();

                ConsoleKeyInfo mainMenyInput = ReadKey(true);
                Clear();

                
                switch (mainMenyInput.Key)
                {
                    case ConsoleKey.D1:
                        ConsoleKeyInfo deliveryUnitInput = RegisterOrSearchView();

                        switch (deliveryUnitInput.Key)
                        {
                            case ConsoleKey.D1:
                                ConsoleKeyInfo registerOrSearchInput;
                                DeliveryUnitChoiceView(out invalidInput, out registerOrSearchInput);

                                switch (registerOrSearchInput.Key)
                                {
                                    case ConsoleKey.D1:
                                        AddCarMenyView();
                                        break;

                                    case ConsoleKey.D2:
                                        AddQuadcopterMenyView();
                                        break;
                                }
                                break;

                            case ConsoleKey.D2:

                                SearchUnitView();
                                break;
                        }
                        break;

                    case ConsoleKey.D2:

                        AddPackageView();

                        break;

                    case ConsoleKey.D3:

                        ListPackageView();

                        break;

                    case ConsoleKey.D4:

                        DeliverPackageMetod();
                        break;

                    case ConsoleKey.D5:

                        LogInView(correctUsername, correctPassword, out usernameInput, out passwordInput);
                        break;
                }

            } while (true);
        }

        private static ConsoleKeyInfo RegisterOrSearchView()
        {
            SetCursorPosition(4, 1);
            Write("1. Register");

            SetCursorPosition(4, 3);
            Write("2. Search");

            ConsoleKeyInfo deliveryUnitInput = ReadKey(true);
            Clear();
            return deliveryUnitInput;
        }

        private static void DeliveryUnitChoiceView(out bool invalidInput, out ConsoleKeyInfo registerOrSearchInput)
        {
            SetCursorPosition(4, 1);
            Write("1. Car");

            SetCursorPosition(4, 3);
            Write("2. Quadcopter");
            do
            {
                registerOrSearchInput = ReadKey(true);
                invalidInput = !(registerOrSearchInput.Key == ConsoleKey.D1 || registerOrSearchInput.Key == ConsoleKey.D2);

            } while (invalidInput);

            Clear();
        }

        private static void DeliverPackageMetod()
        {
            foreach (var deliveryUnits in deliveryUnitDictionary)
            {
                foreach (var packages in packageList)
                {
                    if (packages.Status == "Pending delivery")
                    {
                        packages.Status = "Delivered";
                        WriteLine("Package sent to destination.");
                        Thread.Sleep(2000);
                        Clear();
                        break;
                    }
                }
            }
        }

        private static void ListPackageView()
        {
            WriteLine($@"ID          Destination          Status");
            foreach (Package packages in packageList)
            {
                WriteLine("------------------------------------------");
                WriteLine($"{packages.PackageId + 1,-11 } {packages.Destination,-20} {packages.Status}");
            }

            WriteLine(" ");
            Write("Press (Enter) to exit");
            while (ReadKey(true).Key != ConsoleKey.Enter) ;

            Clear();
        }

        private static bool AddPackageView()
        {
            bool invalidInput;
            SetCursorPosition(4, 1);
            Write("Sender: ");
            string sender = ReadLine();

            SetCursorPosition(4, 3);
            Write("Destination: ");
            string destination = ReadLine();

            SetCursorPosition(4, 7);
            Write("Is this correct? (Y)es (N)o");

            ConsoleKeyInfo registerPackage;

            do
            {
                registerPackage = ReadKey(true);
                invalidInput = !(registerPackage.Key == ConsoleKey.Y || registerPackage.Key == ConsoleKey.N);

            } while (invalidInput);

            Clear();

            string status = "Pending delivery";

            Package package = new Package(sender, destination, packageId, status);

            switch (registerPackage.Key)
            {
                case ConsoleKey.Y:

                    packageList.Add(package);
                    packageId++;

                    SetCursorPosition(4, 1);
                    WriteLine("Package registered");

                    Thread.Sleep(2000);

                    break;

                case ConsoleKey.N:
                    SetCursorPosition(4, 1);
                    WriteLine("Package not registered");

                    Thread.Sleep(2000);

                    break;

            }

            return invalidInput;
        }

        private static void LogInView(string correctUsername, string correctPassword, out string usernameInput, out string passwordInput)
        {
            do
            {
                SetCursorPosition(4, 1);
                Write("Username: ");
                usernameInput = ReadLine();

                SetCursorPosition(4, 3);
                Write("Password: ");
                passwordInput = ReadLine();

                Clear();

                if (usernameInput != correctUsername || passwordInput != correctPassword)
                {
                    SetCursorPosition(4, 1);
                    Write("Invalid credentials, please try again");
                    Thread.Sleep(2000);
                    Clear();
                }

            } while (usernameInput != correctUsername || passwordInput != correctPassword);
        }

        private static void MainMenyView()
        {
            SetCursorPosition(4, 1);
            Write("1. Delivery units");
            SetCursorPosition(4, 3);
            Write("2. Register package");
            SetCursorPosition(4, 5);
            Write("3. List packages");
            SetCursorPosition(4, 7);
            Write("4. Start delivery");
            SetCursorPosition(4, 9);
            Write("5. Logout");
        }

        private static void SearchUnitView()
        {
            SetCursorPosition(4, 1);
            Write("Unit ID: ");
            string id = ReadLine().ToUpper();
            Clear();

            if (deliveryUnitDictionary.ContainsKey(id))
            {
                deliveryUnitDictionary[id].ViewDeliveryUnitDetails();

             
                WriteLine(" ");
                SetCursorPosition(4, 11);
                Write("Press (Escape) to exit");
                while (ReadKey(true).Key != ConsoleKey.Escape) ;
                Clear();
            }

            else
            {
                SetCursorPosition(4, 1);
                WriteLine("Unit not found");
                Thread.Sleep(2000);
                Clear();
            }
        }

        private static void AddQuadcopterMenyView()
        {
            try
            {
                SetCursorPosition(4, 1);
                Write("ID: ");
                string id = ReadLine();

                SetCursorPosition(4, 3);
                Write("Capacity (kg): ");
                string capacity = ReadLine();

                SetCursorPosition(4, 5);
                Write("Reach (km): ");
                string reach = ReadLine();

                SetCursorPosition(4, 7);
                Write("Transponder ID: ");
                string transponderId = ReadLine();

                SetCursorPosition(4, 11);
                Write("Is this correct? (Y)es (N)o");

                ConsoleKeyInfo addQuadcopter;

                bool invalidInput = true;
                do
                {
                    addQuadcopter = ReadKey(true);
                    invalidInput = !(addQuadcopter.Key == ConsoleKey.Y || addQuadcopter.Key == ConsoleKey.N);

                } while (invalidInput);


                Clear();

                Quadcopter quadcopter = new Quadcopter(id, capacity, reach, transponderId);



                if (addQuadcopter.Key == ConsoleKey.Y)
                {
                    if (deliveryUnitDictionary.ContainsKey(transponderId.ToUpper()) || deliveryUnitDictionary.ContainsKey(id.ToUpper()))
                    {
                        SetCursorPosition(4, 1);
                        WriteLine("Delivery unit already exist");
                        Thread.Sleep(2000);
                        Clear();

                        AddQuadcopterMenyView();
                    }
                    else
                    {
                        deliveryUnitDictionary.Add(quadcopter.Id.ToUpper(), quadcopter);
                        SetCursorPosition(4, 1);
                        WriteLine("Delivery unit registered");
                        Thread.Sleep(2000);
                        Clear();
                    }
                }

                if (addQuadcopter.Key == ConsoleKey.N)
                {
                    SetCursorPosition(4, 1);
                    WriteLine("Quadcopter not registered");
                    Thread.Sleep(2000);
                    Clear();

                    AddQuadcopterMenyView();
                }

            }
            catch 
            {
                WriteLine("Invalid input for Capacity or Reach, only take numeric values");
                Thread.Sleep(2000);
                Clear();
            }

        }

        private static void AddCarMenyView()
        {
            try
            {
                SetCursorPosition(4, 1);
                Write("ID: ");
                string id = ReadLine();

                SetCursorPosition(4, 3);
                Write("Capacity (kg): ");
                string capacity = ReadLine();

                SetCursorPosition(4, 5);
                Write("Reach (km): ");
                string reach = ReadLine();

                SetCursorPosition(4, 7);
                Write("Registration number: ");
                string registrationNumber = ReadLine();

                SetCursorPosition(4, 11);
                Write("Is this correct? (Y)es (N)o ");

                ConsoleKeyInfo addCar;

                bool invalidInput = true;
                do
                {
                    addCar = ReadKey(true);
                    invalidInput = !(addCar.Key == ConsoleKey.Y || addCar.Key == ConsoleKey.N);

                } while (invalidInput);

                Clear();

                Car car = new Car(id, capacity, reach, registrationNumber);

                if (addCar.Key == ConsoleKey.Y)
                {
                    if (deliveryUnitDictionary.ContainsKey(registrationNumber.ToUpper()) || deliveryUnitDictionary.ContainsKey(id.ToUpper()))
                    {
                        SetCursorPosition(4, 1);
                        WriteLine("Delivery unit already exist");
                        Thread.Sleep(2000);
                        Clear();

                        AddCarMenyView();
                    }
                    else
                    {
                        deliveryUnitDictionary.Add(car.Id.ToUpper(), car);
                        SetCursorPosition(4, 1);
                        WriteLine("Delivery unit registered");
                        Thread.Sleep(2000);
                        Clear();
                    }
                }

                else if (addCar.Key == ConsoleKey.N)
                {
                    SetCursorPosition(4, 1);
                    WriteLine("Delivery unit not registered");
                    Thread.Sleep(2000);
                    Clear();

                    AddCarMenyView();
                }
            }
            catch 
            {
                WriteLine("Invalid input for Capacity or Reach, only take numeric values");
                Thread.Sleep(2000);
                Clear();
            }

        }
    }
}
