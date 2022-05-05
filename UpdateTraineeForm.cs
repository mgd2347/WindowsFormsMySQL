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
    public partial class UpdateTraineeForm : Form
    {
        DBConnect connect = new DBConnect();

        public UpdateTraineeForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the entry with this ID: " +
                nudID.Value.ToString() + "?", "Update", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (connect.Update(nudID.Value.ToString(), txtName.Text, txtAddress.Text, 
                    mtxtContact.Text, mtxtIBAN.Text, Gender(),
                    DateTime.Parse(mtxtBirth.Text).ToString("yyyy-MM-dd")))
                {
                    MessageBox.Show("Entry updated.");
                    btnCancel_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error in entry update.");
                }
            }
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
                }
                else if (gender == 'M')
                {
                    rbMale.Checked = true;
                }
                else if (gender == 'O')
                {
                    rbOther.Checked = true;
                }
                mtxtBirth.Text = DateTime.Parse(birthdate).ToString("dd-MM-yyyy");

                groupBox3.Enabled = false;

                txtName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                mtxtContact.ReadOnly = false;
                mtxtIBAN.ReadOnly = false;
                rbFemale.Enabled = true;
                rbMale.Enabled = true;
                rbOther.Enabled = true;
                mtxtBirth.ReadOnly = false;

                btnUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show("Trainee not found.");
            }
        }

        private void UpdateTraineeForm_Load(object sender, EventArgs e)
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

            btnUpdate.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnUpdate.Enabled = false;
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
