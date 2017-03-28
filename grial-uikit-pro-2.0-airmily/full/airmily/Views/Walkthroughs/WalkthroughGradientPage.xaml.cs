using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace airmily
{
	public partial class WalkthroughGradientPage : CarouselPage
	{
		public WalkthroughGradientPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void GoToStep ()
		{
			var index = Children.IndexOf (CurrentPage);
			var moveToIndex = 0;
			if (index < Children.Count - 1) {
				moveToIndex = index + 1;

				SelectedItem = Children [moveToIndex];
			} else {
				Close ();
			}
		}

		public async void Close ()
		{
			await Navigation.PopModalAsync();
		}

		protected async override void OnCurrentPageChanged ()
		{
			base.OnCurrentPageChanged ();
			var currentStep = (WalkthroughGradientItemTemplate)CurrentPage;

			await currentStep.AnimateIn ();
		}
	}
}
