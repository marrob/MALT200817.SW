
namespace MALT200817.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum UserRole
    {
        OPERATOR,
        ADMINISTRATOR,
        DEVELOPER,
    }

    public class UserItem
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserCollection : List<UserItem>
    {

    }
}
