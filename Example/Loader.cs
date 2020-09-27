using ColossalFramework;
using ICities;

using FrameTiming;

namespace FrameTiming.Example
{
	public class Loader : LoadingExtensionBase
	{
		public static LoadMode Mode { get; private set; }
		public static bool IsInGame => Loader.Mode == LoadMode.LoadGame || Loader.Mode == LoadMode.NewGame;

		public override void OnLevelLoaded(LoadMode mode) {
			base.OnLevelLoaded(mode);
			Loader.Mode = mode;
			if (Loader.IsInGame) {
				// create the TickSource instance
				FrameSource.Instance = new FrameSource(Singleton<SimulationManager>.instance);
				GameTimeOutputer.Initialize();
			}
		}
	}
}
