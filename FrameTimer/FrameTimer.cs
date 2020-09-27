using System;

namespace FrameTiming
{
	public class FrameTimer : IFrameTimer, IObserver
	{
		public event Action Elapsed;

		public bool Enabled { get; set; } = false;
		/// <summary>
		/// The time, in frame, between events. 
		/// According to Cities Skylines Modding API, there are 60 frames per second on normal (1x) speed.
		/// </summary>
		public int Interval { get; set; }

		private IFrameSource frameSource;

		/// <summary>
		/// Create <see cref="FrameTimer"/> instance
		/// </summary>
		/// <param name="frameSource">
		/// The source of frame.
		/// </param>
		/// <param name="interval">
		/// The time, in frame, between events.
		/// According to Cities Skylines Modding API, there are 60 frames per second on normal (1x) speed.
		/// </param>
		public FrameTimer(FrameSource frameSource, int interval = 0xff) {
			frameSource.OnNotify += this.Update;
			this.frameSource = frameSource;
			this.Interval = interval;
		}

		public void Start() {
			this.Enabled = true;
		}

		public void Stop() {
			this.Enabled = false;
		}

		public void Update() {
			if (this.Enabled && this.frameSource.GetTick() % this.Interval == 0) {
				this.Elapsed.Invoke();
			}
		}
	}
}
