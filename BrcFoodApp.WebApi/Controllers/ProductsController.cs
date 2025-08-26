using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrcFoodApp.WebApi.Context;
using BrcFoodApp.WebApi.Dtos.ProductDtos;
using BrcFoodApp.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrcFoodApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _apiContext;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext apiContext, IMapper mapper)
        {
            _validator = validator;
            _apiContext = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductsList()
        {
            var values = _apiContext.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validatorResult = _validator.Validate(product);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.Products.Add(product);
                _apiContext.SaveChanges();
                return Ok(new { message = "Eklme işlemi başarılı", data = product });
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _apiContext.Products.Find(id);
            _apiContext.Products.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetByProductId")]
        public IActionResult GetByProductId(int id)
        {
            var value = _apiContext.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validatorResult = _validator.Validate(product);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _apiContext.Products.Update(product);
                _apiContext.SaveChanges();
                return Ok(new { message = "Güncelleme işlemi başarılı", data = product });
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto productDto)
        {
            var value = _mapper.Map<Product>(productDto);
            _apiContext.Add(value);
            _apiContext.SaveChanges();
            return Ok("Ekleme işlemi başarılı.");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var products = _apiContext.Products.Include(x => x.Category);
            var value = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            return Ok(value);
        }
    }
}