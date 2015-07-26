using System;
using Foundation;

namespace Bullbucks
{
	public static class KeyStore
	{
		private static NSUserDefaults _Defaults = new NSUserDefaults("group.com.azizmb.bullbucks", NSUserDefaultsType.SuiteName);

		public static string FirstName
		{
			get {
				return _Defaults.StringForKey ("FirstName");
			}

			set {
				_Defaults.SetString (value, "FirstName");
			}
		}

		public static string LastName
		{
			get {
				return _Defaults.StringForKey ("LastName");
			}

			set {
				_Defaults.SetString (value, "LastName");
			}
		}

		public static string UID
		{
			get {
				return _Defaults.StringForKey ("UID");
			}

			set {
				_Defaults.SetString (value, "UID");
			}
		}

		public static string CardNumber
		{
			get {
				return _Defaults.StringForKey ("CardNumber");
			}

			set {
				_Defaults.SetString (value, "CardNumber");
			}
		}

		public static DateTime Updated
		{
			get {
				return new DateTime (1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddTicks ((int)_Defaults.IntForKey ("Updated"));
			}

			set {
				var delta = value - new DateTime (1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
				_Defaults.SetInt ((int)delta.Ticks, "Updated");
			}
		}
	}
}

