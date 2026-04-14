using HarmonyLib;
using System;
using UnityEngine;
using Verse;

namespace rjwstd
{
    [StaticConstructorOnStartup]
    public static class HarmonyStarter
    {
        static HarmonyStarter()
        {
            Harmony harmony = new Harmony("rjw.std");
            harmony.PatchAll();
        }
    }

    public class STD_Mod : Mod
    {
        public static STD_Settings settings;

        public STD_Mod(ModContentPack content)
            : base(content)
        {

           
            settings = GetSettings<STD_Settings>();
        }

        public override string SettingsCategory()
        {
            return "RJW - STD";
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }
    public class STD_Settings : ModSettings
    {
        public static bool std_sex = true;
        public static bool std_floor = true;
        public static bool std_show_roll_to_catch = false;

        public static float std_min_severity_to_pitch = 0.21f;
        public static float std_env_pitch_cleanliness_exaggeration = 2.0f;
        public static float std_env_pitch_dirtiness_exaggeration = 0.5f;
        public static float std_outdoor_cleanliness = -1.0f;
        public static float opp_inf_initial_immunity = 0.55f;
        public static float pawn_spawn_with_std_mul = 1.0f;
        public static float nymph_spawn_with_std_mul = 3.0f;

        public override void ExposeData()
        {

            Scribe_Values.Look(ref std_sex, "std_sex", defaultValue: true);
            Scribe_Values.Look(ref std_floor, "std_floor", defaultValue: true);
            Scribe_Values.Look(ref std_show_roll_to_catch, "std_show_roll_to_catch", defaultValue: false);

            Scribe_Values.Look(ref std_min_severity_to_pitch, "std_min_severity_to_pitch", defaultValue: 0.21f);
            Scribe_Values.Look(ref std_env_pitch_cleanliness_exaggeration, "std_env_pitch_cleanliness_exaggeration", defaultValue: 2.0f);
            Scribe_Values.Look(ref std_env_pitch_dirtiness_exaggeration, "std_env_pitch_dirtiness_exaggeration", defaultValue: 0.5f);
            Scribe_Values.Look(ref std_outdoor_cleanliness, "std_outdoor_cleanliness", defaultValue: -1.0f);
            Scribe_Values.Look(ref opp_inf_initial_immunity, "opp_inf_initial_immunity", defaultValue: 0.55f);
            Scribe_Values.Look(ref pawn_spawn_with_std_mul, "pawn_spawn_with_std_mul", defaultValue: 1.0f);
            Scribe_Values.Look(ref nymph_spawn_with_std_mul, "nymph_spawn_with_std_mul", defaultValue: 3.0f);


            base.ExposeData();
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.CheckboxLabeled("std_sex".Translate(), ref std_sex, "std_sex_desc".Translate());
            listing_Standard.CheckboxLabeled("std_floor".Translate(), ref std_floor, "std_floor_desc".Translate());
            listing_Standard.CheckboxLabeled("std_show_roll_to_catch".Translate(), ref std_show_roll_to_catch, "std_show_roll_to_catch_desc".Translate());
            std_min_severity_to_pitch = (float)Math.Round(listing_Standard.SliderLabeled("std_min_severity_to_pitch".Translate() + ": " + std_min_severity_to_pitch, std_min_severity_to_pitch, 0, 1, tooltip: "std_min_severity_to_pitch_desc".Translate()), 3);
            std_env_pitch_cleanliness_exaggeration = (float)Math.Round(listing_Standard.SliderLabeled("std_env_pitch_cleanliness_exaggeration".Translate() + ": " + std_env_pitch_cleanliness_exaggeration, std_env_pitch_cleanliness_exaggeration, 0, 10, tooltip: "std_env_pitch_cleanliness_exaggeration_desc".Translate()), 3);
            std_env_pitch_dirtiness_exaggeration = (float)Math.Round(listing_Standard.SliderLabeled("std_env_pitch_dirtiness_exaggeration".Translate() + ": " + std_env_pitch_dirtiness_exaggeration, std_env_pitch_dirtiness_exaggeration, 0, 10, tooltip: "std_env_pitch_dirtiness_exaggeration_desc".Translate()), 3);
            std_outdoor_cleanliness = (float)Math.Round(listing_Standard.SliderLabeled("std_outdoor_cleanliness".Translate() + ": " + std_outdoor_cleanliness, std_outdoor_cleanliness, -10, 10, tooltip: "std_outdoor_cleanliness_desc".Translate()), 2);
            opp_inf_initial_immunity = (float)Math.Round(listing_Standard.SliderLabeled("opp_inf_initial_immunity".Translate() + ": " + opp_inf_initial_immunity, opp_inf_initial_immunity, 0, 1, tooltip: "opp_inf_initial_immunity_desc".Translate()), 3);
            pawn_spawn_with_std_mul = (float)Math.Round(listing_Standard.SliderLabeled("pawn_spawn_with_std_mul".Translate() + ": " + pawn_spawn_with_std_mul, pawn_spawn_with_std_mul, 0, 10, tooltip: "pawn_spawn_with_std_mul_desc".Translate()), 2);
            nymph_spawn_with_std_mul = (float)Math.Round(listing_Standard.SliderLabeled("nymph_spawn_with_std_mul".Translate() + ": " + nymph_spawn_with_std_mul, nymph_spawn_with_std_mul, 0, 10, tooltip: "nymph_spawn_with_std_mul_desc".Translate()), 2);
            listing_Standard.End();
        }
    }
    /*    public class STDBase
     *    : ModBase
        {
            public override string ModIdentifier
            {
                get
                {
                    return "RJW_STD";
                }
            }

            public static SettingHandle<bool> std_sex;
            public static SettingHandle<bool> std_floor;
            public static SettingHandle<bool> std_show_roll_to_catch;
            public static SettingHandle<float> std_min_severity_to_pitch;
            public static SettingHandle<float> std_env_pitch_cleanliness_exaggeration;
            public static SettingHandle<float> std_env_pitch_dirtiness_exaggeration;
            public static SettingHandle<float> std_outdoor_cleanliness;
            public static SettingHandle<float> opp_inf_initial_immunity;
            public static SettingHandle<float> pawn_spawn_with_std_mul;
            public static SettingHandle<float> nymph_spawn_with_std_mul;

            public override void DefsLoaded()
            {
                std_sex = Settings.GetHandle("std_sex", Translator.Translate("std_sex"), Translator.Translate("std_sex_desc"), true);
                std_floor = Settings.GetHandle("std_floor", Translator.Translate("std_floor"), Translator.Translate("std_floor_desc"), true);

                std_show_roll_to_catch = Settings.GetHandle("std_show_roll_to_catch", Translator.Translate("std_show_roll_to_catch"), Translator.Translate("std_show_roll_to_catch_desc"), false);
                std_min_severity_to_pitch = Settings.GetHandle("std_min_severity_to_pitch", Translator.Translate("std_min_severity_to_pitch"), Translator.Translate("std_min_severity_to_pitch_desc"), 0.21f);

                std_env_pitch_cleanliness_exaggeration = Settings.GetHandle("std_env_pitch_cleanliness_exaggeration", Translator.Translate("std_env_pitch_cleanliness_exaggeration"), Translator.Translate("std_env_pitch_cleanliness_exaggeration_desc"), 2.0f);
                std_env_pitch_dirtiness_exaggeration = Settings.GetHandle("std_env_pitch_dirtiness_exaggeration", Translator.Translate("std_env_pitch_dirtiness_exaggeration"), Translator.Translate("std_env_pitch_dirtiness_exaggeration_desc"), 0.5f);
                std_outdoor_cleanliness = Settings.GetHandle("std_outdoor_cleanliness", Translator.Translate("std_outdoor_cleanliness"), Translator.Translate("std_outdoor_cleanliness_desc"), -1.0f);

                opp_inf_initial_immunity = Settings.GetHandle("opp_inf_initial_immunity", Translator.Translate("opp_inf_initial_immunity"), Translator.Translate("opp_inf_initial_immunity_desc"), 0.55f);
                pawn_spawn_with_std_mul = Settings.GetHandle("pawn_spawn_with_std_mul", Translator.Translate("pawn_spawn_with_std_mul"), Translator.Translate("pawn_spawn_with_std_mul_desc"), 1.0f);
                nymph_spawn_with_std_mul = Settings.GetHandle("nymph_spawn_with_std_mul", Translator.Translate("nymph_spawn_with_std_mul"), Translator.Translate("nymph_spawn_with_std_mul_desc"), 3.0f);
            }
        }*/
}
