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
    public partial class ListTraineeForm : Form
    {
        DBConnect connect = new DBConnect();
        public ListTraineeForm()
        {
            InitializeComponent();
        }

        private void ListTraineeForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns.Add("codID", "ID");
            dataGridView1.Columns.Add("name", "Nome");
            dataGridView1.Columns.Add("iban", "IBAN");
            dataGridView1.Columns.Add("birth", "Data Nasc.");
            dataGridView1.Columns.Add("gender", "Género");

            connect.FillTraineeDataGridFilter(ref dataGridView1, "", ' ');
            lblEntries.Text = "No. of entries: " + dataGridView1.Rows.Count;
            rbAll.Checked = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            connect.FillTraineeDataGridFilter(ref dataGridView1, "", ' ');
            lblEntries.Text = "No. of entries: " + dataGridView1.Rows.Count;
            rbAll.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtName.Text = General.RemoveSpaces(txtName.Text);
            connect.FillTraineeDataGridFilter(ref dataGridView1, txtName.Text, Gender());
        }

        private char Gender()
        {
            char gender = 'T';

            if (rbFemale.Checked)
            {
                gender = 'F';
            }
            else if (rbMale.Checked)
            {
                gender = 'M';
            }
            else if (rbOther.Checked)
            {
                gender = 'O';
            }

            return gender;
        }
    }
}
