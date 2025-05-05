using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Dto;
using Data.Entity;
using Data.Exceptions;
using Data.Parameters.Product;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRespository _repository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRespository repository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<DeleteProductResponse> Delete(DeleteProductRequest request)
        {
            Product product = await _repository.GetByIdAsync(request.IdProduct);
            await _repository.Delete(product);
            var response = _mapper.Map<DeleteProductResponse>(product);
            return response;
        }

        public async Task<GetAllProductsResponse> GetAll()
        {
            List<Product> products = await _repository.GetAllAsync();
            var response = new GetAllProductsResponse()
            {
                Products = _mapper.Map<List<ProductDto>>(products)
            };
            return response;
        }

        public async Task<GetProductByIdResponse> GetById(GetProductByIdRequest request)
        {
            Product product = await _repository.GetByIdAsync(request.IdProduct);
            var response = new GetProductByIdResponse()
            {
                Product = _mapper.Map<ProductDto>(product)
            };
            return response;
        }

        public async Task<PostProductResponse> Post(PostProductRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundCategoryException();
            }
            Product product = _mapper.Map<Product>(request);
            await _repository.Insert(product);
            var response = _mapper.Map<PostProductResponse>(product);
            return response;
        }

        public async Task<UpdateProductResponse> Update(UpdateProductRequest request)
        {
            Product product = _mapper.Map<Product>(request);
            await _repository.Update(product);
            var response = new UpdateProductResponse()
            {
                Product = _mapper.Map<ProductDto>(product)
            };
            return response;
        }

        public async Task<List<Product>> GetProductsByCategory(int idCategory)
        {
            var products = await _repository.GetAllAsync();
            var response = products.Where(p => p.CategoryId == idCategory).ToList();
            return response;
        }
    }
}
