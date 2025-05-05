using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Parameters.Category;

namespace Service.Interface
{
    public interface ICategoryService
    {
        Task<PostCategoryResponse> Post(PostCategoryRequest request);
        Task<UpdateCategoryResponse> Update(UpdateCategoryRequest request);
        Task<GetAllCategoriesResponse> GetAll();
        Task<GetCategoryByIdResponse> GetById(GetCategoryByIdRequest request);
        Task<DeleteCategoryResponse> Delete(DeleteCategoryRequest request);
    }
}
