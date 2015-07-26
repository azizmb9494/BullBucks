// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Bullbucks
{
	[Register ("BalViewCtrl")]
	partial class BalViewCtrl
	{
		[Outlet]
		UIKit.UILabel balLbl { get; set; }

		[Outlet]
		UIKit.UILabel timeLbl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (balLbl != null) {
				balLbl.Dispose ();
				balLbl = null;
			}

			if (timeLbl != null) {
				timeLbl.Dispose ();
				timeLbl = null;
			}
		}
	}
}
