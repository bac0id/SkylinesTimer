namespace SkylinesTiming
{
	public class SkylinesTimeSource : Observable, ISkylinesTimeSource
	{
		public static SkylinesTimeSource Instance { get; set; }
		private const uint INTERNAL_TIME_CONST = 32;

		private SimulationManager sm;
		public uint internalTime = 0;

		public SkylinesTimeSource(SimulationManager simulationManager) {
			this.sm = simulationManager;
		}

		public void OnFrameUpdate() {
			this.ProcessInternalTime();
			base.Notify();
		}

		public uint GetTime() {
			return this.internalTime;
		}

		private void ProcessInternalTime() {
			// on 1x speed => deltaTime = 1
			// on 2x speed => deltaTime = 2
			// on 3x speed => deltaTime = 4
			// if use a mod to run game at 4x speed, maybe deltaTime = 8
			var deltaTime = this.sm.FinalSimulationSpeed;
			this.internalTime = (uint)(internalTime + deltaTime);
		}
	}
}
