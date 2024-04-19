using System;
using Verse;
using HarmonyLib;
using System.Reflection;

namespace PIMH
{
    [StaticConstructorOnStartup]
    public static class PIMH
    {
        static PIMH()
        {
            new Harmony("Flestal.PIMH").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
