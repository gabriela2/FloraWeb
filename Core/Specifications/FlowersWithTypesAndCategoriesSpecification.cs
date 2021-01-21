using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class FlowersWithTypesAndCategoriesSpecification : BaseSpecification<Flower>
    {
        public FlowersWithTypesAndCategoriesSpecification()
        {
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
        }

        public FlowersWithTypesAndCategoriesSpecification(int id) : base(x => x.Id == id)
        { 
            AddInclude(x => x.FlowerType);
            AddInclude(x => x.FlowerCategory);
        }
    }
}




