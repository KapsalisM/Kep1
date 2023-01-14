using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            String query = "Select Email,Fullname,Phone,birth,type,address,registrationdate from Customer1 ";
            OleDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            OleDbDataReader reader = cmd.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (reader.Read())
            {
                for (int i = 0; i <= 6; i++)
                {
                    sb.Append(reader.GetString(i) + " " );

                }
                sb.Append(Environment.NewLine);
            }
            reader.Close();
            connection.Close();
            MessageBox.Show(sb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            String email = textBox1.Text;
            String fullname = textBox2.Text;
            String phone = textBox3.Text;
            String birth = textBox4.Text;
            String type = textBox5.Text;
            String address = textBox6.Text;
            String registrationdate = textBox7.Text;
            OleDbCommand command = connection.CreateCommand();
            String query = "Insert into Customer1([email],[fullname],[phone],[birth],[type],[address],[registrationdate]) values(@email,@fullname,@phone,@birth,@type,@address,@registrationdate)";
            command.CommandText = query;
    
            /*command.Parameters[0].Value = email;
            command.Parameters[1].Value = fullname;*/
            command.Parameters.AddRange(new OleDbParameter[] {
            new OleDbParameter("@email",email),
            new OleDbParameter("@fullname",fullname),
            new OleDbParameter("@phone",phone),
            new OleDbParameter("@birth",birth),
            new OleDbParameter("@type",type),
            new OleDbParameter("@address",address),
            new OleDbParameter("@registrationdate",registrationdate)
            });;
            //string[] arr = {query,query2,query3,query4,query5,query6,query7};
            //string allQueries = string.Join(";", arr);
            //command.CommandText = allQueries;
            int i = command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(i.ToString() + " row affected");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
