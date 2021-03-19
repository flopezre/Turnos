using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad  {

        [Key]
        public int IdEspecialidad { get; set; }

        [StringLength(200, ErrorMessage = "El campo de especialidad debe tener como maximo 200 caracteres")]
        [Required (ErrorMessage = "Debe ingresar una especialidad")]
        [Display (Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

    }
}