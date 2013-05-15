using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

using Ios5CollectionView;
using System.Drawing;

namespace SimpleCollectionView
{
	public class NormalViewController : UIViewController
	{
		static string animalCellId = "AnimalCell";
		static string headerId = "Header";	

		PSTCollectionView CollectionView { get; set; }
		List<IAnimal> animals;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			animals = new List<IAnimal> ();
			for (int i = 0; i< 500; i++) {
				animals.Add (new Monkey ());
			}
		
			CollectionView = new PSTCollectionView (new RectangleF (0, 0, 703, 748), new PSTCollectionViewFlowLayout {
				HeaderReferenceSize = new System.Drawing.SizeF (50, 50),
				SectionInset = new UIEdgeInsets (20,0,0,0)
			});
			CollectionView.BackgroundColor = UIColor.ScrollViewTexturedBackgroundColor;

			CollectionView.DataSource = new TestDataSource (this);

			CollectionView.RegisterClassForCell (typeof(AnimalCell), animalCellId);
			CollectionView.RegisterClassForSupplementaryView(typeof(Header), PSTCollectionElementKindSection.Header, headerId);


			View.Add (CollectionView);
		}

		class TestDataSource : PSTCollectionViewDataSource
		{
			NormalViewController vc;

			public TestDataSource (NormalViewController vc)
			{
				this.vc = vc;
			}

			public override int NumberOfSections (PSTCollectionView collectionView)
			{
				return 1;
			}
			
			public override int GetItemsCount (PSTCollectionView collectionView, int section)
			{
				return vc.animals.Count;
			}
			
			public override PSTCollectionViewCell GetCell (PSTCollectionView collectionView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var animalCell = (AnimalCell)collectionView.DequeueReusableCell (animalCellId, indexPath);
				
				var animal = vc.animals [indexPath.Row];
				
				animalCell.Image = animal.Image;
				
				return animalCell;
			}

			public override PSTCollectionReusableView GetViewForSupplementaryElement (PSTCollectionView collectionView, string elementKind, NSIndexPath indexPath)
			{
				var headerView = collectionView.DequeueReusableSupplementaryView (elementKind, headerId, indexPath) as Header;
				headerView.Text = "Musti";
				return headerView;
			}
		}
	}
}

