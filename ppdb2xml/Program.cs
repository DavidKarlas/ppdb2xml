using System;
using System.IO;
using Roslyn.Test.PdbUtilities;

namespace ppdb2xml
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("Usage: ppdb2xml assembly");
				return;
			}
			if (!File.Exists(args[0]))
			{
				Console.WriteLine($"File {args[0]} not found.");
				return;
			}
			using (var ppdb = new FileStream(Path.ChangeExtension(args[0], "pdb"), FileMode.Open))
			using (var pd = new FileStream(args[0], FileMode.Open))
			{
				Console.WriteLine(PdbToXmlConverter.ToXml(ppdb, pd));
			}
		}
	}
}
