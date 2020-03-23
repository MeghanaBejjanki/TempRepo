using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    partial class MySql : IDisposable
    {
        private MySqlConnection Connection;
        private string Server;
        private string Database;
        private string User;
        private string Password;
        public MySql()
        {
            Initialize();
        }
        private string GetConnectionString()
        {
            return "SERVER=" + Server + ";"
                + "DATABASE=" + Database + ";"
                + "UID=" + User + ";"
                + "PASSWORD=" + Password + ";";
        }
        private void Initialize()
        {
            Server = "localhost";
            Database = "testdb";
            User = "root";
            Password = "password1";
            Connection = new MySqlConnection(GetConnectionString());
        }
        private bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException EX)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (EX.Number)
                {
                    case 0:
                        Debug.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Debug.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
        
        public bool IsRowsPresent(string Tname)
        {
            int NORows = CountRows(Tname);
            if (NORows != 0)
            {
                return true;
            }
            else
                return false;

        }
        
        
        public string GetTableName(DateTime date)
        {

            string Tname = "table" + date.Day.ToString() + date.Month.ToString() + date.Year.ToString();
            return Tname;
        }
        public void CreateTable(DateTime date)
        {
            string Tname = GetTableName(date);
            string Command = "Create table " + Tname + " (task varchar(100),ScheduledTime time(0));";
            MySqlCommand Cmd = new MySqlCommand(Command, Connection);
            Cmd.ExecuteNonQuery();

        }
        public bool IstablePresent(string Tname)
        {
            string Command = "select count(*) from " + Tname + ";";


            try
            {
                MySqlCommand Cmd = new MySqlCommand(Command, Connection);
                Cmd.ExecuteScalar();
                Debug.WriteLine("till");

            }
            catch (MySqlException)
            {
                return false;
            }
            return true;

        }
        public int CountRows(string Tname)
        {
            int Count = 0;
            string Command = "Select count(*) from " + Tname;
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(Command, Connection);
                    Count = cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
                catch (Exception)
                {
                    this.CloseConnection();
                }
                this.CloseConnection();
            }
            return Count;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
