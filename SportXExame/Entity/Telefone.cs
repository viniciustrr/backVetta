using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Text.Json.Serialization;

namespace SportXExame.Entity
{
    [Table("Telefone")]
    public class Telefone
    {
      

        [Column("Id")]
        public int id { get; set; }

        [Column("Telefones")]
        public string telefone { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }


    }
}
