namespace ProjectCoreDDD.Domain.Entities
{
    public class UserRole : EntityBase
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}