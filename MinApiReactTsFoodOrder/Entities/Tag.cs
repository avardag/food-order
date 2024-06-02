namespace MinApiReactTsFoodOrder.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Food> Foods { get; set; }
}