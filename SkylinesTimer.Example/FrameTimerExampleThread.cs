using ICities;

using SkylinesTiming;

namespace SkylinesTiming.Example
{
	public class FrameTimerExampleThread : ThreadingExtensionBase
	{
		public override void OnBeforeSimulationFrame() {
			if (SkylinesTimerExampleMod.Enabled && Loader.IsInGame) {
				SkylinesTimeSource.Instance.OnFrameUpdate();
				DebugLog.Log(string.Format("Internal Time\t{0}", SkylinesTimeSource.Instance.internalTime));
			}
		}
	}
}
