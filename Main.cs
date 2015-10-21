using System;
using System.Collections.Generic;

namespace LiteCsvParser
{
	class MainClass
	{
		public static void TestWrite()
		{
			using (var writer = new CsvFileWriter("Test.csv"))
			{
				// Write each row of data
				for (int row = 0; row < 10; row++)
				{
					List<string> fields = new List<string>();
					// TODO: Populate column values for this row
					for(int j=0; j<5; j++) {
						fields.Add("" + j);
					}

					writer.WriteRow(fields);
				}
			}
		}
		
		public static void TestRead()
		{
			List<string> fields = new List<string>();
			using (var reader = new CsvFileReader("Test.csv"))
			{
				while (reader.ReadRow(fields))
				{
					// TODO: Do something with columns' values
					foreach(string field in fields) {
						Console.Write("\t" + field);
					}
					Console.Write("\n");
				}
			}
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			TestWrite ();

			TestRead ();
		}
	}
}
