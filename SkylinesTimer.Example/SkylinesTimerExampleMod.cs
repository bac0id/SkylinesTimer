using ICities;

namespace SkylinesTiming.Example
{
	public class SkylinesTimerExampleMod : IUserMod
	{
		public static bool Enabled = false;

		public string Name {
			get {
				return "Frame Timer Example Mod";
			}
		}

		public string Description {
			get {
				return "Nothing...";
			}
		}

		public void OnEnabled() {
			SkylinesTimerExampleMod.Enabled = true;
		}

		public void OnDisabled() {
			SkylinesTimerExampleMod.Enabled = false;
		}
	}
}
