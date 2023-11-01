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
using System.Data.SqlTypes;
namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private static string connect_Str = @"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=TRUNG_TAM_ANH_NGU_ILA;Integrated Security=True";
        private SqlConnection conn = new SqlConnection(connect_Str);
        Score scoreA = new Score();
        private void Load_Data()
        {
            conn.Open();
            string sql = "SELECT * FROM DIEM";
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            dataGridView.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txb_Ma.Text == "" || txb_Ten.Text == "")
            {
                MessageBox.Show("Need data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string mhv = txb_Ma.Text;
                string mkh = txb_Ten.Text;

                if (scoreA.insertScore(mhv, mkh, score, desc) == true)
                {
                    btnRefresh.PerformClick();
                    MessageBox.Show("Hoàn tất cập nhật điểm", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa hoàn tất cập nhật điểm", "Update Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_score.Clear();
            textBox_description.Clear();
            Load_Data();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (textBox_stdId.Text == "" )
            {
                MessageBox.Show("Need Score data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string mhv = textBox_stdId.Text;

                if (scoreA.deleteScore(mhv) == true)
                {
                    btnRefresh.PerformClick();
                    MessageBox.Show("Hoàn tất xóa điểm", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa hoàn tất xóa điểm", "Delete Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

    }
}
