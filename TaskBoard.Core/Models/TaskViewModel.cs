using static Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Core.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TaskConstans.TitleMaxLength, MinimumLength =TaskConstans.TitleMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(TaskConstans.DescriptionMaxLength, MinimumLength = TaskConstans.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string Owner { get; set; } = string.Empty;
    }
}
