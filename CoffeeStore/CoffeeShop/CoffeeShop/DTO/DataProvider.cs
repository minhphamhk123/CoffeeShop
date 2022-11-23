﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Database;

namespace CoffeeShop.DTO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider(); return instance;
            }
            private set { instance = value; }
        }

        private DataProvider() { }

        //private string connectionSTR = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
        private string connectionSTR = DBConfig.GetConnectionString();

        /// <summary>
        /// Hàm thực hiện lệnh truyền vào và trả về bảng dữ liệu
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');

                    int i = 0;

                    foreach (var item in listParameter)
                    {
                        if (item.Contains('@'))
                        {

                            command.Parameters.AddWithValue(item, parameter[i]);

                            i++;
                        }
                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }


        /// <summary>
        /// Hàm trả ra số dòng thành công, vd các lệnh: Update , Insert, Delete, ...
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                // Hàm trả ra số dòng thành công, vd các lệnh: Update , Insert, Delete, ...

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');

                    int i = 0;

                    foreach (var item in listParameter)
                    {
                        if (item.Contains('@'))
                        {

                            command.Parameters.AddWithValue(item, parameter[i]);

                            i++;
                        }
                    }
                }


                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }


        /// <summary>
        /// Hàm thực hiện đếm số lượng (trả về ô đầu tiên của kết quả) , vd: SELECT Count(*) FROM ABC
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            // Hàm thực hiện đếm số lượng (trả về ô đầu tiên của kết quả) , vd: SELECT Count(*) FROM ABC

            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);


                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');

                    int i = 0;

                    foreach (var item in listParameter)
                    {
                        if (item.Contains('@'))
                        {

                            command.Parameters.AddWithValue(item, parameter[i]);

                            i++;
                        }
                    }
                }


                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
}
