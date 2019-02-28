using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecurRevString
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter string to check it is palindrome or not : ");
			Console.WriteLine("Enter the word exit to exit the program.");
			string word = Console.ReadLine();
			bool yesItIs;  // is it a Palindrome?
			word = word.ToLower(); // force to lower case

			while (word != "exit")
			{
				if (word == RecStingRevPub(word))  // compare the input to the string returned from the method
				{
					yesItIs = true;
				}
				else
				{
					yesItIs = false;
				}
				if (yesItIs)
					Console.WriteLine("{0} is a Palindrome string\n", word);
				else
					Console.WriteLine("{0} is not a Palindrome string\n", word);
				// do it again
				Console.WriteLine("Enter string to check it is palindrome or not : ");
				Console.WriteLine("Enter the word exit to exit the program.");
				word = Console.ReadLine();
				word = word.ToLower(); // force to lower case
			}
			Console.WriteLine("Goodbye.");
			Console.ReadLine();
		}
		
		public static string RecStingRevPub(string input)
		{
			if (input.Length > 0)
				return input[input.Length - 1] + RecStingRevPub(input.Substring(0, input.Length - 1));
			else
				return input;
		}
	}
}
