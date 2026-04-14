using Verse;
using HarmonyLib;
using rjw;
using System;
using System.Reflection;

namespace rjwparasite
{
	///<summary>
	///roll for parasite generation for pawns
	///</summary>
	[HarmonyPatch(typeof(PawnGenerator), "GeneratePawn", new Type[] { typeof(PawnGenerationRequest)})]
	static class PawnGenerator_parasite_spreader
	{
		[HarmonyPostfix]
		private static void PawnGenerator_PARASITE_spreader_Patch(ref PawnGenerationRequest request, ref Pawn __result)
		{
			try
			{
				if (request.AllowedDevelopmentalStages == DevelopmentalStage.None ||
					request.AllowedDevelopmentalStages == DevelopmentalStage.Adult)
					if (__result != null)
						parasite_spreader.generate_on(__result);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}
	}
}
