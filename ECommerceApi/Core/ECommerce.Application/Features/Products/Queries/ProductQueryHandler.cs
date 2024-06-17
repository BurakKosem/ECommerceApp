using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.Queries
{
    public class ProductQueryHandler
    {
        //GetAllProducts
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
        {
            private readonly IUnitofWork _unitofWork;

            public GetAllProductsQueryHandler(IUnitofWork unitofWork)
            {
                _unitofWork = unitofWork;
            }

            public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
            {

                var products = await _unitofWork.GetReadRepository<Product>()
                                    .GetAllAsync(include: p => p.Include(p => p.Brand)
                                                               .Include(p => p.CategoryProducts)
                                                               .ThenInclude(cp => cp.Category));

                var response = products.Select(product => new GetAllProductsQueryResponse
                {
                    Name = product.Name,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price - (product.Price * product.Discount / 100),
                    BrandName = product.Brand?.Name,
                    Categories = product.CategoryProducts.Select(cp => cp.Category?.Name).ToList()
                }).ToList();

                return response;
            }
        }
    }

}
