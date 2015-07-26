using System;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using BigTed;

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
			Name.Footer = "Only your U Number OR First AND Last Name are required.";


			this.Root = new RootElement ("Account") {
				Numbers,
				Name,
				new Section() {
					this.Save
				}
			};

			this.NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Save, delegate {
				this.Save_Tapped();	
			});

			this.NavigationItem.LeftBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Cancel, delegate {
				this.NavigationController.PopViewController(true);	
			});
		}

		void Save_Tapped ()
		{
			ulong cNumber = 0; 
			if (this.CardNumber.Value.Length != 16 || !ulong.TryParse (this.CardNumber.Value, out cNumber)) {
				BTProgressHUD.ShowErrorWithStatus ("Card #");
			} else if (this.UID.Value.Length != 9) {
				BTProgressHUD.ShowErrorWithStatus ("U Number");
			} else {
				KeyStore.CardNumber = this.CardNumber.Value;
				KeyStore.UID = this.UID.Value;
				KeyStore.FirstName = this.FirstName.Value;
				KeyStore.LastName = this.LastName.Value;

				BTProgressHUD.ShowSuccessWithStatus ("Saved!");
				this.NavigationController.PopViewController (true);
			}
		}
	}
}

