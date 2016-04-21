using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinal
{
    public partial class Form3 : Form
    {
        EntidadProfesor profesor;
        ControlProfesor con = new ControlProfesor ();
        public Form3()
        {
            InitializeComponent();
        }
        private void limpiarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";

        }
        private void cargarGrid()
        {
            dataGridView1.DataSource = con.leer();
        }
        private void cargarEntidad()
        {
           EntidadProfesor.Id_profesor = Convert.ToInt16(textBox1.Text);
            EntidadProfesor.NombreP = textBox2.Text;
           EntidadProfesor.ApellidoP= textBox4.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            con.insertar(profesor);
            cargarGrid();
            limpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            con.modificar(profesor);
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
            textBox4.Text = dt.Rows[0][3].ToString();
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
    }
}
