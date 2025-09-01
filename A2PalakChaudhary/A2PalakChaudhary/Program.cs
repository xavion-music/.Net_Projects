using System;
using System.Collections.Generic;
using System.Linq;

namespace A2PalakChaudhary
{
    internal class Program
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        static void Main(string[] args)
        {
            AddVehicles();
            Menu();
        }

        static void AddVehicles()
        {
            // cars all in sedan category
            vehicles.Add(new Car { ID = 1, Name = "2025 Mercedes-Benz CLA", RentalPrice = 120, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = false });
            vehicles.Add(new Car { ID = 2, Name = "2025 Honda Accord", RentalPrice = 85, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = false });
            vehicles.Add(new Car { ID = 3, Name = "2025 Toyota Camry (Hybrid)", RentalPrice = 90, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = false });
            vehicles.Add(new Car { ID = 4, Name = "2025 Cadillac CT5-V", RentalPrice = 150, Category = Category.Sedan, Type = VehicleType.Exotic, IsReserved = false });
            vehicles.Add(new Car { ID = 5, Name = "2025 Cadillac Celestiq", RentalPrice = 300, Category = Category.Sedan, Type = VehicleType.Exotic, IsReserved = true });
            vehicles.Add(new Car { ID = 6, Name = "2025 Lucid Air Sapphire", RentalPrice = 320, Category = Category.Sedan, Type = VehicleType.Exotic, IsReserved = false });
            vehicles.Add(new Car { ID = 7, Name = "2025 Kia K5", RentalPrice = 80, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = true });
            vehicles.Add(new Car { ID = 8, Name = "2025 Lexus ES", RentalPrice = 110, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = false });
            vehicles.Add(new Car { ID = 9, Name = "2026 Honda 0 Saloon", RentalPrice = 95, Category = Category.Sedan, Type = VehicleType.Standard, IsReserved = false });

            // bike cruser, sports,etc
            vehicles.Add(new Motorbike { ID = 10, Name = "2025 Indian Scout 101", RentalPrice = 100, Category = Category.Cruiser, Type = VehicleType.Bike, IsReserved = false });
            vehicles.Add(new Motorbike { ID = 11, Name = "2025 Indian Sport Chief", RentalPrice = 105, Category = Category.Cruiser, Type = VehicleType.Bike, IsReserved = true });
            vehicles.Add(new Motorbike { ID = 12, Name = "2025 Harley-Davidson Street Bob 114", RentalPrice = 115, Category = Category.Cruiser, Type = VehicleType.Bike, IsReserved = false });
            vehicles.Add(new Motorbike { ID = 13, Name = "2025 Harley-Davidson Breakout 117", RentalPrice = 130, Category = Category.Cruiser, Type = VehicleType.Bike, IsReserved = false });
            vehicles.Add(new Motorbike { ID = 14, Name = "2025 Buell Super Cruiser", RentalPrice = 125, Category = Category.Cruiser, Type = VehicleType.Bike, IsReserved = true });
            vehicles.Add(new Motorbike { ID = 15, Name = "2025 Harley-Davidson Pan America 1250 ST", RentalPrice = 140, Category = Category.Sports, Type = VehicleType.Bike, IsReserved = false });
        }

        static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("ASSIGNMENT-2 by PALAK CHAUDHARY");
                Console.WriteLine("\n+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");
                Console.WriteLine();
                Console.WriteLine("  1 - View all vehicles");
                Console.WriteLine("  2 - View available vehicles");
                Console.WriteLine("  3 - View reserved vehicles");
                Console.WriteLine("  4 - Reserve a vehicle");
                Console.WriteLine("  5 - Cancel reservation");
                Console.WriteLine("  6 - Exit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        ShowAvailable();
                        break;
                    case 3:
                        ShowReserved();
                        break;
                    case 4:
                        ReserveVehicle();
                        break;
                    case 5:
                        CancelReservation();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (choice != 6);
        }

        static void ShowAll()
        {
            Console.WriteLine("ID  Name                                      Price     Category  Type     Reserved");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var v in vehicles)
            {
                v.Display();
            }
        }

        static void ShowAvailable()
        {
            Console.WriteLine("\nAvailable Vehicles:\n");
            foreach (var v in vehicles.Where(x => !x.IsReserved))
            {
                v.Display();
            }
        }

        static void ShowReserved()
        {
            Console.WriteLine("\nReserved Vehicles:\n");
            foreach (var v in vehicles.Where(x => x.IsReserved))
            {
                v.Display();
            }
        }

        static void ReserveVehicle()
        {
            Console.Write("Enter ID to reserve: ");
            int.TryParse(Console.ReadLine(), out int id);
            var v = vehicles.FirstOrDefault(x => x.ID == id);
            if (v != null && !v.IsReserved)
            {
                v.IsReserved = true;
                Console.WriteLine("Reserved successfully.");
            }
            else
            {
                Console.WriteLine("Not found or already reserved.");
            }
        }

        static void CancelReservation()
        {
            Console.Write("Enter ID to cancel: ");
            int.TryParse(Console.ReadLine(), out int id);
            var v = vehicles.FirstOrDefault(x => x.ID == id);
            if (v != null && v.IsReserved)
            {
                v.IsReserved = false;
                Console.WriteLine("Reservation cancelled.");
            }
            else
            {
                Console.WriteLine("Not found or not reserved.");
            }
        }
    }
}
