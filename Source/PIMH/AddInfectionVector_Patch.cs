using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PIMH
{
    [HarmonyPatch(typeof(Pawn_InfectionVectorTracker), "AddInfectionVector",new Type[] {typeof(InfectionPathway)})]
    public static class AddInfectionVector_Patch
    {
        public static bool Prefix(InfectionPathway pathway)
        {
            bool Immune = pathway.OwnerPawn.story.traits.HasTrait(TraitDefOf.BodyPurist);
            if (Immune)
            {
                Log.Message(pathway.OwnerPawn.Name + " is immune to metalhorror.");
                return false;
            }
            return true;
        }
    }
}
