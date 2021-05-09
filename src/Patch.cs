using System;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace Bomb
{
    [HarmonyPatch(typeof(Block), "GetBlastResistance", typeof(IWorldAccessor), typeof(BlockPos), typeof(Vec3f), typeof(EnumBlastType))]
    public class Patch
    {
        public static void Init()
        {
            new Harmony("com.mschelstastic.blastingbomb").PatchAll();
        }

        static bool Prefix(
            Block __instance,
            ref double __result,
            IWorldAccessor world,
            BlockPos pos,
            Vec3f blastDirectionVector,
            EnumBlastType blastType
            )
        {
            if (blastType == EnumBlastType.EntityBlast)
            {
                return true; // execute original
            }

            // 60 is both magic and arbitrary. Its purpose is just to not explode mantle.
            if (__instance.Resistance < 60 && __instance.BlockMaterial == EnumBlockMaterial.Stone)
            {
                __result = 0.0d;
            }
            else
            {
                __result = BlockMaterialUtil.MaterialBlastResistance(blastType, __instance.BlockMaterial);
            }

            return false; // do not execute original
        }
    }
}