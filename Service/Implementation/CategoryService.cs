using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Dto;
using Data.Entity;
using Data.Exceptions;
using Data.Parameters.Category;
using Data.Parameters.Product;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper, IProductService productService)
        {
            _repository = repository;
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<DeleteCategoryResponse> Delete(DeleteCategoryRequest request)
        {
            Category category = await _repository.GetByIdAsync(request.IdCategory);
            var productsByCategory = await _productService.GetProductsByCategory(request.IdCategory);
            if (productsByCategory.Count() > 0 )
            {
                throw new CategoryDeletionException(category.Name);
            }
            await _repository.Delete(category);
            var response = _mapper.Map<DeleteCategoryResponse>(category);
            return response;
        }

        public async Task<GetAllCategoriesResponse> GetAll()
        {
            List<Category> categories = await _repository.GetAllAsync();
            var response = new GetAllCategoriesResponse()
            {
                Categories = _mapper.Map<List<CategoryDto>>(categories)
            };
            return response;
        }

        public async Task<GetCategoryByIdResponse> GetById(GetCategoryByIdRequest request)
        {
            Category category = await _repository.GetByIdAsync(request.IdCategory);
            var response = new GetCategoryByIdResponse()
            {
                Category = _mapper.Map<CategoryDto>(category)
            };
            return response;
        }

        public async Task<PostCategoryResponse> Post(PostCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
            await _repository.Insert(category);
            var response = _mapper.Map<PostCategoryResponse>(category);
            return response;
        }

        public async Task<UpdateCategoryResponse> Update(UpdateCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
            await _repository.Update(category);
            var response = _mapper.Map<UpdateCategoryResponse>(category);
            return response;
        }
    }
}
