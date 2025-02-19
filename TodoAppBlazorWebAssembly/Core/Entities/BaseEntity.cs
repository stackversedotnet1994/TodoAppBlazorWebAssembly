using System.ComponentModel.DataAnnotations;

namespace TodoAppBlazorWebAssembly.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
