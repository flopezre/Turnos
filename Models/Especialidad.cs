using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad  {

        [Key]
        public int idEspecialidad { get; set; }
        public string descripcion { get; set; }
        //public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

    }
}