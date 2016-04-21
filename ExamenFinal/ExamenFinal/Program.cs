using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ExamenFinal
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 


        static Menu form; // static + Form 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread thr = new Thread(ConsoleEstadisticas);
            form = new Menu();
            thr.Start(form);
            Application.Run(new Form1());
        }
        static void ConsoleEstadisticas(object state)
        {
            string conexion = "Data Source=USER;Initial Catalog=bd_colegio;Integrated Security=True;";
            SqlConnection sqlconn;
            sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            string nombre, apellido, direccion;
            int id, materia, edad, cont1 = 0, cont2 = 0,pr;
            Form1 form1 = new Form1();
            Modelo mod = new Modelo();
            ControlEstudiantes estudiante=new ControlEstudiantes();
            ControlMateria materias=new ControlMateria();
            ControlProfesor profesor=new ControlProfesor();
            estudiante.leer();
            DataTable dt = new DataTable();
            id = Convert.ToInt32(dt.Rows[0][1].ToString());
            nombre = dt.Rows[0][2].ToString();
            apellido = dt.Rows[0][3].ToString();
            direccion = dt.Rows[0][4].ToString();
            edad = Convert.ToInt32(dt.Rows[0][5].ToString());
            materia = Convert.ToInt32(dt.Rows[0][6].ToString());
            materias.leer();
           dt = new DataTable();
           pr = Convert.ToInt32(dt.Rows[0][1].ToString());
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
          

        string cmd;
            Console.WriteLine("Ingrese en comando que desea Ejecutar..");
            do
            {
                
                cmd = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(cmd))
                {
                    cmd = cmd.ToLower();
                    switch (cmd)
                    {
                      
                        case "reporte de edades":
                        {
                            try
                            {
                                comando = new SqlCommand("select edad from estudiante", sqlconn);
                                lector = comando.ExecuteReader();
                                while (lector.Read())
                                {
                                    if (edad >= 18)
                                    {
                                        cont1++;
                                        Console.WriteLine("Mayores de edad" + cont1);
                                    }
                                    else if (edad < 18)
                                    {
                                        cont2++;
                                        Console.WriteLine("Menores de edad" + cont2);
                                    }
                                } lector.Close();
                                
                            }
                            catch (Exception e)
                            {

                            }
                           
                            
                            break;
                        }
                        case "reporte de Cupo":
                            {
                                comando = new SqlCommand("select id_materia from estudiante", sqlconn);
                                lector = comando.ExecuteReader();
                                while (lector.Read())
                                {
                                    if (materia ==1)
                                    {
                                        cont1++;
                                        Console.WriteLine("la Materia tiene ..." + cont1);
                                    } else
                                    if (materia == 2)
                                    {
                                        cont2++;
                                        Console.WriteLine("la Materia tiene ..." + cont2);
                                    }
                                    else
                                        if (materia == 3)
                                        {
                                            cont1++;
                                            Console.WriteLine("la Materia tiene ..." + cont1);
                                        }
                                        else
                                            if (materia == 4)
                                            {
                                                cont2++;
                                                Console.WriteLine("la Materia tiene ..." + cont2);
                                            }
                                } lector.Close();
                            
                            break;
                        }
                        case "reporte de asistencia":
                            {
                                try
                                {
                                    comando = new SqlCommand("select id_profesor from materia", sqlconn);
                                    lector = comando.ExecuteReader();
                                    while (lector.Read())
                                    {
                                        if (pr==1)
                                        {
                                            cont1++;
                                            Console.WriteLine("Prof tiene " + cont1+"Alumnos");
                                        }
                                        else if (pr == 2)
                                        {
                                            cont2++;
                                            Console.WriteLine("Prof tiene " + cont2 + "Alumnos");
                                        }
                                        else if (pr == 3)
                                        {
                                            cont1++;
                                            Console.WriteLine("Prof tiene " + cont1 + "Alumnos");
                                        }
                                        else if (pr == 4)
                                        {
                                            cont2++;
                                            Console.WriteLine("Prof tiene " + cont2 + "Alumnos");
                                        }
                                    } lector.Close();
                                }
                                catch (Exception e)
                                {

                                }
                                break;
                            }
                        case "reporte de profesorado":
                            {

                                break;
                            }
                        case "mostrar":
                            {
                                Generada m = new Generada();
                                m.Mostrar();
                                break;
                            }
                        case "salir":
                            {
                                Form frm = (Form)state;
                                if (!frm.IsDisposed) 
                                    frm.Invoke(new Action(() => frm.Close()));
                                break;
                            }
                        default:
                            Console.WriteLine("Comando invalido...");
                            break;
                    }
               }
            } while (!(cmd == "salir")); 
            
        
        
        
        
        }
        public class Generada
        {
            internal string Mostrar()
            {
                return "  ";
            }

        }
    }
}
