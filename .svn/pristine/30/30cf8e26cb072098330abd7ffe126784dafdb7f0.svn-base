using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductTracker.Properties;

namespace ProductTracker
{
    public class User : Connection
    {
        int UserId { get; set; }
        public string Login { get; set; }
        string Psw { get; set; }
        public string Fio { get; set; }
        int RoleId { get; set; }

        // Проверка на существование введенного логина
        public bool LoginAvailable(string login)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var res = false;
                const string commandText = "SELECT login FROM Users WHERE login = @login";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@login", SqlDbType.VarChar);
                command.Parameters["@login"].Value = login;

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

        // Регистрация нового пользователя
        public void CreateNew(string login, string psw)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "INSERT INTO Users VALUES (@login, 1, 1, 1, @psw)";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@login", SqlDbType.VarChar);
                command.Parameters.Add("@psw", SqlDbType.VarChar);
                command.Parameters["@login"].Value = login;
                command.Parameters["@psw"].Value = psw;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(Resources.user_created, Resources.successful_operation_msg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Проверяет данные пользователя при авторизации (пара логин-пароль)
        public bool Autorisation(string pass)
        {
            var result = false;
            using (var connection = new SqlConnection(ConnectionString))
            {
                const string commandText = "SELECT * FROM Users WHERE login = @login";
                var command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@login", SqlDbType.VarChar);
                command.Parameters["@login"].Value = Login;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (pass == reader.GetString(2))
                            {
                                result = true;
                                Fio = reader.GetString(3);
                                UserId = reader.GetInt32(0);
                                RoleId = reader.GetInt32(4);
                                Psw = pass;
                            }
                            else
                            {
                                MessageBox.Show(Resources.User_Autorisation_Логин_и_пароль_неверны);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.notFoundLogin);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        // Возвращает ID роли пользователя
        public int UserInRole()
        {
            return RoleId;
        }
    }
}
