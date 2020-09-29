namespace SkylinesTiming.Example
{
	public class GameTimeOutputer
	{
		private static int ElapsedCounter1 = 0;
		private static int ElapsedCounter2 = 0;

		public static void Initialize() {
			SkylinesTimer timer1 = new SkylinesTimer(SkylinesTimeSource.Instance, 60);
			timer1.Elapsed += () => {
				++ElapsedCounter1;
				DebugLog.Log(string.Format("Timer1 elapsed\t{0}, next {1}", ElapsedCounter1, timer1.nextElapsingTime));
			};
			timer1.Start();

			SkylinesTimer timer2 = new SkylinesTimer(SkylinesTimeSource.Instance, 120);
			timer2.Elapsed += () => {
				++ElapsedCounter2;
				DebugLog.Log(string.Format("Timer2 elapsed\t{0}, next {1}", ElapsedCounter2, timer2.nextElapsingTime));
			};
			timer2.Start();
			DebugLog.Log("GameTimeOutputer initialized");
		}
	}
}
