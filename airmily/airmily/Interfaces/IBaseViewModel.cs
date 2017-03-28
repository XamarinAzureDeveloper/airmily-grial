using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace airmily.Interfaces
{
    public interface IBaseViewModel
    {
        bool IsLoading { get; set; }
        bool IsUnitTesting { get; set; }

        string Title { get; set; }

		// The majority of this is for the custom NavigationBar we tried playing around with. You can probably ignore most of this stuff.
		string OtherText { get; }
		DelegateCommand OtherCmd { get; }
		bool IsBackButton { get; }
		DelegateCommand BackCmd { get; }
    }
}
