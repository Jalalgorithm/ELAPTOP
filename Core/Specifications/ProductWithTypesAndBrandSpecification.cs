﻿using Core.Model;
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
        public ProductWithTypesAndBrandSpecification(string sort, int? brandId , int? typeId)
            : base(x =>
            (!brandId.HasValue || x.ProductBrandId==brandId )&&
            (!typeId.HasValue || x.ProductTypeId==typeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort)
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
