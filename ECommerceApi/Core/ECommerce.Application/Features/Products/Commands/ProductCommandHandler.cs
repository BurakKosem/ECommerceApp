using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IUnitofWork _unitofWork;

        public CreateProductCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            CreateProductCommandResponse response = new();
            Product product = new(request.Name, request.Description, request.BrandId, request.Price, request.Discount);

            await _unitofWork.GetWriteRepository<Product>().AddAsync(product);
            var result = await _unitofWork.SaveAsync();
            if(result > 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await _unitofWork.GetWriteRepository<CategoryProduct>().AddAsync(new CategoryProduct { CategoryId = categoryId, ProductId = product.Id });
                    await _unitofWork.SaveAsync();
                }
            }

            return response;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IUnitofWork _unitofWork;

        public UpdateProductCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateProductCommandResponse response = new();
            var product = await _unitofWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id, 
                                                            include: p => p.Include(p => p.Brand)
                                                               .Include(p => p.CategoryProducts)
                                                               .ThenInclude(cp => cp.Category));

            product.Name = request.Name;
            product.Description = request.Description;
            product.BrandId = request.BrandId;
            product.Price = request.Price;
            product.Discount = request.Discount;

            _unitofWork.GetWriteRepository<CategoryProduct>().DeleteRange(product.CategoryProducts.ToList());

            foreach(var caregoryId in request.CategoryIds)
            {
                await _unitofWork.GetWriteRepository<CategoryProduct>().AddAsync(new()
                {
                    CategoryId = caregoryId,
                    ProductId = product.Id
                });
            }

             _unitofWork.GetWriteRepository<Product>().Update(product);
            await _unitofWork.SaveAsync();

            return response;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IUnitofWork _unitofWork;

        public DeleteProductCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteProductCommandResponse response = new();

            var product = await _unitofWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id,
                                                            include: p => p.Include(p => p.Brand)
                                                               .Include(p => p.CategoryProducts)
                                                               .ThenInclude(cp => cp.Category));

            _unitofWork.GetWriteRepository<Product>().Delete(product);
            await _unitofWork.SaveAsync();
            return response;
        }
    }
}
