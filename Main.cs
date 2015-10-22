using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Mono.Csv;

namespace LiteCsvParser
{
	class MainClass
	{
		public static void PrintRow(List<string> row) {
			foreach(string cell in row) {
				Console.Write("\t\t" + cell);
			}
			Console.Write("\n");
		}

		public static void PrintDataGrid(List<List<string>> dataGrid) {
			Console.WriteLine ("------------------------------------------------------------------------------");
			foreach (var row in dataGrid) {
				PrintRow(row);
			}
			Console.WriteLine ("------------------------------------------------------------------------------");
		}

		public static bool CompareFile(string inputFile, string outputFile) {
			string str1 = File.ReadAllText (inputFile);
			string str2 = File.ReadAllText (outputFile);
			bool same = (str1 == str2);

			Console.WriteLine ("input file: " + inputFile);
			Console.WriteLine ("output file: " + outputFile);
			Console.WriteLine ("TEST " + (same?"PASS":"FAIL"));
			return same;
		}

		public static bool TestWithGrid(string inputFile, string outputFile) {
			var dataGrid = CsvFileReader.ReadAll(inputFile, Encoding.GetEncoding("gbk"));
			if (dataGrid != null) {
				PrintDataGrid (dataGrid);

				CsvFileWriter.WriteAll(dataGrid, outputFile, Encoding.GetEncoding("gbk"));

				return CompareFile (inputFile, outputFile);

			} else {
				Console.WriteLine("Failed loading data from inputFile");
				return false;
			}
		}

		public static bool TestWithRow(string inputFile, string outputFile) {
			using (var sr = new StreamReader (inputFile, Encoding.GetEncoding ("gbk"))) {
				var reader = new CsvFileReader (sr);
				using( var sw = new StreamWriter (outputFile, false, Encoding.GetEncoding ("gbk")) ) {
					var writer = new CsvFileWriter(sw);

					Console.WriteLine ("------------------------------------------------------------------------------");
					var row = new List<string> ();
					while (reader.ReadRow(row)) {
						PrintRow(row);
						writer.WriteRow( row );
					}
					Console.WriteLine ("------------------------------------------------------------------------------");
				}
			}

			return CompareFile (inputFile, outputFile);
		}

		public static void Main (string[] args) {
			Console.WriteLine ("Hello World!");

			if (args.Length < 1) {
				Console.WriteLine( "Sytnax: \nLiteCsvParser <input_file> <input_file> ...\nLiteCsvParser *.csv" );
				return;
			}

			int nPass = 0;
			List<string> failed = new List<string> ();
			for (int i=0; i<args.Length; i++) {
				bool ok = TestWithGrid (args[i], "./tmp.csv");
				if(ok) {
					nPass ++;
				} else {
					failed.Add(args[i]);
				}
			}
			File.Delete ("./tmp.csv");

			Console.WriteLine("\nTest pass: " + nPass.ToString() + "/" + args.Length.ToString());

			if (failed.Count > 0) {
				Console.WriteLine("Failed cases:");
				foreach(var filepath in failed) {
					Console.WriteLine( filepath );
				}
			}
			Console.WriteLine ();
		}
	}
}
