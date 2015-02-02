using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BassMapper
{
    public abstract class EntityModelStandard<T> : EntityModelBase<T>, IEntityModelStandard where T : class
    {
        [AutoMap("ID")]        
        [Key]
        public int? ID { get; set; }

        [AutoMap("CreatedDate", true)]
        [DisplayName("Created Date")]        
        public DateTime? CreatedDate { get; set; }

        [AutoMap("CreatedBy", true)]
        [DisplayName("Created By")]        
        public string CreatedBy { get; set; }

        [AutoMap("LastModifiedDate", true)]
        [DisplayName("Last Modified Date")]        
        public DateTime? LastModifiedDate { get; set; }

        [AutoMap("LastModifiedBy", true)]
        [DisplayName("Last Modified By")]        
        public string LastModifiedBy { get; set; }
    }
}
