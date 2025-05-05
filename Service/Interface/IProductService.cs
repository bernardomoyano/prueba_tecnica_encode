using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Data.Parameters.Category;
using Data.Parameters.Product;

namespace Service.Interface
{
    public interface IProductService
    {
        Task<PostProductResponse> Post(PostProductRequest request);
        Task<UpdateProductResponse> Update(UpdateProductRequest request);
        Task<GetAllProductsResponse> GetAll();
        Task<GetProductByIdResponse> GetById(GetProductByIdRequest request);
        Task<DeleteProductResponse> Delete(DeleteProductRequest request);
        Task<List<Product>> GetProductsByCategory(int idCategory);
    }
}
