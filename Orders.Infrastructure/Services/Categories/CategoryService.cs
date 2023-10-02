﻿using AutoMapper;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(OrdersDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> GetAll(string serachKey)
        {
            var categories = _db.categaories.Where(x => x.Name.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                MealsCount = _db.meals.Count(x => x.CategaoryId == x.Id)

            }).ToList();
            return categories;

        }
        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _db.categaories.Add(category);
            _db.SaveChanges();
            return category.Id;

        }
        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = _db.categaories.SingleOrDefault(x => x.Id == dto.Id);
            if (category == null)
            {
                //throw 
            }
            var UpdateCategory = _mapper.Map(dto, category);
            _db.categaories.Update(UpdateCategory);
            _db.SaveChanges();
            return category.Id;
        }
        public async Task<int> Delete(int id)
        {
            var category = _db.categaories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new Exception();
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            category.IsDelete = true;
            _db.categaories.Update(category);
            _db.SaveChanges();
            return category.Id;
        }
        public async Task<CategoryViewModel> Get(int id)
        {
            var category = _db.categaories.SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                //throw 
            }
            var categoryVm = _mapper.Map<CategoryViewModel>(category);
            categoryVm.MealsCount = _db.meals.Count(x => x.CategaoryId == category.Id);
            return categoryVm;
        }
    }

}
