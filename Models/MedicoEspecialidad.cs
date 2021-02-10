namespace Turnos.Models
{
    public class MedicoEspecialidad
    {
        public int idMedico { get; set; }

        public int idEspecialidad { get; set; }

        public Medico Medico { get; set; }

        public Especialidad Especialidad { get; set; }
    }
}