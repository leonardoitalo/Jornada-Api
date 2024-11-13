﻿using System.ComponentModel.DataAnnotations;

namespace Jornada.API.Data.Dtos;

public class CreateFeedbackDto
{
    [Required]
    public string Photo { get; set; }

    [Required]
    public string Message { get; set; }

    [Required]
    public string Name { get; set; }
}