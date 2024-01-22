using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandSpecification :BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandSpecification(ProductSpecParams productSpec)
            : base(x =>
            (!productSpec.BrandId.HasValue || x.ProductBrandId==productSpec.BrandId )&&
            (!productSpec.TypeId.HasValue || x.ProductTypeId==productSpec.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);

            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch(productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price); 
                        break;
                    case "priceDesc":
                        AddOrderBy(p=>p.Price); 
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }
        }

        public ProductWithTypesAndBrandSpecification(int id) 
            : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}
