using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DrugPrevention.Repositories.DuyenCTT.SoapModels
{
    /// <summary>
    /// Represents paginated results for a SOAP service.
    /// </summary>
    [DataContract]
    public class PaginationResultSoapModel<T>
    {
        /// <summary>
        /// Gets or sets the list of items in the current page.
        /// </summary>
        [DataMember(Order = 1)]
        public List<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the current page index (starting from 1).
        /// </summary>
        [DataMember(Order = 2)]
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the number of items per page.
        /// </summary>
        [DataMember(Order = 3)]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        [DataMember(Order = 4)]
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        [DataMember(Order = 5)]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;

        /// <summary>
        /// Default constructor for serialization.
        /// </summary>
        public PaginationResultSoapModel() { }

        /// <summary>
        /// Constructs a new paginated result.
        /// </summary>
        public PaginationResultSoapModel(List<T> items, int totalItems, int pageIndex, int pageSize)
        {
            Items = items ?? new List<T>();
            TotalItems = totalItems;
            PageIndex = pageIndex;
            PageSize = pageSize;

            TotalPages = (totalItems == 0 || pageSize == 0)
                ? 0
                : (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}
