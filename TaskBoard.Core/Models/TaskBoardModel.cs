using static Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Core.Models
{
    public class TaskBoardModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}