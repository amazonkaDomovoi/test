using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkWithDiffrentStructures
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var input = "5+7*2-6/3";
			var postfixExpression = ConvertToPostfixExpression(input);
			var result = Calculate(postfixExpression);
			//Assert.AreEqual(17, result);
		}

		private double Calculate(Queue<char> postfixExpression)
		{
			//TODO: implement
			return 0;
		}

		public Queue<char> ConvertToPostfixExpression(string input)
		{
			var postfixExpression = new Queue<char>();
			var operators = new Stack<char>();

			foreach (var letter in input)
			{
				if (char.IsDigit(letter))
				{
					postfixExpression.Enqueue(letter);
				}
				else if (Operator.IsAvailable(letter))
				{
					if (operators.Count == 0 || Operator.GetPriopity(letter) > Operator.GetPriopity(operators.Peek()))
					{
						operators.Push(letter);
					}
					else
					{
						while (operators.Count > 0 && Operator.GetPriopity(letter) <= Operator.GetPriopity(operators.Peek()))
						{
							postfixExpression.Enqueue(operators.Pop());
						}
					}
				}
				else throw new NotImplementedException();
			}

			while (operators.Count > 0)
				postfixExpression.Enqueue(operators.Pop());

			return postfixExpression;
		}
	}

	public class Operator
	{
		private static readonly char[] AvailableOperators = { '+', '-', '*', '/' };
		public static int GetPriopity(char value)
		{
			switch (value)
			{
				case '+':
				case '-':
					{
						return 1;
					}
				case '*':
				case '/':
					{
						return 2;
					}
				default: throw new NotImplementedException();
			}

		}

		public static bool IsAvailable(Char value)
		{
			return AvailableOperators.Any(c => c.Equals(value));
		}
	}
}
