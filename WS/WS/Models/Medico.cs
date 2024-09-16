using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    [Table("Medico")]
    public class Medico
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        public string NomeMedico { get; set; }
        public string Especialidade { get; set; }

        public Medico()
        {
            this.Id = 0;
            this.NomeMedico = "";
            this.Especialidade = "";
        }
    }
}
