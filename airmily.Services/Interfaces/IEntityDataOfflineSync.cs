using System;
using Microsoft.WindowsAzure.MobileServices;

namespace airmily.Services.Interfaces
{
    public interface IEntityDataOfflineSync
	{
		string ID { get; set; }

        [Version]
        byte[] Version { get; set; }

		[UpdatedAt]
		DateTimeOffset? UpdatedAt { get; set; }

		[CreatedAt]
		DateTimeOffset? CreatedAt { get; set; }
	}
}