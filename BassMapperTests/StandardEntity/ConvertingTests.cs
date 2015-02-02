using System;
using System.Collections.Generic;
using BassMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BassMapperTests.StandardEntity
{
    [TestClass]
    public class ConvertingTests
    {
        private FakeDataEntity _data;

        private FakeVM _vm;

        [TestInitialize]
        public void Init()
        {
            _data = new FakeDataEntity
            {
                CreatedDate = DateTime.Today,
                CreatedBy = "testuser",
                LastModifiedDate = DateTime.Today,
                LastModifiedBy = "testuser",
                CurrentDate = DateTime.Now,
                ID = 10,
                IsDeleted = true,
                Name = "Fake Entity",
                RefID = 111,
                Item = new RefItem { Name = "Item Ref"},
                OneChild = new Child{Name = "Item Child"}
            };

            _vm = new FakeVM
            {
                CreatedDate = DateTime.Today,
                CreatedBy = "testuser",
                LastModifiedDate = DateTime.Today,
                LastModifiedBy = "testuser",
                CurrentDate = DateTime.Now,
                ID = 10,
                IsDeleted = true,
                Name = "Fake Entity",
                ReferenceID = 111,
                Children = new List<string> {"Test1", "Test2"},                
            };
        }

        [TestMethod]
        public void TestConvertFromDataAsBase()
        {
            var vm = new FakeVM();
            vm.AutoMapFrom(_data);
            FromDataAssert(vm);
        }

        [TestMethod]
        public void TestConvertFromDataWithMapperStatic()
        {
            var vm = new FakeVM();
            vm = Mapper.FromEntity(vm, _data);
            FromDataAssert(vm);
        }

        [TestMethod]
        public void TestConvertFromDataWithMapperDynamic()
        {
            var vm = new FakeVM();
            vm = Mapper.Map(_data, vm);
            FromDataAssert(vm);
        }

        [TestMethod]
        public void TestConvertToDataAsBase()
        {
            var data = _vm.AutoMapTo(new FakeDataEntity());
            ToDataAssert(data);
        }

        [TestMethod]
        public void TestConvertToDataWithMapperStatic()
        {
            var data = Mapper.ToEntity(_vm, new FakeDataEntity());
            ToDataAssert(data);
        }

        [TestMethod]
        public void TestConvertToDataWithMapperDynamic()
        {
            var data = Mapper.Map(_vm, new FakeDataEntity());
            ToDataAssert(data);
        }

        private void FromDataAssert(FakeVM vm)
        {
            Assert.AreEqual(vm.Name, _data.Name);
            Assert.AreEqual(vm.IsDeleted, _data.IsDeleted);
            Assert.AreEqual(vm.CreatedDate, _data.CreatedDate);
            Assert.AreEqual(vm.ID, _data.ID);
            Assert.AreEqual(vm.ReferenceID, _data.RefID);
            Assert.AreEqual(vm.CurrentDate, _data.CurrentDate);
            Assert.AreEqual(vm.RefItemName, _data.Item.Name);
            Assert.AreEqual(vm.Child.Name, _data.OneChild.Name);
        }

        private void ToDataAssert(FakeDataEntity data)
        {
            Assert.AreEqual(_vm.Name, data.Name);
            Assert.AreNotEqual(_vm.IsDeleted, data.IsDeleted);
            Assert.AreNotEqual(_vm.CreatedDate, data.CreatedDate);
            Assert.AreEqual(_vm.ID, data.ID);
            Assert.AreEqual(_vm.ReferenceID, data.RefID);
            Assert.AreEqual(_vm.CurrentDate, data.CurrentDate);
            Assert.AreEqual(_vm.Children.Count, data.ChildrenCount);
        }
    }
}