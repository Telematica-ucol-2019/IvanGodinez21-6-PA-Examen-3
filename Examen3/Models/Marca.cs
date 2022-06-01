using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen3.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
    }
}
