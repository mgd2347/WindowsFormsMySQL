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
    public partial class Main : Form
    {
        InsertTraineeForm insertTraineeForm = new InsertTraineeForm();
        DeleteTraineeForm deleteTraineeForm = new DeleteTraineeForm();
        UpdateTraineeForm updateTraineeForm = new UpdateTraineeForm();
        ListTraineeForm listTraineeForm = new ListTraineeForm();
        public Main()
        {
            InitializeComponent();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (insertTraineeForm.IsDisposed)
            {
                insertTraineeForm = new InsertTraineeForm();
            }
            insertTraineeForm.MdiParent = this;
            insertTraineeForm.StartPosition = FormStartPosition.Manual;
            insertTraineeForm.Location = new Point((this.ClientSize.Width - insertTraineeForm.Width) 
                / 2, (this.ClientSize.Height - insertTraineeForm.Height) / 3);
            insertTraineeForm.Show();
            insertTraineeForm.Activate();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deleteTraineeForm.IsDisposed)
            {
                deleteTraineeForm = new DeleteTraineeForm();
            }
            deleteTraineeForm.MdiParent = this;
            deleteTraineeForm.StartPosition = FormStartPosition.Manual;
            deleteTraineeForm.Location = new Point((this.ClientSize.Width - deleteTraineeForm.Width) 
                / 2, (this.ClientSize.Height - deleteTraineeForm.Height) / 3);
            deleteTraineeForm.Show();
            deleteTraineeForm.Activate();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updateTraineeForm.IsDisposed)
            {
                updateTraineeForm = new UpdateTraineeForm();
            }
            updateTraineeForm.MdiParent = this;
            updateTraineeForm.StartPosition = FormStartPosition.Manual;
            updateTraineeForm.Location = new Point((this.ClientSize.Width - updateTraineeForm.Width)
                / 2, (this.ClientSize.Height - updateTraineeForm.Height) / 3);
            updateTraineeForm.Show();
            updateTraineeForm.Activate();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listTraineeForm.IsDisposed)
            {
                listTraineeForm = new ListTraineeForm();
            }
            listTraineeForm.MdiParent = this;
            listTraineeForm.StartPosition = FormStartPosition.Manual;
            listTraineeForm.Location = new Point((this.ClientSize.Width - listTraineeForm.Width)
                / 2, (this.ClientSize.Height - listTraineeForm.Height) / 3);
            listTraineeForm.Show();
            listTraineeForm.Activate();
        }
    }
}
