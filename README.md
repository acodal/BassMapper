# BassMapper
Simple Mapper between View Models and Data Entities.

<div>Using reflection to map properties.</div>
<div>Supports mapping between different types as long as it is possible to convert. Eg string <> int. decimal? <> decimal, etc.</div>
<div>All mappings is on ViewModel not on different place.</div>
<div>Best use cases are when you work with auto generated classes which you don't want to access directly </div>
<div>(Db generated classes, Web service's proxies, etc.)</div>
<br />
<br />
<div>Need to map your data entity to your View Models? You can easily do with BassMapper now.</div>
<br />
<div>Your View Model need to inherit either from EntityModelBase<TData> where TData is your Data Entity </div>
<div>or use more generic inteface IEntityModelBase<TData> if your View Models already inherits from other classes</div>
<br />
<div>There are also overrides EntityModelStandard<TData> and IEntityModelStandard<TData> which has default properties:</div>
        <div>int? ID { get; set; }</div>
        <div>DateTime? CreatedDate { get; set; }</div>
        <div>string CreatedBy { get; set; }</div>
        <div>DateTime? LastModifiedDate { get; set; }</div>
        <div>string LastModifiedBy { get; set; }</div>
        <br />
<div>Then to map each property just add [AutoMap] attribute on each property.</div>
<div>This attribute has few overrides which allows you specify name on Entity (if different to View Model) </div>
<div>And/or whether is read only to ensure that no one can update this property.</div>
<br />
<div>Then anywhere you want to map from/to entity use static class Mapper.</div>
<div>vm = Mapper.FromEntity(vm, data);</div>
<div>data = Mapper.ToEntity(vm, data);</div>
<div>or generic</div>
<div>to = Mapper.Map(from, to)</div>
