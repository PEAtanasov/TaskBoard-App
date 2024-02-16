namespace TaskBoard.Core.Models
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }
        public int UserTasksCount { get; set;}
        public List<HomeBoardModel> BoardsWithTasksCount { get; set; } = new List<HomeBoardModel>();
    }
}
