using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenFinal
{
    class Modelo
    {
        string conexion = "Data Source=USER;Initial Catalog=bd_colegio;Integrated Security=True;";
        SqlConnection sqlconn;
       

        public void conectarBD()
        {
            sqlconn = new SqlConnection(conexion);
          
            try
            {
                sqlconn.Open(); 
               
            }
            catch(Exception e)
            {
                var message = MessageBox.Show("Conexion fallida! Error: " + e.Message.ToString());
            }

        }

        public void desconectarBD()
        {
            sqlconn.Close();
         
        }

        public void ejecutarSQL(string sql)
        {
            SqlCommand sqlcomm = new SqlCommand();
           
            conectarBD();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sql;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
           
            desconectarBD();
        }

        public DataTable llenarDT(string sql)
        {
            conectarBD();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
           
            desconectarBD();
            return dt;
        }
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
    }
    }

