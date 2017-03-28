using System.Threading.Tasks;
using airmily.Services.Models;
using System.Collections.Generic;

namespace airmily.Services.Azure
{
	/* TODO
	 * Return IEnumerables instead of Lists
	 * Ping restapi.fairfx.com for Updating connectivity
	 * Ping airmilyapp.azurewebsites.net for Sync connectivity
	 */

	public interface IAzure
	{
		Task<bool>				LoginAsync(string user, string pass);

		Task					LogoutAsync();
        
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="userid"></param>
	    /// <returns></returns>
		Task<User>				GetUser(string userid);

		/// <summary>
		/// Creates any cards not in the database, and updates the balance and status of exiting cards
		/// </summary>
		/// <param name="credentials">The User object for their FairFX login</param>
		/// <returns>Whether any new cards were created or not</returns>
		Task<bool>				UpdateAllCards(User credentials);
		/// <summary>
		/// Returns a list of cards for a particular user.
		/// </summary>
		/// <param name="userid">The ID of the user</param>
		/// <param name="all">Whether to include users that are not in an Active status</param>
		/// <returns></returns>
		Task<List<Card>>		GetAllCards(User userid);

		/// <summary>
		/// Checks FairFX, and if there are recent transactions, newer than the latest in the DB, it adds them.
		/// Could do with more logic working with the card balance maybe? Should be ok for now, but can be improved.
		/// </summary>
		/// <param name="credentials">The User object for their FairFX login</param>
		/// <param name="cardid">The CardID you're checking</param>
		/// <returns>Whether any new transactions were created or not</returns>
		Task<bool>				UpdateAllTransactions(User credentials, string cardid);
		/// <summary>
		/// Returns a list of transactions for a particular card.
		/// </summary>
		/// <param name="cardid">The ID of the card</param>
		/// <param name="all">Whether to include internal transactions or not (Card Load/Transfer)</param>
		/// <returns></returns>
		Task<List<Transaction>>	GetAllTransactions(string cardid, bool all = false);

		/// <summary>
		/// Creates the AlbumItem row and uploads the image
		/// </summary>
		/// <param name="image">The item to create</param>
		/// <param name="sync"></param>
		/// <returns>Returns false if the item isn't valid</returns>
		Task<bool>				UploadImage(AlbumItem image);
		/// <summary>
		/// Returns a list of pictures for a particular transaction.
		/// This gets all of the attached images, which can then be sorted between goods and receipts.
		/// </summary>
		/// <param name="albumid">The ID of the album (Should be replaced by the transaction ID?)</param>
		/// <returns></returns>
		Task<List<AlbumItem>>	GetAllImages(string albumid);
		Task<List<AlbumItem>>	GetAllImages(string albumid, bool receipt);
		/// <summary>
		/// UNTESTED
		/// Deletes the AlbumItem row and image
		/// </summary>
		/// <param name="image">The item to delete</param>
		/// <returns>Returns false if the item isn't valid</returns>
		Task					DeleteImage(AlbumItem image);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		Task<bool>				AddComment(Comment c);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="imageid"></param>
		/// <returns></returns>
		Task<List<Comment>>		GetComments(string imageid);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		Task					DeleteComment(Comment c);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task SyncAsync();
	}
}