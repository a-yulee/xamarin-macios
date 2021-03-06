//
// Unit tests for SKReceiptRefreshRequest
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc. All rights reserved.
//

#if !__WATCHOS__

using System;
using System.IO;
#if XAMCORE_2_0
using Foundation;
using ObjCRuntime;
using StoreKit;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.StoreKit;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.StoreKit {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class ReceiptRefreshRequestTest {

		[Test]
		public void TerminateForInvalidReceipt ()
		{
			if (!UIDevice.CurrentDevice.CheckSystemVersion (7, 1))
				Assert.Inconclusive ("requires iOS 7.1+");

			// not yet documented - seems to kill the app on purpose ?!? on both sim and devices
			//SKReceiptRefreshRequest.TerminateForInvalidReceipt ();

			IntPtr sk = Dlfcn.dlopen ("/System/Library/Frameworks/StoreKit.framework/StoreKit", 1);
			IntPtr fp = Dlfcn.dlsym (sk, "SKTerminateForInvalidReceipt");
			Assert.That (fp, Is.Not.EqualTo (IntPtr.Zero), "pointer");
			Dlfcn.dlclose (sk);
		}
	}
}

#endif // !__WATCHOS__
