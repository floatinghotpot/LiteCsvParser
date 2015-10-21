
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

Write CSV:
```csharp
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
```

Read CSV:
```csharp
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
```

# Credits

The source code was originally written by Jonathan Wood, from [blackbetcoder.com](http://www.blackbeltcoder.com/Articles/files/reading-and-writing-csv-files-in-c), but not found on github.com, so I create a project in github to maintain it.

This project is published under MIT License. From Jonathan Wood: Use of this article and any related source code or other files is governed by the terms and conditions of [The Code Project Open License](http://www.blackbeltcoder.com/Legal/Licenses/CPOL).

Feedback and pull requests are welcome.

