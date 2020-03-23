
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    partial class MySql
    {
        public List<SingleTask> Select(DateTime date)
        {
            string Tname = GetTableName(date);
            List<SingleTask> Columns = new List<SingleTask>();
            if (this.OpenConnection() == true)
            {

                string Command = "select * from " + Tname + ";";

                if (IstablePresent(Tname))
                {

                    MySqlCommand Cmd = new MySqlCommand(Command, Connection);

                    MySqlDataReader Reader = Cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Columns.Add(new SingleTask((string)Reader["task"], (TimeSpan)Reader["ScheduledTime"]));
                    }
                    this.CloseConnection();
                    return Columns;
                }

                else
                {
                    this.CloseConnection();
                    return Columns;

                }
            }
            return null;
        }
    }
}