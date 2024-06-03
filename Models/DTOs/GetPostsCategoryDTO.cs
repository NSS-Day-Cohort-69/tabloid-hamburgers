namespace Tabloid.Models;

public class GetPostsCategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public GetPostsCategoryDTO(Category category)
    {
        Id = category.Id;
        CategoryName = category.CategoryName;
    }
}
