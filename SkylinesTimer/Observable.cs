using System;

namespace SkylinesTiming
{
	public abstract class Observable
	{
		public event Action OnNotify;

		public void Notify() {
			if (this.OnNotify != null) {
				this.OnNotify.Invoke();
			}
		}
	}
}
