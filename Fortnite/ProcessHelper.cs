using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Fortnite
{
	// Token: 0x02000002 RID: 2
	public class ProcessHelper
	{
		// Token: 0x06000002 RID: 2
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hHandle);

		// Token: 0x06000003 RID: 3
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x06000004 RID: 4
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000005 RID: 5
		[DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x06000006 RID: 6 RVA: 0x00002050 File Offset: 0x00000250
		public static void InjectDll(int processId, string path)
		{
			IntPtr hProcess = ProcessHelper.OpenProcess(1082, false, processId);
			IntPtr procAddress = ProcessHelper.GetProcAddress(ProcessHelper.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			uint num = (uint)((path.Length + 1) * Marshal.SizeOf(typeof(char)));
			IntPtr intPtr = ProcessHelper.VirtualAllocEx(hProcess, IntPtr.Zero, num, 12288U, 4U);
			UIntPtr uintPtr;
			ProcessHelper.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), num, out uintPtr);
			ProcessHelper.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
		}

		// Token: 0x06000007 RID: 7
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x06000008 RID: 8
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll")]
		public static extern int ResumeThread(IntPtr hThread);

		// Token: 0x0600000A RID: 10 RVA: 0x000020D4 File Offset: 0x000002D4
		public static Process StartProcess(string path, bool shouldFreeze, string extraArgs = "")
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = path,
					Arguments = "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -skippatchcheck" + extraArgs
				}
			};
			process.Start();
			if (shouldFreeze)
			{
				foreach (object obj in process.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					ProcessHelper.SuspendThread(ProcessHelper.OpenThread(2, false, processThread.Id));
				}
			}
			return process;
		}

		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll")]
		public static extern int SuspendThread(IntPtr hThread);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x0600000D RID: 13
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
	}
}
