
using System.ComponentModel.DataAnnotations;

namespace OrderFoodCore.Core
{
    public class Restaurant //: IValidatableObject
    {
        public int Id { get; set; }
        
        [Required, StringLength(80)]
        public string Name { get; set; }
        
        [Required, StringLength(155)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
