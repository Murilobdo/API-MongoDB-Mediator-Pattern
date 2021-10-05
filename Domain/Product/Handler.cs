using System;
using System.Threading;
using System.Threading.Tasks;
using API.Domain.Product.Command;
using API.Models;
using API.Interfaces;
using AutoMapper;
using MediatR;
using API.Extensions;
using API.Domain.Product.Validations;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace API.Domain.Product
{
    public class Handler : 
        IRequestHandler<AddProductCommand, string>,
        IRequestHandler<UpdateProductCommand, string>,
        IRequestHandler<DeleteProductCommand, string>,
        IRequestHandler<ListProductCommand, List<ListProductCommand>>
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public Handler(IProductRepository repo, IMediator mediator, IMapper mapper)
        {
            _repository = repo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if(!request.isValid())
                return await Task.FromResult(request.ShowMessagesValidations());

            if(_repository.IfExist(request.Name))
                return await Task.FromResult("Ja existe um produto cadastrado com esse nome.");
            
            _repository.AddProduct(_mapper.Map<ProductEntity>(request));
            return await Task.FromResult("Produto cadastro com sucesso.");
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == string.Empty)
                return await Task.FromResult("Um Id inválido foi fornecido, não e possível efetuar a ação.");

            _repository.DeleteProduct(new ObjectId(request.Id));
            return await Task.FromResult("Produto excluído com sucesso.");
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if(!request.isValid())
                return await Task.FromResult(request.ShowMessagesValidations());
                
            _repository.UpdateProduct(_mapper.Map<ProductEntity>(request));
            return await Task.FromResult("Produto alterado com sucesso.");
        }

        public async Task<List<ListProductCommand>> Handle(ListProductCommand request, CancellationToken cancellationToken)
        {
            var resultado = _repository.ToList();
            var resultadoMapper = resultado.Select(p => _mapper.Map<ListProductCommand>(p));
            return resultadoMapper.ToList();
        }
    }
}