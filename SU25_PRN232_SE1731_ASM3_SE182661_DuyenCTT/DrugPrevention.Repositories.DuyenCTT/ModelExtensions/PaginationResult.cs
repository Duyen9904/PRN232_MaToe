
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.DuyenCTT.ModelExtensions
{
    public class PaginationResult<T>
    {
        public List<T> Items { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages { get; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginationResult(List<T> items, int totalItems, int pageIndex, int pageSize)
        {
            Items = items ?? new List<T>(); // Ensure Items is never null
            TotalItems = totalItems;
            PageIndex = pageIndex; // Should be validated to be >= 1 before this point
            PageSize = pageSize;   // Should be validated to be >= 1 before this point

            if (totalItems == 0 || pageSize == 0) // pageSize should not be 0 if validated
            {
                TotalPages = 0;
            }
            else
            {
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            }
        }
    }
}
