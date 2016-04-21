

namespace ExamenFinal
{
    static class EntidadProfesor
    {
        private static int id_profesor;
        private static string nombreP;
        private static string apellidoP;

        public static string ApellidoP
        {
            get { return apellidoP; }
            set { apellidoP = value; }
        }


        public static string NombreP
        {
            get { return nombreP; }
            set { nombreP = value; }
        }

        public static int Id_profesor
        {
            get { return id_profesor; }
            set { id_profesor = value; }
        }
    }
}
