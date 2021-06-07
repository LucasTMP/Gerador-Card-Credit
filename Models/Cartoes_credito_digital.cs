using System.ComponentModel.DataAnnotations;
using System;

namespace testecore.Models{
    public class Cartoes_credito_digital{
        [Key]
        public int CARD_ID {get; set;}

        [Required(ErrorMessage = "O numero do cartão é obrigatório")]
        [StringLength (16, ErrorMessage = "O numero do cartão deve conter 16 numeros")]
        public string CARD_Number {get; set;}

        [Required (ErrorMessage = "ID é obrigatório")]
        [Range (1, int.MaxValue, ErrorMessage = "ID invalido")]
        public int CARD_PES_ID {get; set;}
        public Pessoas Pessoas {get; set;}

    }
};

