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
    public partial class Form1 : Form
    {
        EntidadEstudiante est;
        ControlEstudiantes con = new ControlEstudiantes();
        public string nombre;
        public string apellido;
        public string direccionF;
        public int edad;
        public int id;
        public int direccion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrid();
            comboBox1.DataSource = cargarCbxMaterias();
            comboBox1.DisplayMember = "materia";
            comboBox1.ValueMember = "nombreM";
           
        }
        #region cbx
        private DataTable cargarCbxMaterias()
        {
            string sql;
            string conexion = "Data Source=User;Initial Catalog=bd_colegio;Integrated Security=True;";
            DataTable dt = new DataTable();
            sql = "select " +
                 "nombreM" +
                 " from " + "materia";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            return dt;
        }
        #endregion
        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void cargarGrid()
        {
            dataGridView1.DataSource = con.leer();
        }
        private void cargarEntidad()
        {
            EntidadEstudiante.Id_estudiante = Convert.ToInt16(textBox1.Text);
            EntidadEstudiante.NombreE = textBox2.Text;
            EntidadEstudiante.ApellidoE = textBox3.Text;
            EntidadEstudiante.Direccion = textBox4.Text;
            EntidadEstudiante.Edad = Convert.ToInt16(textBox5.Text);
            EntidadEstudiante.Id_materiaE = Convert.ToInt16(comboBox1.SelectedValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            con.insertar(est);
            cargarGrid();
            limpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            con.modificar(est);
            cargarGrid();
            limpiarCampos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.eliminar(Convert.ToInt16(textBox1.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = con.buscar(Convert.ToInt16(textBox1.Text));
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            int index = Convert.ToInt16(dt.Rows[0][5].ToString()) + EntidadEstudiante.Id_materiaE;
            comboBox1.SelectedIndex = index;
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }       
    }
}
