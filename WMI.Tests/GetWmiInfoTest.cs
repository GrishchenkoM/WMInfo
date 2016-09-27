using Core;
using NUnit.Framework;


namespace WMI.Tests
{
    // working only with NUnit version 2.6.3.13283
    // run the command in the Package Manager Console:
    // Install-Package NUnit -Version 2.6.3
    [TestFixture]
    public class GetWmiInfoTest
    {
        [SetUp]
        public void SetUp()
        {
            _model = new WmInfo().GetInfo();
        }

        [Test]
        public void GetInfo_Manufacturer_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.Manufacturer.Name);
        }

        [Test]
        public void GetInfo_ComputerName_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.Computer.Name);
        }

        [Test]
        public void GetInfo_UserNames_IsNotEmpty_Test()
        {
            Assert.IsNotEmpty(_model.Users);
        }

        EntitiesModel _model;
    }
}
