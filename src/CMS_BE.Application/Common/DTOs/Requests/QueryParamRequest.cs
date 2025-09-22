using System.Text.Json.Serialization;
using CMS_BE.Application.Common.Binds;
using Microsoft.AspNetCore.Mvc;

namespace CMS_BE.Application.Common.DTOs.Requests
{
    public class QueryParamRequest
    {
        /// <summary>
        /// The current page
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Maximum items that display per page
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// Cursor pagination
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// Fields want to search for
        /// </summary>
        public List<string>? Targets { get; set; }

        /// <summary>
        /// example : Sort=Age:desc,Name:asc
        /// default is asc
        /// </summary>
        public string? Sort { get; set; }
        public object? Filter { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ModelBinder(BinderType = typeof(FilterModelBinder))]
        public string[]? OriginFilters { get; set; }
    }
}
