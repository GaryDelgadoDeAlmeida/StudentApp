using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Student.View;
using Student.Class;

namespace Student
{
    public partial class Index : Form
    {
        private DataStudent dataStudent;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        public Index()
        {
            InitializeComponent();
            this.OpensForms(new DataStudent());
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.picNormalize.Visible = true;
            this.picMaximize.Visible = false;
        }

        private void picNormalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.picMaximize.Visible = true;
            this.picNormalize.Visible = false;
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            this.dataStudent = new DataStudent();
            this.OpensForms(this.dataStudent);
            this.btnDelete.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.OpensForms(new AddStudent());
            this.btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(this.dataStudent != null)
            {
                if(this.dataStudent.dataGridStudent.SelectedRows.Count > 0)
                {
                    try
                    {
                        ConnectionStudentDatabase connectionStudentDatabase = new ConnectionStudentDatabase();
                        connectionStudentDatabase.getSqlConnection().ConnectionString = connectionStudentDatabase.getLocate();
                        connectionStudentDatabase.getSqlConnection().Open();

                        connectionStudentDatabase.getSqlCommand().Connection = connectionStudentDatabase.getSqlConnection();
                        string deleteData = "Delete From Student Where id = '" + this.dataStudent.dataGridStudent.CurrentRow.Cells[0].Value.ToString() + "';";

                        connectionStudentDatabase.getSqlCommand().CommandText = deleteData;
                        connectionStudentDatabase.getSqlCommand().ExecuteNonQuery();

                        connectionStudentDatabase.getSqlConnection().Close();

                        MessageBox.Show("La suppression s'est correctement effectuée.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("The database is null", "Error", MessageBoxButtons.OKCancel);
            }
        }

        private void pnlHead_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpensForms(object formS)
        {
            if (this.pnlContainer.Controls.Count > 0)
            {
                this.pnlContainer.Controls.RemoveAt(0);
            }

            Form fS = formS as Form;
            fS.TopLevel = false;
            fS.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(fS);
            this.pnlContainer.Tag = fS;
            fS.Show();
        }
    }
}
