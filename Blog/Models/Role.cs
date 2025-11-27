using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public Role() { }
        [JsonConstructor]
        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
