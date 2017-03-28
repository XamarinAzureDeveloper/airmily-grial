using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using airmily.Services.Auth;
using airmily.Services.Models;
using SQLitePCL;
using Xamarin.Forms;

namespace airmily.Services.Azure
{
	public class MockAzure : IAzure
	{
		public IAuth _auth = new Auth.Auth();

		#region Variables
		private List<User> _users;
		private List<Card> _cards;
		private List<CardUser> _cardusers;
		private List<Transaction> _transactions;
		private List<AlbumItem> _albumitems;
		private List<Comment> _comments;
		#endregion

#pragma warning disable 1998
		public MockAzure()
		{
			_users = new List<User>
			{
				new User {
					UserName="Test1 User1",
					UserID="user01",
					AccessLevel=1,
					UnionID="abcd1234"
				},
				new User {
					UserName="Test2 Controller",
					UserID="user02",
					AccessLevel=0,
					UnionID="efgh5678"
				},
				new User {
					UserName="Test3 User2",
					UserID="user03",
					AccessLevel=1,
					UnionID="ijkl9012"
				}
			};
			_cards = new List<Card>
			{
				new Card {
					CardID="card01",
					CardHolder="Test1 User1",
					CardNumber="************0001",
					Currency="GBP",
					Balance="9100.00"
				},
				new Card {
					CardID="card02",
					CardHolder="Test1 User1",
					CardNumber="************0002",
					Currency="GBP",
					Balance="1480.95"
				},
				new Card {
					CardID="card03",
					CardHolder="Test1 User1",
					CardNumber="************0003",
					Currency="EUR",
					Balance="1480.95"
				},
				new Card {
					CardID="card04",
					CardHolder="Other Person",
					CardNumber="************1001",
					Currency="GBP",
					Balance="640.00"
				},
				new Card {
					CardID="card05",
					CardHolder="Also Someone",
					CardNumber="************2001",
					Currency="GBP",
					Balance="1400.00"
				},
				new Card {
					CardID="card06",
					CardHolder="Test2 Controller",
					CardNumber="************3001",
					Currency="GBP",
					Balance="12018.00"
				}
			};
			_cardusers = new List<CardUser>
			{
				new CardUser {
					UserID="user01",
					CardID="card01"
				},
				new CardUser {
					UserID="user01",
					CardID="card02"
				},
				new CardUser {
					UserID="user01",
					CardID="card03"
				},
				new CardUser {
					UserID="user01",
					CardID="card04"
				},
				new CardUser {
					UserID="user02",
					CardID="card01"
				},
				new CardUser {
					UserID="user02",
					CardID="card02"
				},
				new CardUser {
					UserID="user02",
					CardID="card03"
				},
				new CardUser {
					UserID="user02",
					CardID="card04"
				},
				new CardUser {
					UserID="user02",
					CardID="card05"
				},
				new CardUser {
					UserID="user02",
					CardID="card06"
				}
			};
			_transactions = new List<Transaction>
			{
				new Transaction {
					CardID = "card01",
					Description = "HARRODS LTD,CARD & POS OPERATIONS,LONDON",
					Currency = "GBP",
					InternalDifference = "1645.10",
					Amount = "1645.10",
					NegativeAmount = true,
					TransDate = "2017-03-21T00:00:000Z",
					PostDate = "2017-03-21T00:00:000Z",
					ID = "tran01"
				},
				new Transaction {
					CardID = "card01",
					Description = "Burberry Ltd,Horseferry House,London",
					Currency = "USD",
					InternalDifference = "897.00",
					Amount = "897.00",
					NegativeAmount = true,
					TransDate = "2017-03-21T00:00:000Z",
					PostDate = "2017-03-21T00:00:000Z",
					ID = "tran02"
				},
				new Transaction {
					CardID = "card01",
					Description = "HARRODS LTD,CARD & POS OPERATIONS,LONDON",
					Currency = "GBP",
					InternalDifference = "72.00",
					Amount = "72.00",
					NegativeAmount = true,
					TransDate = "2017-03-22T00:00:000Z",
					PostDate = "2017-03-22T00:00:000Z",
					ID = "tran03"
				},
				new Transaction {
					CardID = "card02",
					Description = "Amazon UK Marketplace,5 rue plaeti,123-456-7890",
					Currency = "GBP",
					InternalDifference = "0.00",
					Amount = "72.00",
					NegativeAmount = false,
					TransDate = "2017-03-21T00:00:000Z",
					PostDate = "",
					ID = "tran04"
				},
				new Transaction {
					CardID = "card02",
					Description = "HARRODS LTD,CARD & POS OPERATIONS,LONDON",
					Currency = "GBP",
					InternalDifference = "72.00",
					Amount = "72.00",
					NegativeAmount = true,
					TransDate = "2017-03-21T00:00:000Z",
					PostDate = "2017-03-21T00:00:000Z",
					ID = "tran05"
				},
				new Transaction {
					CardID = "card04",
					Description = "Amazon UK Marketplace,5 rue plaeti,123-456-7890",
					Currency = "EUR",
					InternalDifference = "95.00",
					Amount = "95.00",
					NegativeAmount = true,
					TransDate = "2017-03-23T00:00:000Z",
					PostDate = "2017-03-23T00:00:000Z",
					ID = "tran06"
				},
				new Transaction {
					CardID = "card06",
					Description = "HARRODS LTD,CARD & POS OPERATIONS,LONDON",
					Currency = "GBP",
					InternalDifference = "116.00",
					Amount = "116.00",
					NegativeAmount = true,
					TransDate = "2017-03-24T00:00:000Z",
					PostDate = "2017-03-24T00:00:000Z",
					ID = "tran07"
				},
				new Transaction {
					CardID = "card06",
					Description = "HARRODS LTD,CARD & POS OPERATIONS,LONDON",
					Currency = "GBP",
					InternalDifference = "89.00",
					Amount = "89.00",
					NegativeAmount = true,
					TransDate = "2017-03-24T00:00:000Z",
					PostDate = "2017-03-24T00:00:000Z",
					ID = "tran08"
				}
			};
			_albumitems = new List<AlbumItem>
			{
				new AlbumItem {
					Album = "tran01",
					CardID = "card01",
					IsReceipt = true,
					ImageName = "item01"
				},
				new AlbumItem {
					Album = "tran01",
					CardID = "card01",
					IsReceipt = true,
					ImageName = "item02"
				},
				new AlbumItem {
					Album = "tran01",
					CardID = "card01",
					IsReceipt = false,
					ImageName = "item03"
				},
				new AlbumItem {
					Album = "tran03",
					CardID = "card01",
					IsReceipt = true,
					ImageName = "item04"
				},
				new AlbumItem {
					Album = "tran04",
					CardID = "card02",
					IsReceipt = true,
					ImageName = "item05"
				},
				new AlbumItem {
					Album = "tran04",
					CardID = "card02",
					IsReceipt = false,
					ImageName = "item06"
				},
				new AlbumItem {
					Album = "tran07",
					CardID = "card06",
					IsReceipt = true,
					ImageName = "item07"
				},
				new AlbumItem {
					Album = "tran07",
					CardID = "card06",
					IsReceipt = true,
					ImageName = "item08"
				}
			};
			_comments = new List<Comment>();

			#region DefaultImage
			using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
			{
				foreach (AlbumItem a in _albumitems)
				{
					var resp = client.GetAsync("https://pbs.twimg.com/profile_images/722363524379504640/f0IQJ0Qy.jpg").Result;
					a.Image = resp.Content.ReadAsByteArrayAsync().Result;
					resp.Dispose();
				}
				client.Dispose();
			}
			#endregion
		}
		public async Task SyncAsync()
		{
			return;
		}

		#region Account
		public async Task<bool> LoginAsync(string user, string pass)
		{
			User u = await GetUser(user);

			_auth.CurrentUser = u;
			return _auth.CurrentUser != null;
		}

		public async Task LogoutAsync()
		{
			return;
		}
		#endregion
		#region User
		public async Task<User> GetUser(string userid)
		{
			return _users.First(u => u.UserID == userid);
		}
		#endregion
		#region Cards
		public async Task<bool> UpdateAllCards(User credentials)
		{
			return true;
		}

		public async Task<List<Card>> GetAllCards(User userid)
		{
			switch (userid.AccessLevel)
			{
				case 0:
					return _cards;
				default:
					var cards = _cardusers.Where(cu => cu.UserID == userid.UserID).Select(cu => cu.CardID).ToArray();
					string ids = string.Join(",", cards);
					return _cards.Where(c => ids.Contains(c.CardID)).OrderBy(c => c.CardHolder).ToList();
			}
		}
		#endregion
		#region Transactions
		public async Task<bool> UpdateAllTransactions(User credentials, string cardid)
		{
			return true;
		}

		public async Task<List<Transaction>> GetAllTransactions(string cardid, bool all = false)
		{
			return _transactions.Where(t => t.CardID == cardid).ToList();
		}
		#endregion
		#region AlbumItems
		public async Task<bool> UploadImage(AlbumItem image)
		{
			return true;
		}

		public async Task<List<AlbumItem>> GetAllImages(string albumid)
		{
			return _albumitems.Where(a => a.Album == albumid).ToList();
		}

		public async Task<List<AlbumItem>> GetAllImages(string albumid, bool receipt)
		{
			return _albumitems.Where(a => a.Album == albumid && a.IsReceipt == receipt).ToList();
		}

		public async Task DeleteImage(AlbumItem image)
		{
			return;
		}
		#endregion
		#region Comments
		public async Task<bool> AddComment(Comment c)
		{
			return true;
		}

		public async Task<List<Comment>> GetComments(string imageid)
		{
			return _comments.Where(c => c.ImageID == imageid).ToList();
		}

		public async Task DeleteComment(Comment c)
		{
			return;
		}
		#endregion

#pragma warning restore 1998
	}
}
