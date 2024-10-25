using Rage;

namespace DynamicDensity;

internal static class Settings
{
    #region Configs

    // Morning rush start
    internal static int MRushStart = 5;

    // Morning rush end
    internal static int MRushEnd = 10;
    
    // Lunch rush start
    internal static int LRushStart = 11;
    
    // Lunch rush end
    internal static int LRushEnd = 13;
    
    // Evening rush start
    internal static int ERushStart = 16;
    
    // Evening rush end
    internal static int ERushEnd = 18;
    
    // Raining veh multiplier
    internal static double RainVehMult = 1;
    
    // Raining ped multiplier
    internal static double RainPedMult = 0.5;
    
    // Snowing veh multiplier
    internal static double SnowVehMult = 0.5;
    
    // Snowing ped multiplier
    internal static double SnowPedMult = 0.5;
    
    // Rush hour ped mult
    internal static double RushPedMult = 1.5;
    
    // Rush hour veh mult
    internal static double RushVehMult = 1.5;
    
    // Not Rush hour ped mult
    internal static double NotRushPedMult = 0.5;
    
    // Not Rush hour veh mult
    internal static double NotRushVehMult = 0.5;

    #endregion

    internal static InitializationFile Inifile;
    
    internal static void SetupIniFile()
    {
        Inifile = new InitializationFile(@"Plugins/DynamicDensity.ini");
        Inifile.Create();
        // INI File items
        MRushStart = Inifile.ReadInt32("Settings", "Morning Rush Start", MRushStart);
        MRushEnd = Inifile.ReadInt32("Settings", "Morning Rush End", MRushEnd);
        
        LRushStart = Inifile.ReadInt32("Settings", "Lunch Rush Start", LRushStart);
        LRushEnd = Inifile.ReadInt32("Settings", "Lunch Rush End", LRushEnd);
        
        ERushStart = Inifile.ReadInt32("Settings", "Evening Rush Start", ERushStart);
        ERushEnd = Inifile.ReadInt32("Settings", "Evening Rush End", ERushEnd);
        
        RainVehMult = Inifile.ReadDouble("Settings", "Rain Vehicle Multiplier", RainVehMult);
        RainPedMult = Inifile.ReadDouble("Settings", "Rain Ped Multiplier", RainPedMult);
        
        SnowVehMult  = Inifile.ReadDouble("Settings", "Snow Vehicle Multiplier", SnowVehMult);
        SnowPedMult = Inifile.ReadDouble("Settings", "Snow Ped Multiplier", SnowPedMult);
        
        RushVehMult  = Inifile.ReadDouble("Settings", "Rush Hour Vehicle Multiplier", RushVehMult);
        RushPedMult = Inifile.ReadDouble("Settings", "Rush Hour Ped Multiplier", RushPedMult);
        
        NotRushVehMult  = Inifile.ReadDouble("Settings", "Not Rush Hour Vehicle Multiplier", NotRushVehMult);
        NotRushPedMult = Inifile.ReadDouble("Settings", "Not Rush Hour Ped Multiplier", NotRushPedMult);
    }
}