using Microsoft.AspNetCore.Identity;

namespace ToDoList.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string HashedPassword { get; set; }

        public User(string name, string hashedPassword)
        {
            Name = name;
            HashedPassword = hashedPassword;
        }
        
        public User()
        {

        }
    }
}
