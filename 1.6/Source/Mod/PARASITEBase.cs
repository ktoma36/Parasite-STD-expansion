using HarmonyLib;
using System;
using UnityEngine;
using Verse;

namespace rjwparasite
{
    [StaticConstructorOnStartup]
    public static class HarmonyStarter
    {
        static HarmonyStarter()
        {
            Harmony harmony = new Harmony("rjw.parasite");
            harmony.PatchAll();
        }
    }

    public class PARASITE_Mod : Mod
    {
        public static PARASITE_Settings settings;

        public PARASITE_Mod(ModContentPack content)
            : base(content)
        {

           
            settings = GetSettings<PARASITE_Settings>();
        }

        public override string SettingsCategory()
        {
            return "RJW - Parasite";
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }
    public class PARASITE_Settings : ModSettings
    {
        public static bool parasite_sex = true;
        public static bool parasite_floor = true;
        public static bool parasite_show_roll_to_catch = false;

        public static float parasite_min_severity_to_pitch = 0.21f;
        public static float parasite_env_pitch_cleanliness_exaggeration = 2.0f;
        public static float parasite_env_pitch_dirtiness_exaggeration = 0.5f;
        public static float parasite_outdoor_cleanliness = -1.0f;
        public static float opp_inf_initial_immunity = 0.55f;
        public static float pawn_spawn_with_parasite_mul = 1.0f;
        public static float nymph_spawn_with_parasite_mul = 3.0f;

        public override void ExposeData()
        {

            Scribe_Values.Look(ref parasite_sex, "parasite_sex", defaultValue: true);
            Scribe_Values.Look(ref parasite_floor, "parasite_floor", defaultValue: true);
            Scribe_Values.Look(ref parasite_show_roll_to_catch, "parasite_show_roll_to_catch", defaultValue: false);

            Scribe_Values.Look(ref parasite_min_severity_to_pitch, "parasite_min_severity_to_pitch", defaultValue: 0.21f);
            Scribe_Values.Look(ref parasite_env_pitch_cleanliness_exaggeration, "parasite_env_pitch_cleanliness_exaggeration", defaultValue: 2.0f);
            Scribe_Values.Look(ref parasite_env_pitch_dirtiness_exaggeration, "parasite_env_pitch_dirtiness_exaggeration", defaultValue: 0.5f);
            Scribe_Values.Look(ref parasite_outdoor_cleanliness, "parasite_outdoor_cleanliness", defaultValue: -1.0f);
            Scribe_Values.Look(ref opp_inf_initial_immunity, "opp_inf_initial_immunity", defaultValue: 0.55f);
            Scribe_Values.Look(ref pawn_spawn_with_parasite_mul, "pawn_spawn_with_parasite_mul", defaultValue: 1.0f);
            Scribe_Values.Look(ref nymph_spawn_with_parasite_mul, "nymph_spawn_with_parasite_mul", defaultValue: 3.0f);


            base.ExposeData();
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.CheckboxLabeled("parasite_sex".Translate(), ref parasite_sex, "parasite_sex_desc".Translate());
            listing_Standard.CheckboxLabeled("parasite_floor".Translate(), ref parasite_floor, "parasite_floor_desc".Translate());
            listing_Standard.CheckboxLabeled("parasite_show_roll_to_catch".Translate(), ref parasite_show_roll_to_catch, "parasite_show_roll_to_catch_desc".Translate());
            parasite_min_severity_to_pitch = (float)Math.Round(listing_Standard.SliderLabeled("parasite_min_severity_to_pitch".Translate() + ": " + parasite_min_severity_to_pitch, parasite_min_severity_to_pitch, 0, 1, tooltip: "parasite_min_severity_to_pitch_desc".Translate()), 3);
            parasite_env_pitch_cleanliness_exaggeration = (float)Math.Round(listing_Standard.SliderLabeled("parasite_env_pitch_cleanliness_exaggeration".Translate() + ": " + parasite_env_pitch_cleanliness_exaggeration, parasite_env_pitch_cleanliness_exaggeration, 0, 10, tooltip: "parasite_env_pitch_cleanliness_exaggeration_desc".Translate()), 3);
            parasite_env_pitch_dirtiness_exaggeration = (float)Math.Round(listing_Standard.SliderLabeled("parasite_env_pitch_dirtiness_exaggeration".Translate() + ": " + parasite_env_pitch_dirtiness_exaggeration, parasite_env_pitch_dirtiness_exaggeration, 0, 10, tooltip: "parasite_env_pitch_dirtiness_exaggeration_desc".Translate()), 3);
            parasite_outdoor_cleanliness = (float)Math.Round(listing_Standard.SliderLabeled("parasite_outdoor_cleanliness".Translate() + ": " + parasite_outdoor_cleanliness, parasite_outdoor_cleanliness, -10, 10, tooltip: "parasite_outdoor_cleanliness_desc".Translate()), 2);
            opp_inf_initial_immunity = (float)Math.Round(listing_Standard.SliderLabeled("opp_inf_initial_immunity".Translate() + ": " + opp_inf_initial_immunity, opp_inf_initial_immunity, 0, 1, tooltip: "opp_inf_initial_immunity_desc".Translate()), 3);
            pawn_spawn_with_parasite_mul = (float)Math.Round(listing_Standard.SliderLabeled("pawn_spawn_with_parasite_mul".Translate() + ": " + pawn_spawn_with_parasite_mul, pawn_spawn_with_parasite_mul, 0, 10, tooltip: "pawn_spawn_with_parasite_mul_desc".Translate()), 2);
            nymph_spawn_with_parasite_mul = (float)Math.Round(listing_Standard.SliderLabeled("nymph_spawn_with_parasite_mul".Translate() + ": " + nymph_spawn_with_parasite_mul, nymph_spawn_with_parasite_mul, 0, 10, tooltip: "nymph_spawn_with_parasite_mul_desc".Translate()), 2);
            listing_Standard.End();
        }
    }
    /*    public class PARASITEBase
     *    : ModBase
        {
            public override string ModIdentifier
            {
                get
                {
                    return "RJW_parasite";
                }
            }

            public static SettingHandle<bool> parasite_sex;
            public static SettingHandle<bool> parasite_floor;
            public static SettingHandle<bool> parasite_show_roll_to_catch;
            public static SettingHandle<float> parasite_min_severity_to_pitch;
            public static SettingHandle<float> parasite_env_pitch_cleanliness_exaggeration;
            public static SettingHandle<float> parasite_env_pitch_dirtiness_exaggeration;
            public static SettingHandle<float> parasite_outdoor_cleanliness;
            public static SettingHandle<float> opp_inf_initial_immunity;
            public static SettingHandle<float> pawn_spawn_with_parasite_mul;
            public static SettingHandle<float> nymph_spawn_with_parasite_mul;

            public override void DefsLoaded()
            {
                parasite_sex = Settings.GetHandle("parasite_sex", Translator.Translate("parasite_sex"), Translator.Translate("parasite_sex_desc"), true);
                parasite_floor = Settings.GetHandle("parasite_floor", Translator.Translate("parasite_floor"), Translator.Translate("parasite_floor_desc"), true);

                parasite_show_roll_to_catch = Settings.GetHandle("parasite_show_roll_to_catch", Translator.Translate("parasite_show_roll_to_catch"), Translator.Translate("parasite_show_roll_to_catch_desc"), false);
                parasite_min_severity_to_pitch = Settings.GetHandle("parasite_min_severity_to_pitch", Translator.Translate("parasite_min_severity_to_pitch"), Translator.Translate("parasite_min_severity_to_pitch_desc"), 0.21f);

                parasite_env_pitch_cleanliness_exaggeration = Settings.GetHandle("parasite_env_pitch_cleanliness_exaggeration", Translator.Translate("parasite_env_pitch_cleanliness_exaggeration"), Translator.Translate("parasite_env_pitch_cleanliness_exaggeration_desc"), 2.0f);
                parasite_env_pitch_dirtiness_exaggeration = Settings.GetHandle("parasite_env_pitch_dirtiness_exaggeration", Translator.Translate("parasite_env_pitch_dirtiness_exaggeration"), Translator.Translate("parasite_env_pitch_dirtiness_exaggeration_desc"), 0.5f);
                parasite_outdoor_cleanliness = Settings.GetHandle("parasite_outdoor_cleanliness", Translator.Translate("parasite_outdoor_cleanliness"), Translator.Translate("parasite_outdoor_cleanliness_desc"), -1.0f);

                opp_inf_initial_immunity = Settings.GetHandle("opp_inf_initial_immunity", Translator.Translate("opp_inf_initial_immunity"), Translator.Translate("opp_inf_initial_immunity_desc"), 0.55f);
                pawn_spawn_with_parasite_mul = Settings.GetHandle("pawn_spawn_with_parasite_mul", Translator.Translate("pawn_spawn_with_parasite_mul"), Translator.Translate("pawn_spawn_with_parasite_mul_desc"), 1.0f);
                nymph_spawn_with_parasite_mul = Settings.GetHandle("nymph_spawn_with_parasite_mul", Translator.Translate("nymph_spawn_with_parasite_mul"), Translator.Translate("nymph_spawn_with_parasite_mul_desc"), 3.0f);
            }
        }*/
}
