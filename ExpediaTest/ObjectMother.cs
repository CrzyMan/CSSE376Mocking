using Expedia;
using System;

namespace ExpediaTest
{
	public class ObjectMother
	{
        public static Car Saab()
        {
            return new Car(7) { Name = "Saab 9-5 Sports Sedan" };
        }

        public static Car BMW()
        {
            return new Car(10) { Name = "BMW" };
        }

        public static Flight flight(int length)
        {
            return new Flight(new DateTime(2009, 11, 1), new DateTime(2009, 11, 30), length);
        }
	}
}
