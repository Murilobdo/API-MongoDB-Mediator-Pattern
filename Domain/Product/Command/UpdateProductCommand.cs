using API.Domain.Product.Validations;
using API.Extensions;
using MediatR;

namespace API.Domain.Product.Command
{
    public class UpdateProductCommand : ProductBaseCommand, IRequest<string>
    {
        public UpdateProductCommand()
        {
            
        }
        
        public string Id { get; set; }
        internal bool isValid() => 
            new UpdateProductValidation().Validate(this).IsValid;
        internal string ShowMessagesValidations() => 
            new UpdateProductValidation().Validate(this).Errors.GetMessageValidation();
    }
}