using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student.View
{
    public partial class DataStudent : Form
    {
        public DataStudent()
        {
            InitializeComponent();
        }

        private void DataStudent_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'studentDatabase.Student'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.studentTableAdapter.Fill(this.studentDatabase.Student);

        }
    }
}
