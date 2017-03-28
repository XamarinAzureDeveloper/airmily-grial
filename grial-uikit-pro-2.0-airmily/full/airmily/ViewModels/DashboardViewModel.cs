using System.Collections.Generic;

namespace airmily
{
	public class DashboardViewModel
	{
		public List<SampleCategory> Items { 
			get 
			{ 
				return SamplesDefinition.SamplesCategoryList;
			} 
		}
	}
}