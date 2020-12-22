using ProjectCoreDDD.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCoreDDD.Application.Dtos
{
    public class UserSysDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}