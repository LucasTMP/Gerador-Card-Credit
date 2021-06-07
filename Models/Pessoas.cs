using System.ComponentModel.DataAnnotations;

namespace testecore.Models{

    public class Pessoas{
        
        [Key]
        public int Pes_ID {get; set;}

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength (120, ErrorMessage = "O email deve conter entre 10 e 120 caracteres")]
        [MinLength (10, ErrorMessage = "O email deve conter entre 10 e 120 caracteres")]
        public string PES_Email {get; set;}

    }

};


