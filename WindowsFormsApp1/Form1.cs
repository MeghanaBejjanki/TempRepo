using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Todo todo;
        public string taskStr;
        SingleTask eachtask;
        
        public Form1()
        {
            InitializeComponent();
            todo = new Todo();

            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            TaskListArea.Clear();
            //TaskListArea.Text= File.ReadAllText(todo.TodayTasks.path);
            displayTaskInTextArea(todo.TodayTasks);
        }
        private void YesterdaysScheduleButton_Click(object sender, EventArgs e)
        {
            //todo.ChangeDay();
            TaskListArea.Clear();
            DateLabel.Text = DateTime.Now.AddDays(-1).ToShortDateString();
            DayLabel.Text = DateTime.Now.Day.ToString();
            //TaskListArea.Text = File.ReadAllText(todo.YesterdayTasks.path);
            displayTaskInTextArea(todo.YesterdayTasks);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //displayTaskInTextArea(todo.TodayTasks);
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            Form2 popup = new Form2();
            popup.ShowDialog();
            eachtask = todo.TodayTasks.AddTask(popup.EnteredTask);
            //TaskListArea.AppendText("\t"+(todo.TodayTasks.Tasks.Count).ToString());
            TaskListArea.AppendText(eachtask.Time.ToString().Substring(0, 8).PadLeft(9 + 15) + eachtask.Task.PadLeft(eachtask.Task.Length + 25) + "\n");
            saveToFile(todo.TodayTasks, todo.TodayTasks.path);
            //displayTaskInTextArea(todo.TodayTasks);
        }
        private void displayTaskInTextArea(Task task)
        {
            DateLabel.Text = task.Date.ToShortDateString();
            DayLabel.Text  =  task.Date.DayOfWeek.ToString();
            
            if (task.Tasks.Count() == 0)
            {
                TaskListArea.AppendText("Hurray You don't have any task!!");
            }
            
            //TaskListArea.Clear();
            //TaskListArea.AppendText(File.ReadAllText(task.path));
            TaskListArea.Text = File.ReadAllText(task.path);

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //DateLabel.ResetText();
            //DayLabel.ResetText();
            TaskListArea.Clear();
            todo.ChangeDay();
            DateLabel.Text = DateTime.Now.AddDays(1).ToShortDateString();
            //DayLabel.Text = DateTime.Now.DayOfWeek.ToString();
            DayLabel.Text = DateTime.Now.AddDays(1).DayOfWeek.ToString();
            //displayTaskInTextArea(todo.TodayTasks);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            DeleteForm DeleteTask = new DeleteForm(todo.TodayTasks);
            DeleteTask.ShowDialog();
            
            /*if(DeleteTask.IndexofTask>0 && DeleteTask.IndexofTask <= todo.TodayTasks.Tasks.Count)
            {
                todo.TodayTasks.Tasks.RemoveAt(DeleteTask.IndexofTask - 1);
                saveToFile(todo.TodayTasks, todo.TodayTasks.path);
                displayTaskInTextArea(todo.TodayTasks);
                //TaskListArea.AppendText((todo.TodayTasks.Tasks.Count).ToString());
            }
            TaskListArea.Clear();
            */
            saveToFile(todo.TodayTasks,todo.TodayTasks.path);
            displayTaskInTextArea(todo.TodayTasks);


        }

        private void TaskListArea_TextChanged(object sender, EventArgs e)
        {   

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            saveToFile(todo.TodayTasks,todo.TodayTasks.path);
        }

        private void saveToFile(Task task, string path)
        {
            
            //File.WriteAllText(task.path, string.Empty);
            

            File.WriteAllText(path, TaskListArea.Text);
            

        }

        private void DayLabel_Click(object sender, EventArgs e)
        {

        }
    }

}
