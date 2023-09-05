using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CoAutoWeb.Models
{
    public class DisponibilidadeModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Data de inicio")]
        [DataType(DataType.DateTime, ErrorMessage ="Data válida requerida")]
        [Required(ErrorMessage = "Data de inicio é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de fim")]
        [DataType(DataType.DateTime, ErrorMessage = "Data válida requerida")]
        [Required(ErrorMessage = "Data de fim é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }


        [Display(Name = "Hora de inicio")]
        [DataType(DataType.Time)] // Especifica que o campo é do tipo tempo (TimeSpan)
        [Required(ErrorMessage = "Tempo válido é obrigatório")]
        [RegularExpression(@"^\d{2}:\d{2}:\d{2}$", ErrorMessage = "Formato inválido. Use HH:mm:ss")]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de fim")]
        [DataType(DataType.Time)] // Especifica que o campo é do tipo tempo (TimeSpan)
        [Required(ErrorMessage = "Tempo válido é obrigatório")]
        [RegularExpression(@"^\d{2}:\d{2}:\d{2}$", ErrorMessage = "Formato inválido. Use HH:mm:ss")]
        public TimeSpan HoraFim { get; set; }

        
        [Display(Name = "Qual o veiculo")]
        [Range(1,100,ErrorMessage ="o veiculo deve ser associado")]
        public int IdVeiculo { get; set; }
    }
}
