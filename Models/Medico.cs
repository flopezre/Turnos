using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required (ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        [Required (ErrorMessage = "Debe ingresar una dirección")]
        [Display (Name = "Dirección")]
        public string Direccion { get; set; }
        
        [Required (ErrorMessage = "Debe ingresar un teléfono")]
        [Display (Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required (ErrorMessage = "Debe ingresar un email")]
        [EmailAddress (ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; }
        

        [Display (Name = "Horario de atención desde")]
        [DataType (DataType.Time)]
        [DisplayFormat (DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display (Name = "Horario de atención hasta")]
        [DataType (DataType.Time)]
        [DisplayFormat (DataFormatString = "{0:HH:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }

        // Esto es para mostrar una lista de especialidades al medico
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        public List<Turno> Turno { get; set; }

    }
}