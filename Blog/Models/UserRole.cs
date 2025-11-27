using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public UserRole() { }
        [JsonConstructor]
        public UserRole(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
