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
            var GameTime = World.DateTime;
            bool IsMorningRush = GameTime.Hour >= Settings.MRushStart && GameTime.Hour <= Settings.MRushEnd;
            bool IsLunchRush = GameTime.Hour >= Settings.LRushStart && GameTime.Hour <= Settings.LRushEnd;
            bool IsEveningRush = GameTime.Hour >= Settings.ERushStart && GameTime.Hour <= Settings.ERushEnd;
            int currentWeather = NativeFunction.Natives.GET_PREV_WEATHER_TYPE_HASH_NAME<int>();

            // airport
            // Lsquare
            // Casino
            // Unused^

            if (IsMorningRush || IsLunchRush || IsEveningRush)
            {
                // Make scaling configurable
                if (currentWeather == (int)WeatherType.Rain || currentWeather == (int)WeatherType.Thunder ||
                    currentWeather == (int)WeatherType.Clearing)
                {
                    NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult * (float)Settings.RainPedMult);
                    NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult * (float)Settings.RainVehMult);
                    continue;
                }

                if (currentWeather == (int)WeatherType.Snow ||
                    currentWeather == (int)WeatherType.Snowlight ||
                    currentWeather == (int)WeatherType.Blizzard || currentWeather == (int)WeatherType.Xmas)
                {
                    NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult * (float)Settings.SnowPedMult);
                    NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult * (float)Settings.SnowVehMult);
                    continue;
                }

                NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushPedMult);
                NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.RushVehMult);
            }
            else
            {
                // Make scaling configurable
                if (currentWeather == (int)WeatherType.Rain || currentWeather == (int)WeatherType.Thunder ||
                    currentWeather == (int)WeatherType.Clearing)
                {
                    NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult * (float)Settings.RainPedMult);
                    NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult * (float)Settings.RainVehMult);
                    continue;
                }

                if (currentWeather == (int)WeatherType.Snow ||
                    currentWeather == (int)WeatherType.Snowlight ||
                    currentWeather == (int)WeatherType.Blizzard || currentWeather == (int)WeatherType.Xmas)
                {
                    NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult * (float)Settings.SnowPedMult);
                    NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult * (float)Settings.SnowVehMult);
                    continue;
                }

                NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushPedMult);
                NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME((float)Settings.NotRushVehMult);
            }
        }
    }
}