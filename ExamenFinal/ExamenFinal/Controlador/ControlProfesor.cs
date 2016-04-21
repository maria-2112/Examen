using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExamenFinal
{
    class ControlProfesor
    {
        Modelo mod = new Modelo();
        EntidadProfesor entidad;
        string sql;

        public DataTable leer()
        {
            sql = "SELECT "
                + "id_profesor,"
                + "nombreP,"
                + "apellidoP"
                + " FROM "
                + "profesor";
            return mod.llenarDT(sql);
        }

        public DataTable buscar(int id)
        {
            sql = "SELECT "
                + "id_profesor,"
                + "nombreP,"
                + "apellidoP"
                + " FROM "
                + "profesor"
                + " WHERE "
                + "id_profesor = " + id;
            return mod.llenarDT(sql);
        }

        public void insertar(EntidadProfesor entidad)
        {
            sql = "INSERT INTO profesor ("
                 + "id_profesor,"
                + "nombreP,"
                + "apellidoP"
                + ") VALUES ("
                + EntidadProfesor.Id_profesor + ","
                + "'" + EntidadProfesor.NombreP + "',"
                + "'" + EntidadProfesor.ApellidoP + "'"
                + ")";
            mod.ejecutarSQL(sql);
        }

        public void modificar(EntidadProfesor entidad)
        {
            sql = "UPDATE profesor SET "
                + "nombreP ='" + EntidadProfesor.NombreP + "',"
                + "apellidoP = " + EntidadProfesor.ApellidoP + "'"
                + " WHERE "
                + "id_profesor = " + EntidadProfesor.Id_profesor;
            mod.ejecutarSQL(sql);
        }

        public void eliminar(int id)
        {
            sql = "DELETE profesor "
                + "WHERE "
                + "id_profesor = " + id;
            mod.ejecutarSQL(sql);
        }
    }
    }

