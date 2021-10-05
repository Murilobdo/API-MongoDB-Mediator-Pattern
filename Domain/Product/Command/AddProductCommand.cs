using System;
using System.Collections.Generic;
using API.Domain.Product.Validations;
using API.Extensions;
using FluentValidation.Results;
using MediatR;

namespace API.Domain.Product.Command
{
    public class AddProductCommand : ProductBaseCommand, IRequest<string>
    {
        public AddProductCommand()
        {
            
        }

        internal bool isValid() => 
            new AddProductValidation().Validate(this).IsValid;
        internal string ShowMessagesValidations() => 
            new AddProductValidation().Validate(this).Errors.GetMessageValidation();
    }
}