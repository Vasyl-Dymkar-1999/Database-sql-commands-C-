using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DB_with_Vova
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-G39LVL1;Initial Catalog=Studyki;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand com1 = new SqlCommand("SELECT * FROM students", con);
                SqlDataAdapter adapter = new SqlDataAdapter(com1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "INSERT INTO students(id,name,age,mark) values( @id,@name,@age,@mark)";

            int id = int.Parse(textBox1.Text);
            string name = (textBox2.Text);
            int age = int.Parse(textBox3.Text);
            int mark = int.Parse(textBox4.Text);

            using (SqlConnection con= new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand(command, con);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@name", name);
                com.Parameters.AddWithValue("@age", age);
                com.Parameters.AddWithValue("@mark", mark);

                com.ExecuteNonQuery();
                SqlCommand com1 = new SqlCommand("SELECT * FROM students", con);
               // SqlDataReader reader = com1.ExecuteReader();
                //int i = 0;
                //while (reader.Read())
                //{
                //    object ID = reader.GetValue(0);
                //    object Name = reader.GetValue(1);
                //    object Age = reader.GetValue(2);
                //    object Mark = reader.GetValue(3);
                //    dataGridView1.Rows[i].Cells[0].Value = ID;
                //    i++;
                //}

                SqlDataAdapter adapter = new SqlDataAdapter(com1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string comand = "UPDATE students SET name= @name WHERE id=@id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand(comand,con);
                com.Parameters.AddWithValue("@id",int.Parse(textBox5.Text));
                com.Parameters.AddWithValue("@name", (textBox6.Text));

                com.ExecuteNonQuery();


                SqlCommand com1 = new SqlCommand("SELECT * FROM students", con);
                SqlDataAdapter adapter = new SqlDataAdapter(com1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            string comand = "DELETE FROM students  WHERE id=@id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand(comand, con);
                com.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
                

                com.ExecuteNonQuery();


                SqlCommand com1 = new SqlCommand("SELECT * FROM students", con);
                SqlDataAdapter adapter = new SqlDataAdapter(com1);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
        }
    }
}
