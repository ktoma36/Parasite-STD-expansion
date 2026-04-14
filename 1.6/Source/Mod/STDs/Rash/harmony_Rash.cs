using Verse;
using HarmonyLib;
using rjw;
using System;
using RimWorld;

namespace rjwparasite
{
	[HarmonyPatch(typeof(AfterSexUtility), "think_about_sex", new Type[] {typeof(Pawn), typeof(Pawn), typeof(bool), typeof(SexProps), typeof(bool)})]
	static class Aftersex_parasiteThoughtApply
	{
		[HarmonyPostfix]
		private static void ThinkAboutDiseasesparasitePatch(Pawn pawn, Pawn partner, bool isReceiving, SexProps props, bool whoring = false)
		{
			try
			{
				parasite_Rash.ThinkAboutDiseases(pawn, partner);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		} 
	}
}
