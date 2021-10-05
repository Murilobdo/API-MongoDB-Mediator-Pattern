using API.Domain.Product.Command;
using API.Models;
using FluentValidation;

namespace API.Domain.Product.Validations
{
    public class ProductValidationBase<T> : AbstractValidator<T> where T : ProductBaseCommand
    {
        // protected void ValidateId() =>
        //     RuleFor(p => p.).NotEmpty().WithMessage("Nenhum id foi fornecido para a atualização");
        protected void ValidateName() => 
            RuleFor(p => p.Name).NotEmpty().WithMessage("O nome do produto não pode ser vazio.");
        protected void ValidatePrice() => 
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("O preço do produto tem que ser maior que 0.");
        protected void ValidateCost() => 
            RuleFor(p => p.Cost).GreaterThan(0).WithMessage("O preço de custo do produto tem que ser maior que 0.");
        protected void ValidateQuantity() => 
            RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("A quantiade do produto tem que ser maior que 0.");
    }
}