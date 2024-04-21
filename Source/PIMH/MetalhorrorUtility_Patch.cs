using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PIMH
{
    [HarmonyPatch(typeof(MetalhorrorUtility), "Infect")]
    public static class MetalhorrorUtility_Patch
    {
        public static void Postfix(Pawn pawn, Pawn source, string descKey, string descResolved)
        {
            //Log.Message(pawn.Name+ " : " + descKey+" : "+source.Name);
            bool Immune = pawn.story.traits.HasTrait(TraitDefOf.BodyPurist);
            Hediff h_;
            if (Immune && pawn.health.hediffSet.TryGetHediff(HediffDefOf.MetalhorrorImplant, out h_))
            {
                Log.Message("Metalhorror in " + pawn.Name + " dead in contradiction. ("+descKey+")");
                pawn.health.RemoveHediff(h_);
            }
        }
    }
}
