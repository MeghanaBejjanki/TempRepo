using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Todo
    {
        public Task TodayTasks,YesterdayTasks;

        
        public Todo()
        {
            TodayTasks = new Task();
            YesterdayTasks = new Task();
            TodayTasks.path = TodayTasks.createNewFile(TodayTasks.Date);
            YesterdayTasks.Date = DateTime.Now.AddDays(-1);
            YesterdayTasks.path = YesterdayTasks.createNewFile(YesterdayTasks.Date);
        } 
        public void ChangeDay()
        {
            YesterdayTasks = TodayTasks;
            //YesterdayTasks.Date = YesterdayTasks.Date.AddDays(1);
            //YesterdayTasks.path = TodayTasks.path;
            //YesterdayTasks.Tasks = new List<SingleTask>(TodayTasks.Tasks);
            TodayTasks.Date = TodayTasks.Date.AddDays(1);
            TodayTasks.path = TodayTasks.createNewFile(TodayTasks.Date);
            //File.Copy(TodayTasks.fileName, YesterdayTasks.fileName,true);
            //Console.Write(YesterdayTasks.Tasks.Count);
            TodayTasks.Tasks.Clear();
            
        }

        


    }
}