using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMySQL
{
    public partial class Form1 : Form
    {
        DBConnect connect = new DBConnect();
        InsertTraineeForm insertTraineeForm = new InsertTraineeForm();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total no. of trainees: " + connect.Count());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Insert();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connect.Insert2())
            {
                MessageBox.Show("Successfully inserted!");
            }
            else
            {
                MessageBox.Show("Error in insertion!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (connect.Update("12", "Rui Bento"))
            {
                MessageBox.Show("Successfully updated!");
            }
            else
            {
                MessageBox.Show("Error in update!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult reply;
            reply = MessageBox.Show("Are you sure you want to delete the entry?", "Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (reply == DialogResult.Yes)
            {
                if (connect.Delete("11"))
                {
                    MessageBox.Show("Successfully deleted!");
                }
                else
                {
                    MessageBox.Show("Error in deletion!");
                }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (insertTraineeForm.IsDisposed)
            {
                insertTraineeForm = new InsertTraineeForm();
            }
            insertTraineeForm.Show();
            insertTraineeForm.Activate();
        }
    }
}
