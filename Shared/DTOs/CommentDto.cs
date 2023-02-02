using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record CommentWithoutchiledForManipulationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

    }

    public record CommentDto(int Id, string? Content ,string? Img ,DateTime? Date);

    public record CommentCreationDto : CommentWithoutchiledForManipulationDto;

    public record CommentUpdateDto : CommentWithoutchiledForManipulationDto;
}
