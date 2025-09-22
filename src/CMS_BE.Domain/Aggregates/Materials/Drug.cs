using Ardalis.GuardClauses;
using CMS_BE.Domain.Aggregates.Humans;
using CMS_BE.Domain.Common;
using Mediator;

namespace CMS_BE.Domain.Aggregates.Materials
{
    public class Drug : AggregateRoot
    {
        public string Code { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } // Giá thuốc
        public decimal Stock { get; private set; } = 0; // Số lượng tồn kho

        // Mối quan hệ 1:N với Prescriptions
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<Unit> Units { get; set; } = new List<Unit>();

        public Drug() { }

        public Drug(string code, string name, decimal price)
        {
            Code = Guard.Against.NullOrEmpty(code, nameof(Code));
            Name = Guard.Against.NullOrEmpty(name, nameof(Name));
            Price = Guard.Against.NegativeOrZero(price, nameof(Price));
        }

        public void Update(string? code = null, string? name = null, decimal? price = null)
        {
            if (!string.IsNullOrEmpty(code))
                Code = code;
            if (!string.IsNullOrEmpty(name))
                Name = name;
            if (price.HasValue)
                Price = Guard.Against.NegativeOrZero(price.Value, nameof(Price));
        }

        public void UpdateStock(decimal quantity)
        {
            var newStock = Stock + quantity;
            Stock = Guard.Against.Negative(newStock, nameof(Stock));
        }

        protected override bool TryApplyDomainEvent(INotification domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
