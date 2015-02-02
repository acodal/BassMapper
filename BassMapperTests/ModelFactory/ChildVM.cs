using BassMapper;

namespace BassMapperTests.ModelFactory
{
    public class ChildVM : IEntityModelBase<Child>
    {
        [AutoMap]
        public string Name { get; set; }

        public void ConvertFromEntity(Child data)
        {
        }

        public Child ConvertToEntity(Child data)
        {
            return data;
        }
    }
}