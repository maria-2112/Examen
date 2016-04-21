using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExamenFinal
{
    class ControlEstudiantes
    {
         Modelo mod = new Modelo();
         EntidadEstudiante entidad;
        string sql;
        
        public DataTable leer()
        {
            sql = "SELECT "
                + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                 + "edad,"
                + "id_materia"
                + " FROM "
                + "estudiante";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                 + "edad,"
                + "id_materia"
                + " FROM "
                + "estudiante"
                + " WHERE "
                + "id_estudiante = " + id;
            return mod.llenarDT(sql);
        }

        public void insertar(EntidadEstudiante entidad)
        {
            sql = "INSERT INTO estudiante ("
                 + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                 + "edad,"
                + "id_materia"
                + ") VALUES ("
                + EntidadEstudiante.Id_estudiante + ","
                + "'" + EntidadEstudiante.NombreE + "',"
                + "'" + EntidadEstudiante.ApellidoE + "',"
                + "'" + EntidadEstudiante.Direccion + "',"
                 + "'" + EntidadEstudiante.Edad + "',"
                + "'" + EntidadEstudiante.Id_materiaE + "'"
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadEstudiante entidad)
        {
            sql = "UPDATE estudiante SET "
                + "nombre ='" + EntidadEstudiante.NombreE + "',"
                + "apellido= '" + EntidadEstudiante.ApellidoE + "',"
                + "direccion = '" + EntidadEstudiante.Direccion + "',"
                  + "edad = '" + EntidadEstudiante.Edad + "',"
                + "id_materia = " + EntidadEstudiante.Id_materiaE + "'"
                + " WHERE "
                + "id_estudiante = " + EntidadEstudiante.Id_estudiante;
                mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE estudiante "
                + "WHERE "
                + "id_estudiante = " + id;
            mod.ejecutarSQL(sql);
        }
      
    }
    }

