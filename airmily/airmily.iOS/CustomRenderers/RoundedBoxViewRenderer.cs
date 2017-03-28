using System;
using System.Collections.Generic;
using System.Text;

using UIKit;
using CoreGraphics;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using airmily.Views.Controls;
using airmily.iOS.CustomRenderers;
using System.ComponentModel;

[assembly:ExportRendererAttribute(typeof(RoundedBoxView),typeof(RoundedBoxViewRenderer))]
namespace airmily.iOS.CustomRenderers
{
	class RoundedBoxViewRenderer :	BoxRenderer
	{
		public override void Draw(CGRect rect)
		{
			RoundedBoxView rbv = (RoundedBoxView)this.Element;
			using (var context = UIGraphics.GetCurrentContext())
			{
				context.SetFillColor(rbv.Color.ToCGColor());
				context.SetStrokeColor(rbv.Stroke.ToCGColor());
				context.SetLineWidth((float)rbv.StrokeThickness);


				var rc = this.Bounds.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);
				nfloat radius = (nfloat)rbv.CornerRadius;
				radius = (nfloat)Math.Max(0, Math.Min(radius, Math.Max(rc.Height / 2, rc.Width / 2)));

				var path = CGPath.FromRoundedRect(rc, radius, radius);
				context.AddPath(path);
				context.DrawPath(CGPathDrawingMode.FillStroke);
				//base.Draw(rect);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName || e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName || e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
			{
				Layer.MasksToBounds = true;
				Layer.CornerRadius = (float)((RoundedBoxView)this.Element).CornerRadius / 2.0f;
				this.SetNeedsDisplay();
			}
		}
	}
}
