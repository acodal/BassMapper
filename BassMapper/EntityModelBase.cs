namespace BassMapper
{
    public abstract class EntityModelBase
    {         
    }

    public abstract class EntityModelBase<T> : EntityModelBase, IEntityModelBase<T> where T : class
    {
        public void AutoMapFrom(T data)
        {
            Mapper.ConvertByAttribute(this, data, true);
            ConvertFromEntity(data);
        }

        public T AutoMapTo(T data)
        {
            data = (T)Mapper.ConvertByAttribute(this, data, false);            
            return ConvertToEntity(data);
        }

        public abstract void ConvertFromEntity(T data);
        public abstract T ConvertToEntity(T data);

       
    }
}
