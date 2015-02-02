using System;

namespace BassMapperTests
{
    public class FakeDataEntity
    {
        public string Name { get; set; }

        public int RefID { get; set; }

        public DateTime CurrentDate { get; set; }

        public bool IsDeleted { get; set; }

        public int ChildrenCount { get; set; }

        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public RefItem Item { get; set; }
        public Child OneChild { get; set; }
    }
}
