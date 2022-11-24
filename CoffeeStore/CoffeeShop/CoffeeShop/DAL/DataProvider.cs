using CoffeeShop.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL
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
            connectionSTR = "Data Source=(LocalDb)\\t1;AttachDbFilename=C:\\dotNet2\\CoffeeStore\\CoffeeShop\\CoffeeShop\\bin\\Debug\\net6.0-windows\\CoffeeShopDB.mdf";
            using (var context = new DBContext(connectionSTR))
            {
                //"Data Source=(LocalDb)\\test1;AttachDbFilename=C:\\dotNet2\\CoffeeStore\\CoffeeShop\\CoffeeShop\\bin\\Debug\\net6.0-windows\\CoffeeShopDB.mdf;"
                var dt = new DataTable();
                var conn = context.Database.Connection;
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameter != null)
                        {
                            string[] listParameter = query.Split(' ');

                            int i = 0;

                            foreach (var item in listParameter)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.Add(new SqlParameter(item, parameter[i]));

                                    i++;
                                }
                            }
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    throw;
                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }
                data = dt;
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

            using (var context = new DBContext(connectionSTR))
            {
                int result = 0;
                var conn = context.Database.Connection;
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameter != null)
                        {
                            string[] listParameter = query.Split(' ');

                            int i = 0;

                            foreach (var item in listParameter)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.Add(new SqlParameter(item, parameter[i]));

                                    i++;
                                }
                            }
                        }

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    throw;
                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }
                data = result;
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

            using (var context = new DBContext(connectionSTR))
            {
                var dt = new object();
                var conn = context.Database.Connection;
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open) conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameter != null)
                        {
                            string[] listParameter = query.Split(' ');

                            int i = 0;

                            foreach (var item in listParameter)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.Add(new SqlParameter(item, parameter[i]));

                                    i++;
                                }
                            }
                        }

                        dt = cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    throw;
                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }
                data = dt;
            }

            return data;
        }
    }
}
