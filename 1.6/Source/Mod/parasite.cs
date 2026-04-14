using System.Collections.Generic;
using System.Linq;
using Verse;
using rjw;

namespace rjwparasite
{
	/// <summary>
	/// Common functions and constants relevant to parasites.
	/// </summary>
	public static class parasite
	{
		//all parasites	
		public static List<parasite_def> all => DefDatabase<parasite_def>.AllDefsListForReading;

		public static Hediff get_infection(Pawn p, parasite_def sd)
		{
			return p.health.hediffSet.GetFirstHediffOfDef(sd.hediff_def);
		}

		public static BodyPartRecord GetRelevantBodyPartRecord(Pawn pawn, parasite_def parasite)
		{
			if (parasite.appliedOnFixedBodyParts == null)
			{
				return null;
			}

			BodyPartDef target = parasite.appliedOnFixedBodyParts.Single();
			return pawn?.RaceProps.body.GetPartsWithDef(target).Single();
			//return pawn?.RaceProps.body.GetPartsWithDef(parasite.appliedOnFixedBodyParts.Single()).Single();
		}
	/*
		public static bool IsImmune(Pawn pawn)
		{
            // Archotech genitalia automagically purge parasites.
            return /* pawn.health.hediffSet.HasHediff(Genital_Helper.archotech_vagina)
            || pawn.health.hediffSet.HasHediff(Genital_Helper.archotech_penis)
            || xxx.is_demon(pawn)
            || xxx.is_slime(pawn)
            || xxx.is_mechanoid(pawn);
        }
	*/
        public static bool PartsImmune(Pawn pawn, List<Hediff> list = null)
		{
			List<string> tagslist;
			if (!list.NullOrEmpty())
				if (list.Any())
					foreach (var y in list)
					{
						tagslist = ((HediffDef_SexPart)y.def).partTags;
						if (!tagslist.NullOrEmpty())
							if (tagslist.Contains("parasiteImmune"))
							{
								return true;
							}
					}
			return false;
		}
	}
}
