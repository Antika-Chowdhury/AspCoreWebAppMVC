using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreWebAppMVC.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PdfBase64Data { get; set; }

        public string PdfFileName { get; set; }

        [NotMapped]
        public IFormFile PdfFile { get; set; }
    }
}
