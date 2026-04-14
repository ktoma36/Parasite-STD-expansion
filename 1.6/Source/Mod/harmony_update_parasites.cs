using Verse;
using HarmonyLib;
using rjw;
using System;
using System.Reflection;

namespace rjwparasite
{
	///<summary>
	///roll for parasite update
	///</summary>
	[HarmonyPatch(typeof(Need_Sex), "NeedInterval")]
	static class Need_Sex_PARASITE_Update
	{
		[HarmonyPostfix]
		private static void Need_Sex_PARASITE_Patch(Need_Sex __instance, Pawn ___pawn)
		{
			try
			{
				if (__instance.isInvisible)
					return; // no caravans

				parasite_updater.update(___pawn);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
	}
}
