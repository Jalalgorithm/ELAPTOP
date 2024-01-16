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
        public ProductWithTypesAndBrandSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductWithTypesAndBrandSpecification(int id) 
            : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}
