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
				_Defaults.StringForKey ("FirstName");
			}

			set {
				_Defaults.SetString (value, "FirstName");
			}
		}

		public static string LastName
		{
			get {
				_Defaults.StringForKey ("LastName");
			}

			set {
				_Defaults.SetString (value, "LastName");
			}
		}

		public static string UID
		{
			get {
				_Defaults.StringForKey ("UID");
			}

			set {
				_Defaults.SetString (value, "UID");
			}
		}

		public static string CardNumber
		{
			get {
				_Defaults.StringForKey ("CardNumber");
			}

			set {
				_Defaults.SetString (value, "CardNumber");
			}
		}
	}
}

