

namespace ExamenFinal
{
    static class EntidadEstudiante
    {
        private static int id_estudiante;

        public static int Id_estudiante
        {
            get { return id_estudiante; }
            set { id_estudiante = value; }
        }
        private static string nombreE;

        public static string NombreE
        {
            get { return nombreE; }
            set { nombreE = value; }
        }

        private static string apellidoE;

        public static string ApellidoE
        {
            get { return apellidoE; }
            set { apellidoE = value; }
        }
        private static string direccion;

        public static string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private static int edad;

        public static int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        private static int id_materiaE;

        public static int Id_materiaE
        {
            get { return id_materiaE; }
            set { id_materiaE = value; }
        }
    }
}
