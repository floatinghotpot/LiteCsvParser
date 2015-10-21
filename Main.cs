using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace LiteCsvParser
{
	class MainClass
	{
		public static void PrintDataGrid(List<List<string>> dataGrid) {
			Console.WriteLine ("------------------------------------------------------------------------------");
			foreach (var row in dataGrid) {
				foreach(string cell in row) {
					Console.Write("\t\t" + cell);
				}
				Console.Write("\n");
			}
			Console.WriteLine ("------------------------------------------------------------------------------");
		}

		public static bool CompareFile(string file1, string file2) {
			string str1 = File.ReadAllText (file1);
			string str2 = File.ReadAllText (file2);
			bool same = (str1 == str2);
			Console.WriteLine ("inputFile" + (same?" == ":" != ") + "outputFile");
			return same;
		}

		public static bool Test1(string inputFile, string outputFile) {
			var dataGrid = CsvFileReader.ReadAll(inputFile, Encoding.GetEncoding("gbk"));
			if (dataGrid == null) {
				Console.WriteLine("Failed loading data from inputFile");
				return false;
			}

			PrintDataGrid (dataGrid);

			CsvFileWriter.WriteAll(dataGrid, outputFile, Encoding.GetEncoding("gbk"));

			return CompareFile (inputFile, outputFile);
		}

		public static bool Test2(string inputFile, string outputFile) {
			var dataGrid = new List<List<string>> ();

			using (var sr = new StreamReader (inputFile, Encoding.GetEncoding ("gbk"))) {
				var reader = new CsvFileReader (sr);
				// read row by row
				var row = new List<string> ();
				while (reader.ReadRow(row)) {
					dataGrid.Add (new List<string> (row));
				}
			}

			PrintDataGrid (dataGrid);
			
			using( var sw = new StreamWriter (outputFile, false, Encoding.GetEncoding ("gbk")) ) {
				var writer = new CsvFileWriter(sw);
				// Write each row of data
				foreach(var row in dataGrid) {
					writer.WriteRow( row );
				}
			}

			return CompareFile (inputFile, outputFile);
		}

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			if (args.Length < 2) {
				Console.WriteLine( "Sytnax: LiteCsvParser <input_file> <output_file>" );
				return;
			}

			string inputFile = args [0], outputFile = args [1];

			Test1 (inputFile, outputFile);

			Test2 (inputFile, outputFile);
		}
	}
}
