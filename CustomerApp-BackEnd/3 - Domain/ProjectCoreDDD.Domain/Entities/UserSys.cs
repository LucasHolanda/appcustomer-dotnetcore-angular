namespace ProjectCoreDDD.Domain.Entities
{
    public class UserSys : EntityBase
    {
        public string Login { get; set; }       
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}