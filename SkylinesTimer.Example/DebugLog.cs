using System;
using System.IO;

public static class DebugLog
{
	public static void Log(string msg) {
		using (FileStream fileStream = new FileStream("_SkylinesTimerExampleOutput.txt", FileMode.Append)) {
			StreamWriter sw = new StreamWriter(fileStream);
			var t = DateTime.Now;
			sw.Write("{0}:{1}:{2}\t", t.Minute, t.Second, t.Millisecond);
			sw.WriteLine(msg);
			sw.Flush();
		}
	}
}