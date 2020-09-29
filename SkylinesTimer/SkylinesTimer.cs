using System;

namespace SkylinesTiming
{
	public class SkylinesTimer : ISkylinesTimer, IObserver
	{
		public event Action Elapsed;

		public bool Enabled { get; set; } = false;

		/// <summary>
		/// The time between events. 
		/// </summary>
		public int Interval { get; set; }

		private ISkylinesTimeSource timeSource;
		public uint nextElapsingTime;

		/// <summary>
		/// Create <see cref="SkylinesTimer"/> instance.
		/// </summary>
		/// <param name="timeSource">
		/// The source of time.
		/// </param>
		/// <param name="interval">
		/// <para>
		///		The time between events. 
		/// </para>
		/// <para>
		///		If set to 60, <see cref="Elapsed"/> will be invoked .. 
		///		<list type="bullet">each 1 real second on 1x in-game speed</list>
		///		<list type="bullet">or each 0.5 second on 2x speed</list>
		///		<list type="bullet">or each 0.25 second on 3x speed ( considering <see cref="SimulationManager.FinalSimulationSpeed"/> = 4 )</list>
		/// </para>
		/// </param>
		public SkylinesTimer(SkylinesTimeSource timeSource, int interval = 60) {
			if (timeSource == null)
				throw new ArgumentNullException();
			if (interval <= 0)
				throw new ArgumentOutOfRangeException();
			timeSource.OnNotify += this.Update;
			this.timeSource = timeSource;
			this.Interval = interval;
		}

		public void Start() {
			this.Enabled = true;
			this.nextElapsingTime = GetNextElapsingTime();
		}

		public void Stop() {
			this.Enabled = false;
		}

		public void Update() {
			if (this.Enabled && this.nextElapsingTime <= this.timeSource.GetTime()) {
				this.nextElapsingTime = GetNextElapsingTime();
				this.Elapsed();
			}
		}

		private uint GetNextElapsingTime() {
			return this.timeSource.GetTime() + (uint)this.Interval;
		}
	}
}
