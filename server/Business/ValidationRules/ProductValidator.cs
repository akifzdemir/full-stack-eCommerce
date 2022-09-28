using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MaximumLength(100).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(500).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UsingStatusId).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();

        }
    }
}
