using Verse;
using HarmonyLib;
using System;
using rjw;
using RimWorld;
using rjw.Modules.Interactions.Helpers;

namespace rjwstd
{
	public static class std_Boobitis
	{
		public static std_def boobitis = DefDatabase<std_def>.GetNamed("Boobitis");
		public static void update(Pawn pawn)
		{
			if (pawn.health.hediffSet.HasHediff(boobitis.hediff_def))
				UpdateBoobitis(pawn);

		}

		public static void UpdateBoobitis(Pawn pawn)
		{
			var Parts = pawn.GetBreastList();

			if (!Parts.NullOrEmpty())
			{
				foreach (Hediff hed in Parts)
				{
					if (!(HediffHelper.IsNaturalSexPart(hed.def)))
						continue;

					var boob = pawn.health.hediffSet.GetFirstHediffOfDef(boobitis.hediff_def).Severity;
					if (boob >= 1.0)
					{
						//re-add boob dmg someday?
						continue;
					}
					BreastSize size;
					PartSizeCalculator.TryGetBreastSize(hed, out size);
					var cupSize1 = size.GetCupSize();
                    var hedstage = hed.CurStageIndex;
					//GenderHelper.ChangeSex(pawn, () =>
					//{

					HediffComp_SexPart part = hed.TryGetComp<HediffComp_SexPart>();
					part.UpdateSeverity(hed.Severity + boob * 0.01f); // ~0.7 beast grow
                    PartSizeCalculator.TryGetBreastSize(hed, out size);
                    var cupSize2 = size.GetCupSize();
                    //});


                    /*
					 * The cup size doesn't increase with the severity change, not sure if its RJW itself or something here. - Nalzurin
					 */
                    if (cupSize1 != cupSize2)
					{
						
						string message_title = boobitis.LabelCap;
						string message_text = "RJW_BreastsHaveGrownFromBoobitis".Translate(xxx.get_pawnname(pawn), pawn.Possessive(), hed.def.label.ToLower(), size.GetCupSize(), boobitis.LabelCap).CapitalizeFirst();
						Find.LetterStack.ReceiveLetter(message_title, message_text, LetterDefOf.NeutralEvent, pawn);

						//var message = "RJW_BreastsHaveGrownFromBoobitis".Translate(xxx.get_pawnname(pawn));
						//Messages.Message(message, pawn, MessageTypeDefOf.SilentInput);
					}
				}
			}
		}
	}
}
