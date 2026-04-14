using Verse;
using HarmonyLib;
using System;
using rjw;
using RimWorld;

namespace rjwparasite
{
	[HarmonyPatch(typeof(parasite_updater), "update")]
	static class parasite_updater_Syphilis
	{
		[HarmonyPostfix]
		private static void updateparasite(Pawn p)
		{
			try
			{
				parasite_Syphilis.update(p);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
	}
}
