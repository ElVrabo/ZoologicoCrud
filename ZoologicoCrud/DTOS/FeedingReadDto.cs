using System.ComponentModel.DataAnnotations;

namespace ZoologicoCrud.DTOS
{
    public class FeedingReadDto
    {
        [Display(Name ="Tipo de alimentacion")]
        public string FeedType { get; set; }
    }
}
