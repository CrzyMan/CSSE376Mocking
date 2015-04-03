using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expedia;
using Rhino.Mocks;
using System.Reflection;

namespace ExpediaTest
{
	[TestClass]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[TestInitialize]
		public void TestInitialize()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[TestMethod]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[TestMethod]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [TestMethod]
        public void TestThatCarDoesGetCarLocationFromDatabase()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();
            
            var carNumber = 10;
            String carLocation = "Valhala";

            Expect.Call(mockDB.getCarLocation(carNumber)).Return(carLocation);

            mocks.ReplayAll();

            Car target = new Car(10);
            target.Database = mockDB;

            String result = target.getCarLocation(carNumber);
            Assert.AreEqual(result, carLocation);

            mocks.VerifyAll();
        }

        [TestMethod]
        public void TestThatCarDoesMileageFromDatabase()
        {
            IDatabase mockDB = mocks.StrictMock<IDatabase>();

            Int32 carMileage = 10;

            Expect.Call(mockDB.Miles).PropertyBehavior();

            mocks.ReplayAll();

            mockDB.Miles = carMileage;

            Car target = new Car(10);
            target.Database = mockDB;

            Int32 result = target.Mileage;
            Assert.AreEqual(result, carMileage);

            mocks.VerifyAll();
        }

        [TestMethod]
        public void TestBMWHasCorrectName()
        {
            var target = ObjectMother.BMW();
            Assert.AreEqual("BMW", target.Name);
        }
	}
}
