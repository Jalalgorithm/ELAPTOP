﻿using Core.Interfaces;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELAPTOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var product = await _repo.GetProductsAsync();

            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var prodcutBrands =  await _repo.GetProductBrandsAsync();

            return Ok(prodcutBrands);
        }

        [HttpGet("types")]

        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            var productTypes = await _repo.GetProductTypesAsync();

            return Ok(productTypes);
        }


    }
}
