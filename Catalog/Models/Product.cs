namespace Models;

public class Product
{
    public int Id { get; set; }
    public string GroupCode { get; set; }
    public string Title { get; set; } 
    public string Description { get; set; }
    public float Price { get; set; }
    public string Thumbnail { get; set; }
    public List<string> Images { get; set; }
    public List<Feature> Features { get; set; }
    public int Stock { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }

    public string Color { get; set; }
}