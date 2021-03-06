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
    
    public class UserFriend
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserFriendID { get; set; }

        [MaxLength(50)]
        public string Remark { get; set; }

        public int GroupID { get; set; }

        [ForeignKey("GroupID")]
        public virtual Group Group { get; set; }

        public int MasterID { get; set; }

        [ForeignKey("MasterID")]
        public virtual User Master { get; set; }

        public int FriendID { get; set; }
        
        [ForeignKey("FriendID")]
        public virtual User Friend { get; set; }
    }
}
