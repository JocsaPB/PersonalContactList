using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalContactList.MVC.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public int ContatId { get; set; }
        [Required(ErrorMessage = "Informe o nome do contato")]
        [DisplayName("Nome")]
        [MaxLength(80, ErrorMessage = "Nome do contato não pode ser superior a {0} caracteres")]
        [MinLength(4, ErrorMessage = "Nome do contato deve maior ou igual a {0} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Informe um apelido para o contato")]
        [DisplayName("Apelido")]
        public string KnownAs { get; set; }
        [Required(ErrorMessage = "Seleciona uma categoria para o contato")]
        public int CategoryId { get; set; }
        public virtual CategoryViewModel Category { get; set; }

        //ValueObjectsFromDataBase
        //PHONES
        [Required(ErrorMessage = "Você deve informar ao menos um número para o contato")]
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        [DisplayName("Número de telefone A:")]
        public string TelNumberA { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        [DisplayName("Número de telefone B")]
        public string TelNumberB { get; set; }
        //SOCIAL MEDIA
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        public string Facebook { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        public string Instagran { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        public string Twiiter { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        public string Whatsapp { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        public string Linkedin { get; set; }
        //EMAILS
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        [DisplayName("E-mail A")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string EmailA { get; set; }
        [MaxLength(30, ErrorMessage = "Não deve ultrapassar {0} caracteres")]
        [DisplayName("E-mail B")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string EmailB { get; set; }
    }
} 