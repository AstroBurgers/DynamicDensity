using Rage;
using Rage.Attributes;

[assembly: Plugin("DynamicDensity", Description = "Time to get caught in bumper to bumper traffic", Author = "Astro")]

namespace DynamicDensity;

internal class EntryPoint
{
    internal static void Main()
    {
        Game.DisplayNotification("commonmenutu", "arrowright",
            "DynamicDensity",
            "~b~By Astro",
            "Watch out for rush hour!");
        Game.LogTrivial("Reading ini file...");
        Settings.SetupIniFile();
        Game.LogTrivial("Starting MainProcess...");
        GameFiber.StartNew(Process.MainProcess);
    }
}