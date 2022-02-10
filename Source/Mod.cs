using Verse;

namespace Polyipseity.SubscriberRaid {
	public class EarlyModStartup : Mod {
		public EarlyModStartup(ModContentPack content) : base(content) {}
	}

	[StaticConstructorOnStartup]
	public static class ModStartup {
		public const string ID = nameof(Polyipseity.SubscriberRaid);

		static ModStartup() {}
	}
}
