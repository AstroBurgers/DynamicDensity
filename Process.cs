using Rage;
using Rage.Native;

namespace DynamicDensity;

internal static class Process
{
    internal static void MainProcess()
    {
        while (true)
        {
            GameFiber.Yield();
            if (!Helper.MainPlayer.Exists()) {
                continue;
            }
            // IN 24H FORMAT
            var gameTime = World.TimeOfDay;
            bool isMorningRush = gameTime.Hours >= Settings.MRushStart && gameTime.Hours <= Settings.MRushEnd;
            bool isLunchRush = gameTime.Hours >= Settings.LRushStart && gameTime.Hours <= Settings.LRushEnd;
            bool isEveningRush = gameTime.Hours >= Settings.ERushStart && gameTime.Hours <= Settings.ERushEnd;
            int currentWeather = NativeFunction.Natives.GET_PREV_WEATHER_TYPE_HASH_NAME<int>();

            // airport
            // Lsquare
            // Casino
            // Unused^

            if (isMorningRush || isLunchRush || isEveningRush)
            {
                switch (currentWeather)
                {
                    case (int)WeatherType.Rain:
                    case (int)WeatherType.Thunder:
                    case (int)WeatherType.Clearing:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult * (float)Settings.RainPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult * (float)Settings.RainVehMult);
                        break;
                    case (int)WeatherType.Snow:
                    case (int)WeatherType.Snowlight:
                    case (int)WeatherType.Blizzard:
                    case (int)WeatherType.Xmas:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult * (float)Settings.SnowPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult * (float)Settings.SnowVehMult);
                        break;
                    default:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult);
                        break;
                }
            }
            else
            {
                switch (currentWeather)
                {
                    case (int)WeatherType.Rain:
                    case (int)WeatherType.Thunder:
                    case (int)WeatherType.Clearing:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult * (float)Settings.RainPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult * (float)Settings.RainVehMult);
                        break;
                    case (int)WeatherType.Snow:
                    case (int)WeatherType.Snowlight:
                    case (int)WeatherType.Blizzard:
                    case (int)WeatherType.Xmas:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult * (float)Settings.SnowPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult * (float)Settings.SnowVehMult);
                        break;
                    default:
                        NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult);
                        NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult);
                        break;
                }
            }
        }
    }
}
