using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace SportXExame.Entity
{
    [Table("Cliente")]
    public class Cliente
    {


        [Column("Id")]
        public int id { get; set; }

        [Column("Nome")]
        [MaxLength(100, ErrorMessage = "Este campo tem máximo de 100 caracteres")]
        public string nome { get; set; }

        [Column("Email")]
        public string email { get; set; }


        [Column("CPF/CNPJ")]
        public string cpfCNPJ { get; set; }

        [Column("CEP")]
        public string cep { get; set; }

        [Column("Classificacao")]
        public string classificacao { get; set; }

        [Column("Telefones")]
        public virtual  List<Telefone> telefones { get; set; }




    }
}
