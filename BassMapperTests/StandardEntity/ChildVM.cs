using BassMapper;

namespace BassMapperTests.StandardEntity
{
    public class ChildVM : EntityModelBase<Child>
    {
        [AutoMap]
        public string Name { get; set; }

        public override void ConvertFromEntity(Child data)
        {            
        }

        public override Child ConvertToEntity(Child data)
        {
            return data;
        }
    }
}