using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record PostWithoutchiledForManipulationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int TrainNumber { get; set; }
        [Required]
        public bool Critical { get; set; }
        public string? Img { get; set; }
    }

    public record PostDto(int id , string content , int trainNumber , bool critical  , string? img , int userId , int ? adminId );

    public record PostCreationDto : PostWithoutchiledForManipulationDto;
    public record PostUpdateDto : PostWithoutchiledForManipulationDto;
}
