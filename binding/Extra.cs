//
// Extra.cs
//
// Author:
//   Stephane Delcroix <stephane@delcroix.org>
//
// Copyright © 2012 Stephane Delcroix. All Rights Reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

using System;
using System.Drawing;

namespace PSTCollectionView {
	public partial class PSUICollectionViewController {
		PSUICollectionViewController (PSTCollectionViewLayout layout) : base (layout) {
		}
	}

	public partial class PSTCollectionView {
		public void RegisterClassForCell (Type cellType, string reuseIdentifier)
		{
			if (cellType == null)
				throw new ArgumentNullException ("cellType");
			RegisterClassForCell (Class.GetHandle (cellType), reuseIdentifier);
		}		

		public void RegisterClassForSupplementaryView (Type cellType, PSTCollectionElementKindSection section, string reuseIdentifier)
		{
			if (cellType == null)
				throw new ArgumentNullException ("cellType");

			string kind;
			if (section != PSTCollectionElementKindSection.Header)
			{
				if (section != PSTCollectionElementKindSection.Footer)
					throw new ArgumentOutOfRangeException ("section");
				kind = PSTCollectionElementKindSectionKey.Footer;
			}
			else
				kind = PSTCollectionElementKindSectionKey.Header;
			this.RegisterClassForSupplementaryView (Class.GetHandle (cellType), kind, reuseIdentifier);
		}
	}

	public partial class PSTCollectionViewLayout {
		//temp hack

		static readonly IntPtr selLayoutAttributesForElementsInRect_ = Selector.GetHandle ("layoutAttributesForElementsInRect:");

		[Export ("layoutAttributesForElementsInRect:")]
		public virtual PSTCollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect (System.Drawing.RectangleF rect)
		{
			if (IsDirectBinding) {
				return NSArray.ArrayFromHandle<PSTCollectionViewLayoutAttributes>(MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_RectangleF (this.Handle, selLayoutAttributesForElementsInRect_, rect));
			} else {
				return NSArray.ArrayFromHandle<PSTCollectionViewLayoutAttributes>(MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_RectangleF (this.SuperHandle, selLayoutAttributesForElementsInRect_, rect));
			}
		}

		//public void RegisterClassForDecorationView(Type cellType, string reuseIdentifier) {
		//	if (cellType == null)
		//		throw new ArgumentNullException ("cellType");

		//	this.RegisterClassForDecorationView(Class.GetHandle (cellType), reuseIdentifier);
		//}
	}

	public partial class PSTCollectionReusableView {
		public PSTCollectionReusableView (RectangleF frame) : base (frame) {
		}
	}

	public partial class PSTCollectionViewCell {
		public PSTCollectionViewCell (RectangleF frame) : base (frame) {
		}
	}
}



