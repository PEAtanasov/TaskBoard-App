using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.ValidationConstants;

namespace TaskBoard.Infrastructure.Models;

public class Task
{
    /// <summary>
    /// Task identifier
    /// </summary>
    [Key]
    [Comment("Task identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Task title
    /// </summary>
    [Required]
    [MaxLength(TaskConstans.TitleMaxLength)]
    [Comment("Task title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    [Required]
    [MaxLength(TaskConstans.DescriptionMaxLength)]
    [Comment("Task description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Date and time task has been created
    /// </summary>
    [Required]
    [Comment("Date and time task has been created")]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Board identifier
    /// </summary>
    [ForeignKey(nameof(Board))]
    [Comment("Board identifier")]
    public int? BoardId { get; set; }

    public Board? Board { get; set; }

    /// <summary>
    /// Task owner identifier
    /// </summary>
    [Required]
    [ForeignKey(nameof(Owner))]
    [Comment("Task owner identifier")]
    public string OwnerId { get; set; } = string.Empty;

    public IdentityUser Owner { get; set; } = null!;
}

