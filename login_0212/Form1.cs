using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //宣言追加される。


namespace login_0212
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //Data Source=(localdb)\ProjectsV13;Initial Catalog=新しいデータベース;Connect Timeout=60;Persist Security Info=True;
            //基本形↑
          
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ryodozkpr\Documents\dbLogin.mdf;Integrated Security=True;Connect Timeout=30;");
            con.Open();

            try
            {
                string query = "Select count(*) From tblogin where Username = '" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                //DataAdapter.Fill Method データソース内の行と一致するように、DataSetの行を追加または更新する。
                if (dtbl.Rows[0][0].ToString() == "1")
                {
                    Form2 objForm2 = new Form2();
                    this.Hide();
                    objForm2.Show();
                    MessageBox.Show("ようこそ"+ textBox1.Text+"さん", "通知");
                }
                else
                {
                    MessageBox.Show("ユーザーネームとパスワードをご確認ください","Caution!");
                }
            }
            finally
            {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 objForm3 = new Form3();
            this.Hide();
            objForm3.Show();
        }
    }
}
