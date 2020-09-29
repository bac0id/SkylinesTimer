using System;

namespace SkylinesTiming
{
	public interface ISkylinesTimer
	{
		event Action Elapsed;
		bool Enabled { get; set; }
		int Interval { get; set; }
		void Start();
		void Stop();
	}
}
