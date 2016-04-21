using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ExamenFinal
{
    public partial class Form2 : Form
    {
        EntidadMateria materia;
        ControlMateria con = new ControlMateria();
        public Form2()
        {
            InitializeComponent();
        }

        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
        }
        private void cargarGrid()
        {
            dataGridView1.DataSource = con.leer();
        }
        private void cargarEntidad()
        {
            EntidadMateria.Id_materia = Convert.ToInt16(textBox1.Text);
            EntidadMateria.NombreM = textBox2.Text;
            EntidadMateria.Id_profesorE = Convert.ToInt16(textBox3.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cargarGrid();
            comboBox1.DataSource = cargarCbxProfesor();
            comboBox1.DisplayMember = "profesor";
            comboBox1.ValueMember = "nombreP" + "apellidoP";

        }
        #region cbx
        private DataTable cargarCbxProfesor()
        {
            string sql;
            string conexion = "Data Source=User;Initial Catalog=bd_colegio;Integrated Security=True;";
            DataTable dt = new DataTable();
            sql = "select " +
                 "nombreP, " +
                   "apellidoP" +
                 " from " + "profesor";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            return dt;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            con.insertar(materia);
            cargarGrid();
            limpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
               
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             DataTable dt = new DataTable();
            dt = con.buscar(Convert.ToInt16(textBox1.Text));
            textBox2.Text = dt.Rows[0][1].ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(comboBox1.SelectedValue);
        }
    }
}
