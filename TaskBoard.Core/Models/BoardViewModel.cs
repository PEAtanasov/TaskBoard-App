using System.ComponentModel.DataAnnotations;

using static Common.ValidationConstants;

namespace TaskBoard.Core.Models
{
    public class BoardViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BoardConstants.NameMaxLength, MinimumLength = BoardConstants.NameMinLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
