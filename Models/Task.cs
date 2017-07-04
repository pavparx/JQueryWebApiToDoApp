namespace Models
{
    public class Task
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public virtual User Creator { get; private set; }
    }
}