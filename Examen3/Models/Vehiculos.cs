using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Examen3.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        [ForeignKey(typeof(Marca))]
        public int FKMarcaId { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Marca Marca{ get; set; }
    }
}
