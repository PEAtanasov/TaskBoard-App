using System.ComponentModel.DataAnnotations;
using static Common.ValidationConstants;

namespace TaskBoard.Core.Models
{
    public class TaskFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TaskConstans.TitleMaxLength, MinimumLength = TaskConstans.TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(TaskConstans.DescriptionMaxLength, MinimumLength = TaskConstans.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public string OwnerId = string.Empty;

        public IEnumerable<TaskBoardModel> Boards = new List<TaskBoardModel>();
    }
}
