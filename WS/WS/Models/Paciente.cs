using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [PrimaryKey,NotNull,AutoIncrement]
        public int Id { get; set; }
        public string NomePaciente { get; set; }
        public string NomeMedico { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }

        public Paciente() 
        {
            this.Id = 0;
            this.NomePaciente = "";
            this.NomeMedico = "";
            this.Dia = "";
            this.Horario = "";
        }
    }
}
