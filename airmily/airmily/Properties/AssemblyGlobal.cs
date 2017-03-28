using System;

namespace airmily
{
	public static class AssemblyGlobal
	{
		public const string Company = "BEIER360 Limited";

		public const string Year = "2017";

		public const string Copyright = Company + " - " + Year;

		public const string Product = "airmily";

#if DEBUG
		public const string Configuration = "Debug";
#elif RELEASE
		public const string Configuration = "Release";
#else
		public const string Configuration = "Unknown";
#endif
	}
}

