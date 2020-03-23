

using MySql.Data.MySqlClient;
using System;

namespace WindowsFormsApp1
{
    partial class MySql
    {
        public void Insert(DateTime date,string Text,TimeSpan Time)
        {
            string Tname = GetTableName(date);

            string Command = "insert into " + Tname + " values('" + Text + "','" + Time.ToString(@"hh\:mm\:ss") + "')";
            if (this.OpenConnection() == true)
            {

                if (!IstablePresent(GetTableName(date)))
                {
                    CreateTable(date);
                }
                MySqlCommand Cmd = new MySqlCommand(Command, Connection);
                Cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void Delete(DateTime date,TimeSpan time)
        {
            string Tname = GetTableName(date);

            if (this.OpenConnection() == true)
            {

                string Command = "delete from " + Tname + " where Scheduledtime='" + time.ToString(@"hh\:mm\:ss") + "';";
                if (IsRowsPresent(Tname))
                {
                    MySqlCommand Cmd = new MySqlCommand(Command, Connection);
                    this.OpenConnection();
                    Cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            else
            {
                this.CloseConnection();
            }
        }
    }
}