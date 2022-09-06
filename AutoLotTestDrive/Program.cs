using System;
using System.Data.Entity;
using AutoLotDAL.EF;
using System.Text;
using AutoLotDAL.Models;
using AutoLotDAL.Models.Base;
using AutoLotDAL.Repos;
using static System.Console;
using System.Collections.Generic;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyDataInitializer());

            StringBuilder strCust = new StringBuilder("");
            strCust.AppendLine("\n");

            var custs = new List<Customer>
            {
                new Customer {FirstName = "Djulia", LastName = "Roberts"},
                new Customer {FirstName = "Silvestr", LastName = "Stalone"},
                new Customer {FirstName = "Bruce", LastName = "Lee"},
                new Customer {FirstName = "Stive", LastName = "Djobs"},
                new Customer {FirstName = "Павел", LastName = "Павлов"},
            };

                var cust = new Customer { FirstName = "Melik", LastName = "Gibsovich" };
                var custToDelete = new Customer { FirstName = "Melik", LastName = "Gibsovich" };
                //int CustomerId = 4;
                //int[] timeStamp = { 0x0000000000001777 };
                int carId = 1;
            //RemoveRecordByCusts(CustomerId, timeStamp);
            //RemoveRecordByCust(custToDelete);
            AddNewCust(cust);           
            AddNewCusts(custs);
            UpdateRecordInv(carId);


            WriteLine("***** Формирование и заполнение таблиц БД из классов модели ADO.NET EF Code First *****\n");
            using (var context = new AutoLotEntities())
            {
                try
                {
                    foreach (Inventory c in context.Cars)
                    {
                        WriteLine(c);
                        ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.ToString());
                    ReadLine();
                    return;
                }
            }

            /*WriteLine("***** Вывод списка авто по имени владельца *****\n");
            using (var repo = new InventoryRepo())
            {
                try
                {
                    foreach (Inventory c in repo.GetAll())
                    {
                        Title = "Fun from Blablatov";
                        ConsoleColor bgndColor = BackgroundColor;
                        BackgroundColor = ConsoleColor.Yellow;
                        ConsoleColor prevColor = ForegroundColor;
                        ForegroundColor = ConsoleColor.Blue;
                        //ForegroundColor = prevColor;
                        WriteLine(c);
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.ToString());
                    ReadLine();
                    return;
                }
                //TestConcurrency();
            }  */  
            ReadLine();  
        }

        //Добавление записей в БД
        private static void AddNewRecord(Inventory car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }
        private static void AddNewCust(Customer cust)
        {
            using (var repo = new CustomerRepo())
            {
                repo.Add(cust);
            }
        }
        private static void AddNewCusts(List<Customer> custs)
        {
            using (var repo = new CustomerRepo())
            {
                repo.AddRange(custs);
            }
        }

        //Редактирование записей в БД
        private static void UpdateRecordInv(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                //Извлечь запись, изменить ее и сохранить 
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }

        //Удаление записей в БД
        private static void RemoveRecordByCust(Customer custToDelete)
        {
            using (var repo = new CustomerRepo())
            {
                repo.Delete(custToDelete);
            }
        }
        private static void RemoveRecordByCusts(int CustomerId, int[] timeStamp)
        {
            using (var repo = new CustomerRepo())
            {
                repo.Delete(CustomerId, timeStamp);
            }
        }
    }
}
