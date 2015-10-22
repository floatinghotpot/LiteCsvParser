
# LiteCsvParser 

A lite CSV reader and writer in C#, without any heavy dependency.

# Purpose

Parsing CSV files may sound like an easy task, but in reality it is not that trivial. 

* Using String.Split() is fast, but it cannot handle quoting notation and eascaping.

* Using Microsoft.VisualBasic.FileIO is very good, but it's dependent on Windows platform.

If you wanna read/write CSV file in Mono/Unity cross-platform project, LiteCsvParser is the right choice.

# How to Use

You will need only the file "LiteCsvParser.cs", copy & ad it into your own project.

You can also git clone this project, use MonDevelop or VisualStudio to open the project to build a demo executable.

# Compatibility

* VisualStudio
* Mono
* Unity

See dependency:
```
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
```

# Example 

Read & write all data grid:
```csharp
using LiteCsvParser;

List<List<string>> dataGrid = CsvFileReader.ReadAll("test.csv", Encoding.GetEncoding("gbk"));

// TODO: deal with data grid
foreach(var row in dataGrid) {
	foreach(var cell in row) {
		Console.Write("\t\t" + cell);
	}
	Console.Write("\n");
}

CsvFileWriter.WriteAll(dataGrid, "output2.csv", Encoding.GetEncoding("gbk"));
```

Read row by row (if the CSV file is very large):
```csharp
	List<string> row = new List<string>();
	using (var reader = new CsvFileReader("Test.csv"))
	{
		while (reader.ReadRow(row))
		{
			// TODO: Do something with columns' values
			foreach(string cell in row) {
				Console.Write("\t\t" + cell);
			}
			Console.Write("\n");
		}
	}
```


Write row by row:
```csharp
	using (var writer = new CsvFileWriter("Test.csv"))
	{
		// Write each row of data
		for (int i = 0; i < 10; i++)
		{
			List<string> row = new List<string>();
			
			// TODO: Populate column values for this row
			for(int j=0; j<5; j++) {
				row.Add("" + j);
			}

			writer.WriteRow(row);
		}
	}
```

# Credits

The source code was originally written by Jonathan Wood, from [blackbetcoder.com](http://www.blackbeltcoder.com/Articles/files/reading-and-writing-csv-files-in-c), but not found on github.com, so I create a project in github to maintain it.

This project is published under MIT License. From Jonathan Wood: Use of this article and any related source code or other files is governed by the terms and conditions of [The Code Project Open License](http://www.blackbeltcoder.com/Legal/Licenses/CPOL).

Feedback and pull requests are welcome.

