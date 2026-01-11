using MyAppService.Domain.Common;

namespace MyAppService.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
