// See https://aka.ms/new-console-template for more information
using lab5._2;
using System;
using System.Data.SqlClient;

public class Program
{
    public static void Main(string[] args)
    {
        CRUD crud = new CRUD();
        while (true)
        {
            Console.WriteLine("====Action====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Edit Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. View all Product");
            Console.WriteLine("5. Search product by Id ");
            Console.WriteLine("6. Search product by Name ");
            Console.WriteLine("7. End ");
            Console.WriteLine("Choose 1-7");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    crud.CreateProduct();
                    break;
                case 2:
                    crud.EditData();
                    break;
                case 3:
                    crud.DeleteProduct();
                    break;
                case 4:
                    crud.GetAllProduct();
                    break;
                case 5:
                    crud.SearchById();
                    break;
                case 6:
                    crud.SearchByName();
                    break;
                case 7:
                    Console.WriteLine("==Exit program==");
                    break;

            }


        }

    }
}