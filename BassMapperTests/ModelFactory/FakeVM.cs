using System;
using System.Collections.Generic;
using BassMapper;

namespace BassMapperTests.ModelFactory
{
    public class FakeVM : IEntityModelStandard<FakeDataEntity>
    {
        public FakeVM()
        {
            Children = new List<string>();
        }

        [AutoMap]
        public string Name { get; set; }

        [AutoMap("RefID")]
        public int? ReferenceID { get; set; }

        [AutoMap]
        public DateTime? CurrentDate { get; set; }

        [AutoMap(true)]
        public bool IsDeleted { get; set; }

        public bool HasTitle { get; set; }

        public List<string> Children { get; set; }

        public string RefItemName { get; set; }

        public ChildVM Child { get; set; }

        public void ConvertFromEntity(FakeDataEntity data)
        {
            HasTitle = !string.IsNullOrEmpty(data.Name);
            if (data.Item != null)
            {
                RefItemName = data.Item.Name;
            }
            if (data.OneChild != null)
            {
                Child = Mapper.FromEntity(new ChildVM(), data.OneChild);
            }  
        }

        
        public FakeDataEntity ConvertToEntity(FakeDataEntity data)
        {
            data.ChildrenCount = Children.Count;
            return data;
        }


        [AutoMap]
        public int? ID { get; set; }

        [AutoMap(true)]
        public DateTime? CreatedDate { get; set; }

        [AutoMap(true)]
        public string CreatedBy { get; set; }

        [AutoMap(true)]
        public DateTime? LastModifiedDate { get; set; }

        [AutoMap(true)]
        public string LastModifiedBy { get; set; }
        
    }
}
