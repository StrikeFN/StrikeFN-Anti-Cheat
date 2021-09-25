using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace Fortnite
{

	internal class Program
	{
		[DllImport("Kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();
		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

		public static void dll()
        {
			WebClient Client = new WebClient();
			Client.DownloadFile("https://github.com/DRQSuperior/StrikeFN-dll-Download/raw/main/Strikessl.dll", "Strike.dll");
		}

		private static void Main(string[] args)
		{
			//title
			Console.Title = ("StrikeFN Anti Cheat");
			Thread.Sleep(1000);

			//dll download
            Program.dll();

			//welcome
			Program.PrintWelcome();
			//discord
			Console.WriteLine("discord discord.io/strikefn Please Join it would be very appreciated!");
			//launch
			string str = string.Empty;
			string text = string.Empty;
			foreach (string text2 in args)
			{
				bool flag = text2.Contains("-epicusername=");
				bool flag2 = flag;
				bool flag3 = flag2;
				bool flag4 = flag3;
				if (flag4)
				{
					str = text2.Replace("-epicusername=", "");
				}
				text = text + text2 + " ";
			}
			Process process = Process.Start("FortniteClient-Win64-Shipping.exe", text);
			ProcessHelper.InjectDll(process.Id, Path.Combine(Directory.GetCurrentDirectory(), "Strike.dll"));
			process.WaitForExit();
			Process.GetCurrentProcess().Kill();
		}

		public static void PrintWelcome()
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("W");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("e");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("l");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("c");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("o");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("m");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("e");
			Thread.Sleep(75);
			Console.Write(" ");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("T");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("o");
			Thread.Sleep(75);
			Console.Write(" ");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("S");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("t");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("r");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("i");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("k");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("e");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("F");
			Thread.Sleep(75);
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write("N");
			Thread.Sleep(75);
			Console.Clear();
		}
	}
}
