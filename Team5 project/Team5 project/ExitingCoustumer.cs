﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Team5_project
{
    public partial class ExitingCoustumer : Form
    {
        public static string Customer;
        public ExitingCoustumer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchbyid(CostumerSearch.Text.Trim());
        }
        protected void searchbyid(string searchText)
        {
            if (CostumerSearch.Text == "")
            {
                MessageBox.Show("No Id to search!");

            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PROJECT\TEAM5\TEAM5\TEAM5 PROJECT\DATABASE\StoreMange.mdf;Integrated Security=True;Connect Timeout=30");
                {
                    string sql = "SELECT * FROM Costumers WHERE Id = '" + CostumerSearch.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("id", CostumerSearch.Text);

                        DataTable dt = new DataTable();
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        ad.Fill(dt);

                        if (dt.Rows.Count > 0)
                        { //check if the query returns any data
                            ExitingCoustumer.Customer = CostumerSearch.Text;
                            dataGridView1.DataSource = dt;

                            
                            //dg1.DataBind();
                        }
                        else
                        {
                            MessageBox.Show("Record not found!");
                        }
                    }
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CostumerSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login ss = new Login();
            ss.Show();
        }

        private void returnCashier_Click(object sender, EventArgs e)
        {
            this.Close();
            Checkout ss = new Checkout();
            ss.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (ExitingCoustumer.Customer != "" && CostumerSearch.Text != "" && ExitingCoustumer.Customer == CostumerSearch.Text)
            {
                MessageBox.Show(Customer, "You have place this customer:", MessageBoxButtons.OK);
                this.Close();
                Checkout ss = new Checkout();
                ss.label4.Text = ExitingCoustumer.Customer;
                ss.label6.Text = FindProduct.Product;
                ss.label3.Text = FindProduct.Quantity;
                ss.label11.Text = FindProduct.Product_name;
                if (FindProduct.int_Product_price != 0)
                    ss.label9.Text = FindProduct.int_Product_price.ToString();
                ss.Show();
            }
            else
            {
                MessageBox.Show("You didnt place a customer, please try again","Error", MessageBoxButtons.OK);

            }
        }

        private void ExitingCoustumer_Load(object sender, EventArgs e)
        {

        }
    }
}
 