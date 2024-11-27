namespace AutomationFramework.API.Builders
{
    public static class PetBuilder
    {
        public static Pet BuildPetPayload(string name, string status, string category, string tags)
        {
            return new Pet
            {
                Name = name,
                Status = status,
                Category = new Category
                {
                    Id = new Random().Next(1, 100),
                    Name = category
                },
                Tags = new[]
                {
                    new Tag
                    {
                        Id = new Random().Next(1, 100),
                        Name = tags
                    }
                }
            };
        }
    }

    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Category Category { get; set; }
        public Tag[] Tags { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

