

namespace ExamenFinal
{
    static class EntidadMateria
    {
        private static int id_materia;
        private static string nombreM;
        private static int id_profesorE;

        public static int Id_profesorE
        {
            get { return id_profesorE; }
            set { id_profesorE = value; }
        }

        public static string NombreM
        {
            get { return nombreM; }
            set { nombreM = value; }
        }

        public static int Id_materia
        {
            get { return id_materia; }
            set { id_materia = value; }
        }

    }
}
