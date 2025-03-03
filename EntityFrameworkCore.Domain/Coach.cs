using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Domain
{
    public class Coach : BaseDomainModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public virtual Team? TeamId { get; set; }
    }
}
