using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using airmily.Services.Interfaces;

namespace airmily.Services.Models
{
    public class WeChatUser : IWeChatUser
    {
        public string Nickname { get; set; }
        public string HeadImgUrl { get; set; }
        public string UnionID { get; set; }
        public string OpenID { get; set; }
	    public int Sex { get; set; }
	    public string Language { get; set; }
	    public string City { get; set; }
	    public string Province { get; set; }
	    public string Country { get; set; }
	    public object[] Privilege { get; set; }
    }
}
