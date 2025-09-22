using System.ComponentModel.DataAnnotations;

namespace CMS_BE.Infrastructure.Data
{
    public class DatabaseSettings
    {
        [Required]
        public string? DatabaseConnection { get; set; }
    }
}
