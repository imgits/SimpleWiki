//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleWiki.DataProvider.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Role
    {
        public static Role NormalRole = new Role { RoleID = 1, RoleName = "user" };

        public static Role AnonymousRole = new Role { RoleID = -1, RoleName = "anonymous" };

        public static Role OperatorRole = new Role { RoleID = 2, RoleName = "operator" };

        public static Role SuperRole = new Role { RoleID = 3, RoleName = "su" };

        public Role()
        {
            this.Users = new HashSet<User>();
        }
    
        [Key]
        public int RoleID { get; set; }

        [MaxLength(10)]
        public string RoleName { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}