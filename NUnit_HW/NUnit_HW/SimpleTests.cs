using System;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NUnit_HW
{
	[TestFixture]
	public class SimpleTests
	{
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		public void TestPow(int number)
		{
			var result = Math.Pow(number, 2);
			Assert.That(result, Is.EqualTo(number * number));
		}


		[TestCase(1, 5)]
		[TestCase(8, 15)]
		[TestCase(100, 200)]
		public void TestRandom(int x, int y)
		{
			var randomValue = new Random().Next(x, y);

			Assert.IsTrue(randomValue >= x);
			Assert.IsTrue(randomValue < y);
		}

		
		[TestCase("Hey", " man")]
		[TestCase("Just", " dance")]
		public void TestStrings(string str1, string str2)
		{
			var result = str1 + str2;

			Assert.That(result.Length, Is.EqualTo(str1.Length+str2.Length));
			Assert.That(result, Does.StartWith(str1));
			Assert.That(result, Does.EndWith(str2));
		}

		[TestCase("Let's")]
		[TestCase("imagine")]
		public void TestRevers(string str)
		{
			var result = str.Reverse();
			Assert.That(result, Is.EquivalentTo(str));
		}

	}
}
