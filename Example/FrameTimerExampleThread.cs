using FrameTiming;
using ICities;

namespace FrameTiming.Example
{
	public class FrameTimerExampleThread : ThreadingExtensionBase
	{
		public override void OnBeforeSimulationFrame() {
			if (FrameTimerExampleMod.Enabled && Loader.IsInGame) {
				FrameSource.Instance.Notify();
			}
		}
	}
}
