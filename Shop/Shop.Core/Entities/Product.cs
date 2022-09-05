
public class Product : BaseEntity
{
    public string Name { get; set; }
    public string State { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
}

