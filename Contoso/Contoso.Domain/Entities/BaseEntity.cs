namespace Contoso.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; private set; }
        public DateTime? LastUpdated { get; private set; }
        public bool IsDeleted { get; private set; }

        public BaseEntity()
        {
            LastUpdated = DateTime.Now;
            CreatedDate ??= LastUpdated;
        }
    }
}
