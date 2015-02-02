using System;

namespace BassMapper
{
    public interface IEntityModelStandard
    {
        int? ID { get; set; }
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
        string LastModifiedBy { get; set; }
    }

    public interface IEntityModelStandard<T> : IEntityModelBase<T>, IEntityModelStandard
    {
        
    }
}
