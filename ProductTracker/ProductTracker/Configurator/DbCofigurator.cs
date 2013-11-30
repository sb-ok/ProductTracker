using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProductTracker.Properties;

namespace ProductTracker
{
    class DbCofigurator : Connection
    {
        // Возвращает список существующих в базе типов объектов
        public List<string> TypeList()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<string> res = new List<string>();
                string commandText = "SELECT typeName FROM productType";
                SqlCommand command = new SqlCommand(commandText, connection);

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

        // Возвращает список типов объектов, которые могут быть корневыми

        public List<string> RootTypeList()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<string> res = new List<string>();
                string commandText = "SELECT typeName FROM productType WHERE rootType = 1";
                SqlCommand command = new SqlCommand(commandText, connection);

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

        // Возвращает список существующих в базе атрибутов
        public List<string> ProductAttributeList()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                List<string> res = new List<string>();
                string commandText = "SELECT name FROM mtAttribute";
                SqlCommand command = new SqlCommand(commandText, connection);

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

        // Переименовывает тип объекта
        public void RenameProductType(string newName, string oldName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "UPDATE productType SET typeName = @newName WHERE typeName = @oldName";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@newName", SqlDbType.VarChar);
                command.Parameters.Add("@oldName", SqlDbType.VarChar);
                command.Parameters["@newName"].Value = newName;
                command.Parameters["@oldName"].Value = oldName;

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

        // Переименовывает атрибут объекта
        public void RenameProductAttribute(string newName, string oldName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "UPDATE mtAttribute SET name = @newName WHERE name = @oldName";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@newName", SqlDbType.VarChar);
                command.Parameters.Add("@oldName", SqlDbType.VarChar);
                command.Parameters["@newName"].Value = newName;
                command.Parameters["@oldName"].Value = oldName;

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

        // Удаляет тип объекта
        public void RemoveProductType(string typeName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM dbo.productType WHERE typeName = @typeName";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@typeName", SqlDbType.VarChar);
                command.Parameters["@typeName"].Value = typeName;

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

        // Удаляет атрибут объекта
        public void RemoveProductAttribute(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "DELETE FROM mtAttribute WHERE name = @name";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@name", SqlDbType.VarChar);
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

        // Создает новый тип объекта
        public void CreateProductType(string typeName, int rootType)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "INSERT INTO productType VALUES (@typeName, @rootType)";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@typeName", SqlDbType.VarChar);
                command.Parameters.Add("@rootType", SqlDbType.Int);
                command.Parameters["@typeName"].Value = typeName;
                command.Parameters["@rootType"].Value = rootType;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(Resources.AddProdType_Add_succes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Создает новый атрибут конфигуратора
        public void CreateAttribute(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "INSERT INTO mtAttribute VALUES (@name)";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = name;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(Resources.AddProdType_Add_succes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Проверяет наличие типа объектов в базе данных
        public bool ProductTypeThere(string typeName)
        {
            bool res = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "SELECT typeName FROM productType WHERE typeName = @typeName";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@typeName", SqlDbType.VarChar);
                command.Parameters["@typeName"].Value = typeName;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        res = true;
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

        // Проверяет наличие типа атрибута в базе данных
        public bool ProductAttributeThere(string name)
        {
            bool res = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string commandText = "SELECT name FROM mtAttribute Type WHERE name = @name";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@name", SqlDbType.VarChar);
                command.Parameters["@name"].Value = name;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        res = true;
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

    }
}
