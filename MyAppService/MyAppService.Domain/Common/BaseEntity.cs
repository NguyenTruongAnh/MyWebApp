namespace MyAppService.Domain.Common
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedById { get; set; }
    }
}
