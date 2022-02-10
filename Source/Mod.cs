using Verse;
using UnityEngine;
using HarmonyLib;

namespace Polyipseity.SubscriberRaid {
	public sealed class EarlyModStartup : Mod {
		public static string NAMESPACE = typeof(EarlyModStartup).Namespace;
		public static readonly Harmony HARMONY = new Harmony(NAMESPACE);
		public static EarlyModStartup INSTANCE { get; private set; }
		private readonly Settings _settings;
		public Settings settings { get { return _settings; } }

		public EarlyModStartup(ModContentPack content) : base(content) {
			this._settings = GetSettings<Settings>();
			INSTANCE = this;
		}

		public override void DoSettingsWindowContents(Rect inRect) { settings.DoSettingsWindowContents(inRect); }

		public override void WriteSettings() { settings.WriteSettings(); }

		public override string SettingsCategory() { return settings.SettingsCategory(); }
	}

	[StaticConstructorOnStartup]
	public static class ModStartup {
		public const string ID = nameof(Polyipseity.SubscriberRaid);

		static ModStartup() {
			EarlyModStartup.HARMONY.PatchAll();
			Log.Message($"[{EarlyModStartup.HARMONY.Id}] Applied patches.");
		}
	}

	public sealed class Settings : ModSettings {
		private const int NUMBER_OF_SUBSCRIBER_DEFAULT = 100;
		public int numberOfSubscriber = NUMBER_OF_SUBSCRIBER_DEFAULT;
		private string numberOfSubscriberBuffer = NUMBER_OF_SUBSCRIBER_DEFAULT.ToString();

		internal void DoSettingsWindowContents(Rect rect) {
			Listing_Standard listing = new Listing_Standard();
			listing.Begin(rect);
			listing.TextFieldNumericLabeled(nameof(numberOfSubscriber), ref numberOfSubscriber, ref numberOfSubscriberBuffer, min: 0, max: int.MaxValue);
			listing.End();
		}

		public override void ExposeData()
		{
			Scribe_Values.Look(ref numberOfSubscriber, nameof(numberOfSubscriber), NUMBER_OF_SUBSCRIBER_DEFAULT);
			base.ExposeData();
		}

		internal void WriteSettings() {
			Write();
		}

		internal string SettingsCategory() {
			return ModStartup.ID.Translate();
		}
	}
}
