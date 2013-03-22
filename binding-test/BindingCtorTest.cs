//
// BindingCtorTest.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;

using TouchUnit.Bindings;
using NUnit.Framework;

namespace bindingtest
{
	[TestFixture]
	public class BindingCtorTest : ApiCtorInitTest
	{
		public BindingCtorTest ()
		{
			LogProgress = true;

			ContinueOnFailure = true;

			LogUntestedTypes = true;
		}

		protected override System.Reflection.Assembly Assembly {
			get {
				return typeof (PSTCollectionView.PSTCollectionView).Assembly;
			}
		}
	}
}

