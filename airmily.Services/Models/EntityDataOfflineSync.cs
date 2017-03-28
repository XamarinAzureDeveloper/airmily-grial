using System;
using airmily.Services.Interfaces;

namespace airmily.Services.Models
{
    public class EntityDataOfflineSync : IEntityDataOfflineSync
    {
        public string ID { get; set; }

        public byte[] Version { get; set; }

		public DateTimeOffset? UpdatedAt { get; set; }

	    public DateTimeOffset? CreatedAt { get; set; }
    }
}