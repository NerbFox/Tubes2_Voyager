// using System;
// using System.Data;
// using System.Windows.Forms;
// using System.Data.SqlClient;
// using System.Drawing;

// namespace WindowsFormsApplication1
// {
//     public partial class Form1 : Form
//     {
//         public Form1()
//         {
//             InitializeComponent();
//         }

//         private void button1_Click(object sender, EventArgs e)
//         {
//             DataGridViewRow row = this.dataGridView1.RowTemplate;
//             row.DefaultCellStyle.BackColor = Color.Bisque;
//             row.Height = 35;
//             row.MinimumHeight = 20;
            
//             string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
//             string sql = "SELECT * FROM Authors";
//             SqlConnection connection = new SqlConnection(connectionString);
//             SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
//             DataSet ds = new DataSet();
//             connection.Open();
//             dataadapter.Fill(ds, "Author_table");
//             connection.Close();
//             dataGridView1.DataSource = ds;
//             dataGridView1.DataMember = "Author_table";

//         }
//     }
// }