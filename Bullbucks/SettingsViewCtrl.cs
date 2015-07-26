using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;

namespace Bullbucks
{
	public class SettingsViewCtrl : DialogViewController
	{
		EntryElement CardNumber, UID, FirstName, LastName;
		StringElement Save;

		public SettingsViewCtrl () : base(null)
		{
			this.CardNumber = new EntryElement ("Card #", "6400130000000000", KeyStore.CardNumber) {
				KeyboardType = UIKeyboardType.NumberPad,
				TextAlignment = UITextAlignment.Right
			};

			this.UID = new EntryElement ("U Number", "U012345678", KeyStore.UID) {
				TextAlignment = UITextAlignment.Right
			};

			this.FirstName = new EntryElement ("First Name", "Rocky", KeyStore.FirstName) {
				TextAlignment = UITextAlignment.Right
			};

			this.LastName = new EntryElement ("Last Name", "Bull", KeyStore.LastName) {
				TextAlignment = UITextAlignment.Right
			};

			this.Save = new StringElement ("Save") { Alignment = UITextAlignment.Center };
			this.Save.Tapped += Save_Tapped;

			Section Numbers = new Section () { this.CardNumber, this.UID };
			Section Name = new Section () { this.FirstName, this.LastName };
			Name.Footer = "Please enter either your U Number OR First AND Last Name.";


			this.Root = new RootElement ("Account") {
				Numbers,
				Name,
				new Section() {
					this.Save
				}
			};
		}

		void Save_Tapped ()
		{
			
		}
	}
}

