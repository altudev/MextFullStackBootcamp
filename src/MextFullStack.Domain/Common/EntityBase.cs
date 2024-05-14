namespace MextFullStack.Domain.Common
{
    public abstract class EntityBase<TKey>
    {
        //public Guid Id { get; set; }
        public TKey Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedByUserId { get; set; } = "system";

        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

    }


}
