using System.Threading;
using System.Threading.Tasks;
using API.Domain.Product.Command;
using FluentValidation;
using FluentValidation.Results;

namespace API.Domain.Product.Validations
{
    public class UpdateProductValidation : ProductValidationBase<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateName();
            ValidateCost();
            ValidatePrice();
            ValidateQuantity();
        }
        
    }
}