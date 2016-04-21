using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExamenFinal
{
    class ControlMateria
    {
        Modelo mod = new Modelo();
        EntidadMateria entidad;
        string sql;

        public DataTable leer()
        {
            sql = "SELECT "
                + "id_materia,"
                + "nombreM,"
                + "id_profesor"
                + " FROM "
                + "materia";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "id_materia,"
                + "nombreM,"
                + "id_profesor"
                + " FROM "
                + "materia"
                + " WHERE "
                + "id_materia = " + id;
            return mod.llenarDT(sql);
        }

        public void insertar(EntidadMateria entidad)
        {
            sql = "INSERT INTO materia ("
                 + "id_materia,"
                + "nombreM,"
                + "id_profesor"
                + ") VALUES ("
                + EntidadMateria.Id_materia + ","
                + "'" + EntidadMateria.NombreM + "',"
                + "'" + EntidadMateria.Id_profesorE + "'"
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadMateria entidad)
        {
            sql = "UPDATE materia SET "
                + "nombreM ='" + EntidadMateria.NombreM + "',"
                + "id_profesor = " + EntidadMateria.Id_profesorE + "'"
                + " WHERE "
                + "id_materia = " + EntidadMateria.Id_materia;
            mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE materia "
                + "WHERE "
                + "id_materia = " + id;
            mod.ejecutarSQL(sql);
        }
    }
}
