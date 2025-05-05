using medicine_receipt_service.Enums;

namespace medicine_receipt_service.Domain.Entities
{
    public class UsersEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
