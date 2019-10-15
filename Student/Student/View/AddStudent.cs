using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student.Class;

namespace Student.View
{
    public partial class AddStudent : Form
    {

        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(
                this.txtFirstName.Text != "" &&
                this.txtLastName.Text != "" &&
                this.txtPhoneNumber.Text != "" &&
                this.txtAddress.Text != "" &&
                this.txtPostalCode.Text != "" &&
                this.txtCity.Text != "" &&
                this.txtCountry.Text != ""
                )
            {
                try
                {

                    ConnectionStudentDatabase connectionStudentDatabase = new ConnectionStudentDatabase();
                    connectionStudentDatabase.getSqlConnection().ConnectionString = connectionStudentDatabase.getLocate();
                    connectionStudentDatabase.getSqlConnection().Open();

                    connectionStudentDatabase.getSqlCommand().Connection = connectionStudentDatabase.getSqlConnection();

                    string insertData = "INSERT INTO Student (firstName, lastName, phoneNumber, address, postalCode, city, country) VALUES (" +
                        "'" + this.txtFirstName.Text + "', " +
                        "'" + this.txtLastName.Text + "', " +
                        "'" + this.txtPhoneNumber.Text + "', " +
                        "'" + this.txtAddress.Text + "', " +
                        "'" + this.txtPostalCode.Text + "', " +
                        "'" + this.txtCity.Text + "', " +
                        "'" + this.txtCountry.Text + "')";

                    connectionStudentDatabase.getSqlCommand().CommandText = insertData;
                    connectionStudentDatabase.getSqlCommand().ExecuteNonQuery();

                    connectionStudentDatabase.getSqlConnection().Close();
                    MessageBox.Show("The student was successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.eraseAllInput();
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fields can't be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            this.eraseAllInput();
        }

        private void eraseAllInput()
        {
            this.txtFirstName.Clear();
            this.txtLastName.Clear();
            this.txtPhoneNumber.Clear();
            this.txtAddress.Clear();
            this.txtPostalCode.Clear();
            this.txtCity.Clear();
            this.txtCountry.Clear();
        }
    }
}
