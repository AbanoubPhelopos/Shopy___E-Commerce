namespace Shopy.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Categoty Name")]
        [MaxLength(80)]
        public string Name { get; set; }=string.Empty;
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
