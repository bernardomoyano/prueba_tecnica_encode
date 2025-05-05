using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Dto;
using Data.Entity;
using Data.Parameters.Category;
using Data.Parameters.Product;

namespace Data.Mapper
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CategoryDto, Category>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PostCategoryRequest, Category>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, PostCategoryResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateCategoryRequest, Category>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, UpdateCategoryResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, DeleteCategoryResponse>()
                .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
