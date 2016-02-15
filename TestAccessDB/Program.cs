using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace TestAccessDB
{
    class Program
    {
        //private OleDbConnection connection;
        private OleDbCommand command;
        private OleDbDataAdapter adapter;
        private DataSet dataset;

        static void Main(string[] args)
        {


            //InitializeComponent();

            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet dataset = new DataSet();

            connection.ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/data/pbsgl/PBSGL-DB_BackEnd.accdb;" +
                "Persist Security Info=False";

            command.Connection = connection;
            command.CommandText = "SELECT * FROM Members";

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(dataset, "Members");

                string s = Convert.ToString(dataset.Tables["Members"].Rows[1][8]);





            }
            catch (OleDbException e)
            {
                Console.WriteLine(e.Message);
              //  MessageBox.Show("Error occured while connecting to database.");
                // Application.Exit();
            }
            finally
            {
                connection.Close();
            }






        }
    }
}
