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
    public partial class DeleteTraineeForm : Form
    {
        DBConnect connect = new DBConnect();
        public DeleteTraineeForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "", address = "", contact = "", iban = "", birthdate = "";
            char gender = ' ';

            if (connect.Search(nudID.Value.ToString(), ref name, ref address, ref contact, ref iban,
                ref gender, ref birthdate))
            {
                txtName.Text = name;
                txtAddress.Text = address;
                mtxtContact.Text = contact;
                mtxtIBAN.Text = iban;
                if (gender == 'F')
                {
                    rbFemale.Checked = true;
                } else if (gender == 'M')
                {
                    rbMale.Checked = true;
                } else if (gender == 'O')
                {
                    rbOther.Checked = true;
                }
                mtxtBirth.Text = DateTime.Parse(birthdate).ToString("dd-MM-yyyy");

                groupBox3.Enabled = false;
                btnDelete.Enabled = true;
            } 
            else
            {
                MessageBox.Show("Trainee not found.");
            }
        }

        private void DeleteTraineeForm_Load(object sender, EventArgs e)
        {
            // groupBox1.Enabled = false;
            txtName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            mtxtContact.ReadOnly = true;
            mtxtIBAN.ReadOnly = true;
            rbFemale.Enabled = false;
            rbMale.Enabled = false;
            rbOther.Enabled = false;
            mtxtBirth.ReadOnly = true;

            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnDelete.Enabled = false;
            Clear();
            nudID.Focus();
        }

        private void Clear()
        {
            nudID.Value = 0;
            txtName.Text = "";
            txtAddress.Text = "";
            mtxtContact.Clear();
            mtxtIBAN.Clear();
            rbFemale.Checked = false;
            rbMale.Checked = false;
            rbOther.Checked = false;
            mtxtBirth.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the entry with this ID: " + 
                nudID.Value.ToString() + "?", "Delete", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (connect.Delete(nudID.Value.ToString()))
                {
                    MessageBox.Show("Entry deleted.");
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error in entry deletion.");
                }
            }
        }
    }
}
