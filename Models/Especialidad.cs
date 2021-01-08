using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad  {

        [Key]
        public int idEspecialidad { get; set; }
        public string descripcion { get; set; }

    }
}