using ICities;

namespace FrameTiming.Example
{
	public class FrameTimerExampleMod : IUserMod
	{
		public static bool Enabled = false;

		public string Name => "Frame Timer Example Mod";

		public string Description => "Nothing...";

		public void OnEnabled() {
			FrameTimerExampleMod.Enabled = true;
		}

		public void OnDisabled() {
			FrameTimerExampleMod.Enabled = false;
		}
	}
}
