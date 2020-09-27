using System;

namespace FrameTiming
{
	public interface IFrameTimer
	{
		event Action Elapsed;
		bool Enabled { get; set; }
		int Interval { get; set; }
		void Start();
		void Stop();
	}
}
