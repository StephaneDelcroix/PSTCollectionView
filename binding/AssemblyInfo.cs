using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libPSTCollectionView.a",LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "UIKit QuartzCore")]
