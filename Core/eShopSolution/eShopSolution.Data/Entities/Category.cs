﻿using eShopSolution.Data.Enum;
using System.Collections.Generic;

namespace eShopSolution.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }

        public int SortOrder { set; get; }

        public bool IsShowOnHome { set; get; }

        public int? ParentId { set; get; }

        public Status Status { set; get; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}