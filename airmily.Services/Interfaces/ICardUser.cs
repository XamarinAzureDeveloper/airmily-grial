using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airmily.Services.Interfaces
{
	public interface ICardUser
	{
		string CardID { get; set; }

		string UserID { get; set; }
	}
}
