# BassMapper
Simple Mapper between View Models and Data Entities.

Using reflection to map properties. 
Supports mapping between different types as long as it is possible to convert. Eg string <> int. decimal? <> decimal, etc.
All mappings is on ViewModel not on different place.
Best use cases are when you work with auto generated classes which you don't want to access directly 
(Db generated classes, Web service's proxies, etc.)

Need to map your data entity to your View Models? You can easily do with BassMapper now.

Your View Model need to inherit either from EntityModelBase<TData> where TData is your Data Entity 
or use more generic inteface IEntityModelBase<TData> if your View Models already inherits from other classes

There are also overrides EntityModelStandard<TData> and IEntityModelStandard<TData> which has default properties:
        int? ID { get; set; }
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
        string LastModifiedBy { get; set; }
        
Then to map each property just add [AutoMap] attribute on each property.
This attribute has few overrides which allows you specify name on Entity (if different to View Model) 
And/or whether is read only to ensure that no one can update this property.

Then anywhere you want to map from/to entity use static class Mapper.
vm = Mapper.FromEntity(vm, data);
data = Mapper.ToEntity(vm, data);
or generic
to = Mapper.Map(from, to)
