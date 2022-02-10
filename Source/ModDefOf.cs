using RimWorld;
using Verse;

namespace Polyipseity.SubscriberRaid {
	public static class ModDefOf {
		[DefOf]
		public static class FactionDefOf {
			public static FactionDef Subscribers = null;

			static FactionDefOf() {
				DefOfHelper.EnsureInitializedInCtor(typeof(FactionDefOf));
			}
		}

		[DefOf]
		public static class PawnKindDefOf {
			public static PawnKindDef Subscriber = null;
			public static PawnKindDef First_Subscriber = null;

			static PawnKindDefOf() {
				DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
			}
		}
	}
}
