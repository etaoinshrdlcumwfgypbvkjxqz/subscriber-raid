using RimWorld;
using Verse;
using HarmonyLib;

namespace Polyipseity.SubscriberRaid {
	internal static class FactionSubscribers_RaidEnemy_Patch {
		[HarmonyPatch(typeof(IncidentWorker_RaidEnemy), "TryExecuteWorker")]
		private static class FulfillPawnCount_SetPoints {
			private static void Prefix(IncidentParms parms) {
				if (parms.faction.def == ModDefOf.FactionDefOf.Subscribers) {
					parms.points = ModDefOf.PawnKindDefOf.Subscriber.combatPower * EarlyModStartup.INSTANCE.settings.numberOfSubscriber;
				}
			}
		}

		[HarmonyPatch(typeof(IncidentWorker_Raid), nameof(IncidentWorker_Raid.AdjustedRaidPoints))]
		private static class FulfillPawnCount_PreventAdjustment {
			private static void Postfix(ref float __result, Faction faction) {
				if (faction.def == ModDefOf.FactionDefOf.Subscribers) {
					__result = ModDefOf.PawnKindDefOf.Subscriber.combatPower * EarlyModStartup.INSTANCE.settings.numberOfSubscriber;
				}
			}
		}

		[HarmonyPatch(typeof(IncidentWorker_RaidEnemy), "GetLetterLabel")]
		private static class ReplaceLetterLabel {
			private static void Postfix(ref string __result, IncidentParms parms) {
				if (parms.faction.def == ModDefOf.FactionDefOf.Subscribers) {
					__result = $"{EarlyModStartup.NAMESPACE}.RaidEnemySubscriber_LetterLabel"
						.Translate(parms.faction.def.pawnsPlural, EarlyModStartup.INSTANCE.settings.numberOfSubscriber);
				}
			}
		}

		[HarmonyPatch(typeof(IncidentWorker_RaidEnemy), "GetLetterText")]
		private static class ReplaceLetterText {
			private static void Postfix(ref string __result, IncidentParms parms) {
				if (parms.faction.def == ModDefOf.FactionDefOf.Subscribers) {
					__result = $"{EarlyModStartup.NAMESPACE}.RaidEnemySubscriber_LetterText"
						.Translate(parms.faction.def.pawnsPlural, parms.faction.Name.ApplyTag(parms.faction), EarlyModStartup.INSTANCE.settings.numberOfSubscriber);
				}
			}
		}
	}
}
