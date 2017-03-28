using System.Collections.Generic;
using Xamarin.Forms;

namespace airmily
{
	public class DashboardScrollableViewModel
	{
		public DashboardScrollableViewModel()
		{
			Items = SamplesDefinition.SamplesCategoryList;
			ItemsReverse = new List<SampleCategory>(SamplesDefinition.CreateSamples().Values);
			ItemsReverse.Reverse();

			foreach (var item in ItemsReverse)
			{
				item.BackgroundColor = Color.FromHex("#525ABB");
				item.Badge = 0;
			}
		}

		public List<SampleCategory> ItemsReverse { get; set; }

		public List<SampleCategory> Items { get; set; }
	}
}