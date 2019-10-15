using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student.Class
{
    class ConnectionStudentDatabase
    {
        private StudentDatabase studentDatabase;
        private SqlDataAdapter dataAdapter;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string locate;

        public ConnectionStudentDatabase()
        {
            this.studentDatabase = new StudentDatabase();
            this.dataAdapter = new SqlDataAdapter();
            this.sqlConnection = new SqlConnection();
            this.sqlCommand = new SqlCommand();
            this.locate = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\garya\Documents\Developpement\Application\C#\Student\Student\StudentDatabase.mdf';Integrated Security=True";
        }

        public StudentDatabase getStudentDatabase()
        {
            return this.studentDatabase;
        }

        public SqlDataAdapter getSqlDataAdapter()
        {
            return this.dataAdapter;
        }

        public SqlConnection getSqlConnection()
        {
            return this.sqlConnection;
        }

        public SqlCommand getSqlCommand()
        {
            return this.sqlCommand;
        }

        public string getLocate()
        {
            return this.locate;
        }
    }
}
