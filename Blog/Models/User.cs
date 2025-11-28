using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        public List<Role> Roles { get; private set; } = new();

        public User() { }

        [JsonConstructor]
        public User(string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }

        [JsonConstructor]
        public User(int id, string name, string email, string passwordHash, string bio, string image, string slug)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Bio = bio;
            Image = image;
            Slug = slug;
        }

        public void SetRoles(Role role)
        {
            Roles.Add(role);
        }
    }
}
