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
        [Required]
        public string Img { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

    }

    public record CommentDto(int Id, string? Content ,string? Img ,DateTime? Date , int? userId, int? postId , int? adminId );

    public record CommentCreationDto : CommentWithoutchiledForManipulationDto;

    public record CommentUpdateDto : CommentWithoutchiledForManipulationDto;
}
