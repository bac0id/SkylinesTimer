namespace FrameTiming
{
	public class FrameSource : Observable, IFrameSource
	{
		public static FrameSource Instance { get; set; }

		private readonly SimulationManager simulationManager;

		public FrameSource(SimulationManager simulationManager) {
			this.simulationManager = simulationManager;
		}

		public uint GetTick() {
			return this.simulationManager.m_currentTickIndex;
		}
	}
}
