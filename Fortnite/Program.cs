using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace Fortnite
{
	internal class Program
	{
		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int MessageBox(IntPtr h, string m, string c, int type);

		private static void Main(string[] args)
		{
			Console.Title = ("Anti Cheat Made By ItzAqua https://github.com/ItzAqua");
			Console.WriteLine("Anti Cheat Made By ItzAqua https://github.com/ItzAqua");
			//From Stack Overflow Cause im brain dead when comes to WebClient
			WebClient Client = new WebClient();
			Client.DownloadFile("https://raw.githubusercontent.com/DRQSuperior/StrikeFN-dll-Download/main/Strike%20ssl.dll", "Strike.dll");
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
			Console.WriteLine("Launched");
			MessageBox((IntPtr)0, "Press Ok on Select Gamemode Screen", "Inject", 0);
			ProcessHelper.InjectDll(process.Id, Path.Combine(Directory.GetCurrentDirectory(), "Strike.dll"));
			process.WaitForExit();
			Process.GetCurrentProcess().Kill();
		}
	}
}
