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
            //Console.WriteLine("this is a message "+this.textBox8);
            connection.Open();
            StringBuilder sb = new StringBuilder();
            if (textBox8.Text == "")
            {

                String query1 = "Select Email,Fullname,Phone,birth,type,address,registrationdate from Customer1 ";
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = query1;
                OleDbDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    for (int i = 0; i <= 6; i++)
                    {
                        sb.Append(reader.GetString(i) + " ");

                    }
                    sb.Append(Environment.NewLine);
                }
                reader.Close();
                MessageBox.Show(sb.ToString());
            }
            else {
                String query = "Select Email,Fullname,Phone,birth,type,address,registrationdate from Customer1 where email= '" + textBox8.Text + "';";
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    textBox1.Text=reader.GetString(0);
                    textBox2.Text = reader.GetString(1);
                    textBox3.Text = reader.GetString(2);
                    textBox4.Text = reader.GetString(3);
                    textBox5.Text = reader.GetString(4);
                    textBox6.Text = reader.GetString(5);
                    textBox7.Text = reader.GetString(6);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {

                        //txtBoxes[i].Text=reader.GetString(1);
                        //this.(textBox+i)=reader.GetString(i);
                        //sb.Append(reader.GetString(i) + " ");
                                            }
                    sb.Append(Environment.NewLine);
                }
                reader.Close();

            }
            //MessageBox.Show(sb.ToString());
            connection.Close();

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
            }); ;
            //string[] arr = {query,query2,query3,query4,query5,query6,query7};
            //string allQueries = string.Join(";", arr);
            //command.CommandText = allQueries;
            int i = command.ExecuteNonQuery();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            {
                //Console.WriteLine("this is a message "+this.textBox8);
                connection.Open();
                StringBuilder sb = new StringBuilder();
                if (textBox8.Text == "")
                {
                    MessageBox.Show("error");

                    //reader.Close();
                }
                else
                {
                    OleDbCommand command = connection.CreateCommand();
                    OleDbCommand cmd = connection.CreateCommand();
                    String query = "delete from Customer1 where email= '" + textBox8.Text + "';";

                    cmd.CommandText = query;
                    OleDbDataReader reader = cmd.ExecuteReader();

                    /*while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sb.Append(reader.GetString(i) + " ");

                        }
                        sb.Append(Environment.NewLine);
                    }
                    reader.Close();
            */
                    int i = command.ExecuteNonQuery();
                    MessageBox.Show(i.ToString() + " row affected");
                }

                connection.Close();
                

            }
            //ToString() + " row affected");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 10)
            {
                //MessageBox.Show("invalide inputs");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("You must select a person by its email");
            }
            else
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                String query = "UPDATE Customer1 set email= '" + textBox1.Text + 
                                                 "', Fullname='"+ textBox2.Text +
                                                 "' where email= '" + textBox8.Text + 


                    "';";
                //int i = command.ExecuteNonQuery();
                //MessageBox.Show(i.ToString() + " row affected");
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                int i = cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

