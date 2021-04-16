
using System.ComponentModel.DataAnnotations.Schema;


namespace HRBCloud.CloudUtil.Data.Entities
{
    [Table("tbleUsers")]
    public class Users
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
    }
}
