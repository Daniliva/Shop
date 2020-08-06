using Shop.Data.Model;
using System.Collections.Generic;

namespace Shop.Data.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}