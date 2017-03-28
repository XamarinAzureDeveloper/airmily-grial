namespace airmily.Services.Interfaces
{
	public interface IAlbumItem
	{
		string ImageName { get; set; }

		string Album { get; set; }
		
		string CardID { get; set; }

		bool IsReceipt { get; set; }

		byte[] Image { get; set; }
	}
}