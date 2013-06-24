using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;

using Ios5CollectionView;

namespace SimpleCollectionView
{
	public class CircleLayout : PSTCollectionViewLayout
	{
		const float ItemSize = 70.0f;
		int cellCount = 20;
		float radius;
		PointF center;

		static string myDecorationViewId = "MyDecorationView";

		public CircleLayout ()
		{
//			RegisterClassForDecorationView (typeof(MyDecorationView), myDecorationViewId);
		}

		//public override PSTCollectionViewLayoutAttributes LayoutAttributesForDecorationView (string decorationViewKind, NSIndexPath indexPath)
		//{
		//	var attribs = PSTCollectionViewLayoutAttributes.CreateForDecorationView (decorationViewKind, indexPath);
		//	attribs.Frame = new RectangleF(0,0, 400, 800);
		//	attribs.ZIndex = -1;
		//
		//	return attribs;
		//}

		public override void PrepareLayout ()
		{
			base.PrepareLayout ();

			SizeF size = CollectionView.Frame.Size;
			cellCount = CollectionView.NumberOfItemsInSection (0);
			center = new PointF (size.Width / 2.0f, size.Height / 2.0f);
			radius = Math.Min (size.Width, size.Height) / 2.5f;	
		}
			
		public override SizeF CollectionViewContentSize {
			get {
				return CollectionView.Frame.Size;
			}
		}

		public override PSTCollectionViewLayoutAttributes LayoutAttributesForItem (NSIndexPath path)
		{
			PSTCollectionViewLayoutAttributes attributes = PSTCollectionViewLayoutAttributes.CreateForCell (path);
			attributes.Size = new SizeF (ItemSize, ItemSize);
			attributes.Center = new PointF (center.X + radius * (float)Math.Cos (2 * path.Row * Math.PI / cellCount),
			                                center.Y + radius * (float)Math.Sin (2 * path.Row * Math.PI / cellCount));
			Console.WriteLine(attributes.Center);
			return attributes;
		}

		public override PSTCollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect (RectangleF rect)
		{
			var attributes = new PSTCollectionViewLayoutAttributes [cellCount];

			for (int i = 0; i < cellCount; i++) {
				NSIndexPath indexPath = NSIndexPath.FromItemSection (i, 0);
				attributes [i] = LayoutAttributesForItem (indexPath);
			}
			return attributes;
		}

	}
	
	public class MyDecorationView : PSTCollectionReusableView
	{
		[Export ("initWithFrame:")]
		public MyDecorationView (System.Drawing.RectangleF frame) : base (frame)
		{
			BackgroundColor = UIColor.Red;
			Frame = frame;
		}
	}
}
