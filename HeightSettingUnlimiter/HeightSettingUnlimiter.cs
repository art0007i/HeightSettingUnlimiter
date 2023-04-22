using HarmonyLib;
using NeosModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using System.Reflection.Emit;

namespace HeightSettingUnlimiter
{
    public class HeightSettingUnlimiter : NeosMod
    {
        public override string Name => "HeightSettingUnlimiter";
        public override string Author => "art0007i";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/art0007i/HeightSettingUnlimiter/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("me.art0007i.HeightSettingUnlimiter");
            harmony.PatchAll();

        }

        [HarmonyPatch]
        class HeightSettingUnlimiterPatch
        {
            static IEnumerable<MethodBase> TargetMethods()
            {
                yield return AccessTools.Method("FrooxEngine.FullBodyCalibratorDialog+<>c__DisplayClass23_0:<BuildHeightUI>b__0");
                yield return AccessTools.Method("FrooxEngine.SettingsDialog+<>c__DisplayClass5_0:<OnAttach>b__0");
                yield return AccessTools.Method(typeof(TutorialScreen), "BuildBasicSettingsScreen");
            }

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes)
            {
                foreach (var code in codes)
                {
                    if (code.Is(OpCodes.Ldc_R8, 2.2))
                    {
                        code.operand = 10.0d;
                    }
                    yield return code;
                }
            }
        }
    }
}