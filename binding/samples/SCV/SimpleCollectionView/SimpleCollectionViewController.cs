using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using PSTCollectionView;

namespace SimpleCollectionView
{
	public class SimpleCollectionViewController : PSTCollectionViewController
	{
		static NSString animalCellId = new NSString ("AnimalCell");
		static NSString headerId = new NSString ("Header");																			

		List<IAnimal> animals;

		public SimpleCollectionViewController (PSTCollectionViewLayout layout) : base (layout)
		{
			animals = new List<IAnimal> ();
			for (int i = 0; i< 20; i++) {
				animals.Add (new Monkey ());
			}

//			CollectionView.ContentInset = new UIEdgeInsets (20, 20, 20, 20);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CollectionView.RegisterClassForCell (typeof(AnimalCell), animalCellId);
			CollectionView.RegisterClassForSupplementaryView(typeof(Header), PSTCollectionElementKindSection.Header, headerId);
		}

		public override int NumberOfSections (PSTCollectionView.PSTCollectionView collectionView)
		{
			return 1;
		}

		public override int GetItemsCount (PSTCollectionView.PSTCollectionView collectionView, int section)
		{
			return animals.Count;
		}

		public override PSTCollectionViewCell GetCell (PSTCollectionView.PSTCollectionView collectionView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var animalCell = (AnimalCell)collectionView.DequeueReusableCell (animalCellId, indexPath);

			var animal = animals [indexPath.Row];

			animalCell.Image = animal.Image;

			return animalCell;
		}

		public override PSTCollectionReusableView GetViewForSupplementaryElement (PSTCollectionView.PSTCollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
		{
			var headerView = (Header)collectionView.DequeueReusableSupplementaryView (elementKind, headerId, indexPath);
			headerView.Text = "This is a Supplementary View";
			return headerView;
		}

		public override void ItemHighlighted (PSTCollectionView.PSTCollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);
			cell.ContentView.BackgroundColor = UIColor.Yellow;
		}

		public override void ItemUnhighlighted (PSTCollectionView.PSTCollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);
			cell.ContentView.BackgroundColor = UIColor.White;
		}

		public override bool ShouldHighlightItem (PSTCollectionView.PSTCollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}

//		public override bool ShouldSelectItem (UICollectionView collectionView, NSIndexPath indexPath)
//		{
//			return false;
//		}

		// for edit menu
		public override bool ShouldShowMenu (PSTCollectionView.PSTCollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}

		public override bool CanPerformAction (PSTCollectionView.PSTCollectionView collectionView, MonoTouch.ObjCRuntime.Selector action, NSIndexPath indexPath, NSObject sender)
		{
			return true;
		}


		public override void PerformAction (PSTCollectionView.PSTCollectionView collectionView, MonoTouch.ObjCRuntime.Selector action, NSIndexPath indexPath, NSObject sender)
		{
			Console.WriteLine ("code to perform action");
		}
	}

	public class AnimalCell : PSTCollectionViewCell
	{
		UIImageView imageView;

		[Export ("initWithFrame:")]
		public AnimalCell (System.Drawing.RectangleF frame) : base (frame)
		{
			BackgroundView = new UIView{BackgroundColor = UIColor.Orange};

			SelectedBackgroundView = new UIView{BackgroundColor = UIColor.Green};

			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			ContentView.Layer.BorderWidth = 2.0f;
			ContentView.BackgroundColor = UIColor.White;
			ContentView.Transform = CGAffineTransform.MakeScale (0.8f, 0.8f);

			imageView = new UIImageView (UIImage.FromBundle ("placeholder.png"));
			imageView.Center = ContentView.Center;
			imageView.Transform = CGAffineTransform.MakeScale (0.7f, 0.7f);

			ContentView.AddSubview (imageView);
		}

		public UIImage Image {
			set {
				imageView.Image = value;
			}
		}
	}

	public class Header : PSTCollectionReusableView
	{
		UILabel label;

		public string Text {
			get {
				return label.Text;
			}
			set {
				label.Text = value;
				SetNeedsDisplay ();
			}
		}

		[Export ("initWithFrame:")]
		public Header (System.Drawing.RectangleF frame) : base (frame)
		{
			label = new UILabel (){Frame = frame, BackgroundColor = UIColor.White};
			AddSubview (label);
		}
	}
	
}

