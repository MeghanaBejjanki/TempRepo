using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Task
    {
        public DateTime Date;
        
        public List<SingleTask> Tasks;
        public string path;
        FileStream myFile;
        public string fileName;
        string timeStamp;
        public Task()
        {
            Date = DateTime.Now;
            
            Tasks = new List<SingleTask>();
        }
        public SingleTask AddTask(string task)
        {
            SingleTask st = new SingleTask(DateTime.Now.TimeOfDay, task);
                this.Tasks.Add(st);
                return st;

        }
        public string createNewFile(DateTime date)
        {
            timeStamp = date.ToString("MM-dd-yyyy") + " " + "TasksList";
            this.path= @"C:\Users\MB185471\Downloads\WindowsFormsApp1-20200224T052829Z-001\WindowsFormsApp1\" + timeStamp + ".txt";
            myFile = File.Open(this.path,FileMode.OpenOrCreate);
            fileName = myFile.Name;
            myFile.Dispose();
            
            return this.path;
        }

        
    }
}
