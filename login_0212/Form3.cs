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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=新しいデータベース;Connect Timeout=60;Persist Security Info=True;");
            con.Open();
                //Form1.csと同様。
            try{
                var cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO tblogin VALUES('" + textBox1.Text + "' , '" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(textBox1.Text + "さんを追加しました", "通知");
            }

            catch (Exception ex){
                MessageBox.Show(ex.Message, "通知");
            }

            finally{
                con.Close();
            }

        }
    }
}
