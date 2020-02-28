using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DeleteForm : Form
    {
        Task task;
        public DeleteForm()
        {
            InitializeComponent();
        }
        public DeleteForm(Task todayTask)
        {
            InitializeComponent();
            this.task = todayTask;
            foreach (SingleTask st in task.Tasks)
            {
                checkedListBox1.Items.Add(st.Task);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (SingleTask st in task.Tasks)
            {
                checkedListBox1.Items.Add(st.Task);
            }
        }

        private void dltBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                listBox1.Items.Add(checkedListBox1.CheckedItems[i]);
            }
            deleteSelected(listBox1);

            show();
            this.Dispose();
        }

        public void show()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                listBox1.Items.Add(checkedListBox1.CheckedItems[i]);
            }
        }
        public void deleteSelected(ListBox listBox1)
        {

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string dltItem = listBox1.Items[i].ToString();
                foreach (SingleTask st in task.Tasks)
                {
                    if (dltItem == st.Task.ToString())
                    {
                        task.Tasks.Remove(st);
                        break;
                    }
                }
            }
        }
    }
}
