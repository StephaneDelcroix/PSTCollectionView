//
// StructsAndEnums.cs
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

using System;
using System.Runtime.InteropServices;
using MonoTouch.ObjCRuntime;

namespace Ios5CollectionView {
	public enum PSTCollectionElementKindSection {
		Header,
		Footer,
	}

	public enum PSTCollectionViewScrollDirection {
		Vertical,
		Horizontal,
	}

	[Flags]
	public enum PSTCollectionViewScrollPosition : uint
	{
		None                 = 0,
		
		// The vertical positions are mutually exclusive to each other, but are bitwise or-able with the horizontal scroll positions.
		// Combining positions from the same grouping (horizontal or vertical) will result in an NSInvalidArgumentException.
		Top                  = 1,
		CenteredVertically   = 2,
		Bottom               = 4,
		
		// Likewise, the horizontal positions are mutually exclusive to each other.
		Left                 = 8,
		CenteredHorizontally = 16,
		Right                = 32
	}
	
	[Flags]
	public enum UICollectionViewScrollPosition : uint
	{
		None                 = 0,
		
		// The vertical positions are mutually exclusive to each other, but are bitwise or-able with the horizontal scroll positions.
		// Combining positions from the same grouping (horizontal or vertical) will result in an NSInvalidArgumentException.
		Top                  = 1,
		CenteredVertically   = 2,
		Bottom               = 4,
		
		// Likewise, the horizontal positions are mutually exclusive to each other.
		Left                 = 8,
		CenteredHorizontally = 16,
		Right                = 32
	}
	
	public enum PSTCollectionViewItemType : uint
	{
		Cell,
		SupplementaryView,
		DecorationView
	}
}



