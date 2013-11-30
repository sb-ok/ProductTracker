using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductTracker.ProductStructure
{
    class DbProductStructure : Connection
    {
        // Возвращает список корневых типов изделий
        public List<string> RootNodesList()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var res = new List<string>();
                const string commandText = "SELECT typeName FROM productType WHERE rootType = 1";
                var command = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return res;
            }
        }

        // Возвращает список не корневых типов изделий
        public List<string> ChildNodesList()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var res = new List<string>();
                const string commandText = "SELECT typeName FROM productType WHERE rootType = 0";
                var command = new SqlCommand(commandText, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.Add(reader.GetString(0));
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return res;
            }
        } 

        // Создает новое изделие в таблице Product
        public void AddNewProduct(string name)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "INSERT INTO product VALUES (@type, @name, 1)";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@type", SqlDbType.VarChar);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@type"].Value = TakeTypeIdFromName("Изделие");
                command.Parameters["@name"].Value = name;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Заносит изделие в таблицу productTree
        public void AddProductInTree(string name)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "INSERT INTO productTree VALUES (@productId, null, null, null, null)";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@productId", SqlDbType.Int);
                command.Parameters["@productId"].Value = TakeProductId(name);
                

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Возвращает ID типа продукции по имени
        public int TakeTypeIdFromName(string typeName)
        {
            int id = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "SELECT typeId FROM productType WHERE typeName = @typeName";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@typeName", SqlDbType.VarChar);
                command.Parameters["@typeName"].Value = typeName;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return id;
        }

        // Возвращает ID изделия по названию
        public int TakeProductId(string name)
        {
            int id = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "SELECT id FROM product WHERE name = @name";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = name;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return id;
        }
    }
}
