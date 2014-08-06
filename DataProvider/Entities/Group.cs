namespace SimpleWiki.DataProvider.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Group")]
    public class Group
    {
        public Group()
        {
            this.UserFriends = new HashSet<UserFriend>();
        }
    
        [Key]
        public int GroupID { get; set; }

        [MaxLength(30)]
        public string GroupName { get; set; }

        //[Index]
        //public int OwnedUser { get; set; }

        [MaxLength(200)]
        public string Remark { get; set; }

        [Index]
        public virtual User OwnedUser { get; set; }

        public virtual ICollection<UserFriend> UserFriends { get; set; }
    }
}
