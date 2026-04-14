using Verse;
using HarmonyLib;
using System;
using rjw;

namespace rjwparasite
{
	///<summary>
	///boobitis increase sex need/make pawn horny
	///</summary>
	[HarmonyPatch(typeof(Need_Sex), "diseasefactor")]
	static class SexNeed_diseasefactorparasite_Boobitis
	{
		[HarmonyPostfix]
		private static void diseasefactor_parasitePatch(Pawn pawn, ref float __result)
		{
			try
			{
				if (pawn.health.hediffSet.HasHediff(parasite_Boobitis.boobitis.hediff_def))
				{
					__result *= 3f;
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
	}

	/// <summary>
	/// boobitis increase breast size
	/// this is probably outdated, but keep it for now atleast
	/// </summary>
	[HarmonyPatch(typeof(parasite_updater), "update")]
	static class parasite_updater_Boobitis
	{
		[HarmonyPostfix]
		private static void updateparasite(Pawn p)
		{
			try
			{
				parasite_Boobitis.update(p);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
	}
}
