using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._2
{
     public class CRUD
    {
        public void CreateProduct()
        {
            //ket noi
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();
            //nhap du lieu
            Console.WriteLine("enter product name");
            string proName = Console.ReadLine();
            Console.WriteLine("enter product desc");
            string proDesc = Console.ReadLine();
            Console.WriteLine("enter product price");
            decimal price = decimal.Parse(Console.ReadLine());
            //cau lenh truy vấn
            string query = "insert into product(proName,proDesc,price) values(@proName,@proDesc,@price)";
            //mở kết nối
            connection.Open();
            //tao sqlcommand de thuc hien cau lenh truy van
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            //truyen tham so truc tiep bang addwithvalue
            sqlCommand.Parameters.AddWithValue("@proName", proName);

            sqlCommand.Parameters.AddWithValue("@proDesc", proDesc);

            sqlCommand.Parameters.AddWithValue("@price", price);
            //thi hanh cau lenh bang executenonquery
            var count = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"{count} Add successful product");
            connection.Close();
        }


        //sua ban ghi
        public void EditData()
        {

            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();

            Console.WriteLine("enter product id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter product name");
            string proName = Console.ReadLine();
            Console.WriteLine("enter product desc");
            string proDesc = Console.ReadLine();
            Console.WriteLine("enter product price");
            decimal price = decimal.Parse(Console.ReadLine());
            connection.Open();
            string query = "update product set proName=@proName,proDesc=@proDesc,price=@price where id=@id";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlCommand.Parameters.AddWithValue("@proName", proName);

            sqlCommand.Parameters.AddWithValue("@proDesc", proDesc);

            sqlCommand.Parameters.AddWithValue("@price", price);
            int row = sqlCommand.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("update successful product");
        }
        //xoa ban ghi
        public void DeleteProduct()
        {
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();
            Console.WriteLine("enter product id");
            int id = int.Parse(Console.ReadLine());
            string query = "delete product where id=@id";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            int row = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Delete successful product");
            connection.Close();
        }
        //tim product theo id
        public void SearchById()
        {
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();
            Console.WriteLine("enter product id");
            int id = int.Parse(Console.ReadLine());
            string query = "select*from product where id=@id";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Product Name:" + reader.GetString(1) + "; the description: " + reader.GetString(2) +
                   "; price:" + reader.GetDecimal(3));
            }
            connection.Close();
        }
        //tim product theo ten
        public void SearchByName()
        {
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();
            Console.WriteLine("enter product proName: ");
            string proName = Console.ReadLine();
            string query = "select*from product where proName like @proName";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@proName", proName);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Product Name:" + reader.GetString(1) + "; the description: " + reader.GetString(2) +
                  "; price:" + reader.GetDecimal(3));
            }
            connection.Close();
        }
        //lay ra danh sach product tu collections
        public void GetAllProduct()
        {
            ConnectionDb connectionDb = new ConnectionDb();
            SqlConnection connection = connectionDb.GetConnection();
            string query = "select*from product";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            ArrayList products = new ArrayList();

            foreach (Product product in reader)
            {
                products.Add(product);
                Console.WriteLine("Product Name:" + reader.GetString(1) + "; the description: " + reader.GetString(2) +
                  "; price:" + reader.GetDecimal(3));
            }

            //    while ( reader.Read())
            //    {
            //       Console.WriteLine("Product Name:" + reader.GetString(1) + "; the description: " + reader.GetString(2) +
            //         "; price:" + reader.GetDecimal(3));
            //   }
            connection.Close();

        }
    }
}

