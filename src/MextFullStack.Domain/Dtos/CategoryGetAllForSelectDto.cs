using MextFullStack.Domain.Entities;

namespace MextFullStack.Domain.Dtos
{
    public class CategoryGetAllForSelectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static CategoryGetAllForSelectDto FromCategory(Category category)
        {
            return new CategoryGetAllForSelectDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
