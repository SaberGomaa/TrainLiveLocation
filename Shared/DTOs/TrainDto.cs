﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record TrainForManipulationDto
    {

        [Required(ErrorMessage = "Degree is a required field.")]
        public string? Degree { get; init; }


        [Required(ErrorMessage = "NumOfSeat is a required field.")]
        public int NumOfSeat { get; init; }


        [Required(ErrorMessage = "NumOfTrainCars is a required field.")]
        public int NumOfTrainCars { get; init; }

        //////
        [Required(ErrorMessage = "Conductor is a required field.")]
        public string? Conductor { get; init; }


        [Required(ErrorMessage = "Driver is a required field.")]
        public string? Driver { get; init; }
        ///////
       
        public string? CurrentLocation { get; init; }
    }

    public record TrainDto(int Id, string? Degree ,string? NumOfSeat, string? NumOfTrainCars, string? Conductor, string? Driver ,string? CurrentLocation);
    public record TrainCreationDto: TrainForManipulationDto;
    public record TrainUpdatenDto : TrainForManipulationDto;

}
