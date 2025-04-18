namespace StoreApp.Data.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url {get; set; } = string.Empty;  // Phone => phone - Pc => pc
    public List<Product> Products { get; set; } = new List<Product>();

}