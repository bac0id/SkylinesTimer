using ColossalFramework;
using ICities;

using SkylinesTiming;

namespace SkylinesTiming.Example
{
	public class Loader : LoadingExtensionBase
	{
		public static LoadMode Mode { get; private set; }
		public static bool IsInGame {
			get { 
				return Loader.Mode == LoadMode.LoadGame || Loader.Mode == LoadMode.NewGame; 
			}
		}

		public override void OnLevelLoaded(LoadMode mode) {
			base.OnLevelLoaded(mode);
			Loader.Mode = mode;
			if (Loader.IsInGame) {
				// create the TickSource instance
				SkylinesTimeSource.Instance = new SkylinesTimeSource(Singleton<SimulationManager>.instance);
				DebugLog.Log("TimeSource instance created");
				GameTimeOutputer.Initialize();
			}
		}
	}
}
