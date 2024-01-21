using AutoMapper;
using Core.Interfaces;
using Core.Model;
using Core.Specifications;
using ELAPTOP.Dtos;
using ELAPTOP.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELAPTOP.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productrepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productrepo , 
            IGenericRepository<ProductType> productTypeRepo , 
            IGenericRepository<ProductBrand> productBrandRepo , IMapper mapper)
        {
            this.productrepo = productrepo;
            this.productTypeRepo = productTypeRepo;
            this.productBrandRepo = productBrandRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProduct(string sort , int? brandId , int? typeId)
        {
            var spec = new ProductWithTypesAndBrandSpecification(sort , brandId , typeId);

            var product = await productrepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(product));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),  StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWithTypesAndBrandSpecification(id);
            var product = await productrepo.GetEntityWithSpec(spec);

            if (product == null)
                return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);

        }

        [HttpGet("brands")]

        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var prodcutBrands = await productBrandRepo.ListAllAsync();

            return Ok(prodcutBrands);
        }

        [HttpGet("types")]

        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            var productTypes = await productTypeRepo.ListAllAsync();

            return Ok(productTypes);
        }


    }
}
