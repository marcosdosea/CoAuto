﻿using System.ComponentModel.DataAnnotations;

namespace CoAutoAPI.Models;

public class DisponibilidadeViewModel
{
    [Key]
    public uint Id { get; set; }

    [Display(Name = "Data e Hora de inicio")]
    [Required(ErrorMessage = "Data de inicio é obrigatório")]
    public DateTime DataHoraInicio { get; set; }

    [Display(Name = "Data e Hora do fim")]
    [Required(ErrorMessage = "Data de fim é obrigatório")]
    public DateTime DataHoraFim { get; set; }

    [Display(Name = "Qual o veiculo")]
    [Range(1, 100, ErrorMessage = "o veiculo deve ser associado")]
    public uint IdVeiculo { get; set; }
}
