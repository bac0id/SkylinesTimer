using System;

namespace SkylinesTiming
{
	public abstract class Observable
	{
		public event Action OnNotify;

		public void Notify() {
			this.OnNotify?.Invoke();
		}
	}
}
