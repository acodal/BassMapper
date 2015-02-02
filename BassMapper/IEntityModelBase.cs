namespace BassMapper
{
    public interface IEntityModelBase<T>
    {
        void ConvertFromEntity(T data);
        T ConvertToEntity(T data);
    }
}