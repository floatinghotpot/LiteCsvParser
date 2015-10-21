using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace LiteCsvParser
{
	class MainClass
	{
		public static void TestWrite()
		{
			using (var writer = new CsvFileWriter("test.csv"))
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
			using (var reader = new CsvFileReader("test.csv"))
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

			if (args.Length < 2) {
				Console.WriteLine( "Sytnax: LiteCsvParser <input_file> <output_file>" );
				return;
			}

			List<List<string>> dataGrid = new List<List<string>> ();

			using( var sr = new StreamReader (args [0], Encoding.GetEncoding ("gbk"))) {
				var reader = new CsvFileReader(sr);
				List<string> row = new List<string>();
				while (reader.ReadRow(row)) {
					foreach(string field in row) {
						Console.Write("\t" + field);
					}
					Console.Write("\n");

					dataGrid.Add( new List<string>( row ) );
				}
			}

			Console.WriteLine ("----------------------------------------------------");

			using( var sw = new StreamWriter (args [1], false, Encoding.Default) ) {
				var writer = new CsvFileWriter(sw);
				// Write each row of data
				foreach(List<string> row in dataGrid) {

					foreach(string field in row) {
						Console.Write("\t" + field);
					}
					Console.Write("\n");

					writer.WriteRow( row );
				}
			}

			Console.WriteLine ("Done.");
		}
	}
}
