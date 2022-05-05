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
    public partial class InsertTraineeForm : Form
    {
        DBConnect connect = new DBConnect();
        public InsertTraineeForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InsertTraineeForm_Load(object sender, EventArgs e)
        {
            nudID.Value = connect.MaxID() + 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (connect.Insert(nudID.Value.ToString(), txtName.Text, txtAddress.Text, 
                    mtxtContact.Text, mtxtIBAN.Text, Gender(), 
                    DateTime.Parse(mtxtBirth.Text).ToString("yyyy-MM-dd")))
                {
                    MessageBox.Show("Successfully inserted!");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error in one of the fields!");
                }             
            }
        }

        private void Clear()
        {
            nudID.Value = connect.MaxID() + 1;
            txtName.Text = "";
            txtAddress.Text = "";
            mtxtContact.Clear();
            mtxtIBAN.Clear();
            rbFemale.Checked = false;
            rbMale.Checked = false;
            rbOther.Checked = false;
            mtxtBirth.Text = "";
        }

        bool Check()
        {
            if (nudID.Value < 1)
            {
                MessageBox.Show("Error in ID field!");
                nudID.Focus();
                return false;
            }

            txtName.Text = General.RemoveSpaces(txtName.Text);
            if (txtName.Text.Length < 3)
            {
                MessageBox.Show("Error in NAME field!");
                txtName.Focus();
                return false;
            }

            txtAddress.Text = General.RemoveSpaces(txtAddress.Text);
            if (txtAddress.Text.Length < 3)
            {
                MessageBox.Show("Error in ADDRESS field!");
                txtAddress.Focus();
                return false;
            }

            if (mtxtContact.Text.Length < 9)
            {
                MessageBox.Show("Error in CONTACT field!");
                mtxtContact.Focus();
                return false;
            }
            
            if (mtxtIBAN.Text.Length != 25)
            {
                MessageBox.Show("Error in IBAN field!");
                mtxtIBAN.Focus();
                return false;
            }

            if(Gender() == 'T')
            {
                MessageBox.Show("Error in GENDER field!");
                rbFemale.Focus();
                return false;
            }

            if (mtxtBirth.Text.Length != 10 || (General.CeckDate(mtxtBirth.Text) == false))
            {
                MessageBox.Show("Error in BIRTHDATE field!");
                mtxtBirth.Focus();
                return false;
            }

            return true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
