using System;
using System.IO;
using ColossalFramework.Plugins;
using FrameTiming;

namespace FrameTiming.Example
{
	public class GameTimeOutputer
	{
		private static IFrameTimer MyTickTimer;

		private static Stream Stream = File.Open($"GameTimeOutput.txt", FileMode.OpenOrCreate);
		private static int ElapsedCounter = 0;

		public static void Initialize() {
			MyTickTimer = new FrameTimer(FrameSource.Instance, 255);
			MyTickTimer.Elapsed += () => {
				++ElapsedCounter;
				using (StreamWriter sw = new StreamWriter(Stream)) {
					sw.WriteLine($"{DateTime.Now:g}\t{ElapsedCounter}");
				}
				DebugOutputPanel.AddMessage(
					PluginManager.MessageType.Message,
					$"{DateTime.Now:g}\t{ElapsedCounter}"
				);
			};
			MyTickTimer.Start();
		}
	}
}
