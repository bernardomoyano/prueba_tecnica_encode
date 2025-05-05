using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Dto;
using Data.Entity;
using Data.Parameters.Product;

namespace Data.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductDto, Product>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PostProductRequest, Product>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, PostProductResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateProductRequest, Product>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, UpdateProductResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, DeleteProductResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
