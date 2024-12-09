using BepInEx;
using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace NemesisPillars
{
    [BepInDependency("com.rune580.riskofoptions")]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    
    public class NemesisPillars : BaseUnityPlugin
    {
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "icebro";
        public const string PluginName = "nemesispillars";
        public const string PluginVersion = "1.0.0";
        
        public void Awake()
        {
            ConfigEntry<float> pillarConfig = Config.Bind<float>("pillars",
                "pillars",
                2,
                "how many pillars required ,, note setting it manually to values outside the slider might softlock you if you cant pillar skip ,,..,,.,");

            SliderConfig slider = new SliderConfig();
            slider.max = 6;
            slider.min = 1;
            slider.FormatString = "{0:0}";
            
           ModSettingsManager.AddOption(new SliderOption(pillarConfig, slider));
            On.RoR2.MoonBatteryMissionController.Awake += (orig, self) =>
            {
                orig(self);
                self._numRequiredBatteries = (int)pillarConfig.Value;
            };
        }
        
    }
}
