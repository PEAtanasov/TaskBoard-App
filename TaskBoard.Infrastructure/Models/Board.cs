using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Common.ValidationConstants;

namespace TaskBoard.Infrastructure.Models
{
    public class Board
    {
        public Board()
        {
           this.Tasks = new List<Task>();     
        }

        /// <summary>
        /// Board identifier
        /// </summary>
        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Board name
        /// </summary>
        [Required]
        [MaxLength(BoardConstants.NameMaxLength)]
        [Comment("Board name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; }
    }
}