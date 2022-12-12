﻿using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductAsync(int categoryid);
    }
}
