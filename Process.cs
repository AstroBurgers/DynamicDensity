using System;
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
            if (!Helper.MainPlayer.Exists()) 
                continue;
            
            var gameTime = World.TimeOfDay;
            bool isRushHour = IsRushHour(gameTime);
            int currentWeather = NativeFunction.Natives.GET_PREV_WEATHER_TYPE_HASH_NAME<int>();
            
            float pedMultiplier = GetDensityMultiplier(
                isRushHour ? (float)Settings.RushPedMult : (float)Settings.NotRushPedMult,
                currentWeather
            );

            float vehMultiplier = GetDensityMultiplier(
                isRushHour ? (float)Settings.RushVehMult : (float)Settings.NotRushVehMult,
                currentWeather
            );
            
            NativeFunction.Natives.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME(pedMultiplier);
            NativeFunction.Natives.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME(vehMultiplier);
        }
    }

    private static bool IsRushHour(TimeSpan time)
    {
        return (time.Hours >= Settings.MRushStart && time.Hours <= Settings.MRushEnd) ||
               (time.Hours >= Settings.LRushStart && time.Hours <= Settings.LRushEnd) ||
               (time.Hours >= Settings.ERushStart && time.Hours <= Settings.ERushEnd);
    }

    private static float GetDensityMultiplier(float baseMultiplier, int weather)
    {
        float weatherMultiplier = weather switch
        {
            (int)WeatherType.Rain or (int)WeatherType.Thunder or (int)WeatherType.Clearing => (float)Settings.RainPedMult,
            (int)WeatherType.Snow or (int)WeatherType.Snowlight or (int)WeatherType.Blizzard or (int)WeatherType.Xmas => (float)Settings.SnowPedMult,
            _ => 1f
        };
        return baseMultiplier * weatherMultiplier;
    }
}