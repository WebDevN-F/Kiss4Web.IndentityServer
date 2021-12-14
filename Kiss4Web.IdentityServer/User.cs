using System.ComponentModel.DataAnnotations;

namespace Kiss4Web.IdentityServer
{
    public class User
    {
        public static int xid;
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }

        public static void ResetId()
        {
            xid = 0;
        }

        public User(string firstName, string lastName, string userName, string passwordHash)
        {
            xid++;
            this.Id = xid;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
            this.PasswordHash = passwordHash;
        }
    }
}