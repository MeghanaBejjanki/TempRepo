using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SQLInterface:IDisposable
    {
        public DateTime Date;
        public List<SingleTask> Tasks;
        //public Task task;
        public SQLInterface(DateTime Date)
        {
            this.Date = Date;
            using (MySql DatabaseHandler = new MySql())
            {
                Tasks = DatabaseHandler.Select(Date);
            }
        }
        public void AddTask(string Task, TimeSpan ScheduledTime)
        {
            using (MySql DatabaseHandler = new MySql())
            {
                DatabaseHandler.Insert(Date, Task, ScheduledTime);
            }
        }
        public void DeleteTask(int Index)
        {
            using (MySql DatabaseHandler = new MySql())
            {

                DatabaseHandler.Delete(Date, Tasks[Index - 1].ScheduledTime);
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
