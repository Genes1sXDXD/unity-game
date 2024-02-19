using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleManager : MonoBehaviour
{
    public float dayDuration = 60f; // Duration of a day in seconds
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script
    public float nightAmbientIntensity = 0.1f; // Intensity of ambient light during the night
    public float dayAmbientIntensity = 1f; // Intensity of ambient light during the day

    private bool isDaytime = true; // Indicates whether it's currently daytime
    private WaitForSeconds dayWait; // Cached WaitForSeconds for day duration

    void Start()
    {
        dayWait = new WaitForSeconds(dayDuration);
        StartCoroutine(DayNightCycle());
    }

    IEnumerator DayNightCycle()
    {
        while (true)
        {
            // Toggle daytime and nighttime
            isDaytime = !isDaytime;

            // Toggle enemy spawning based on the time of day
            enemySpawner.ToggleSpawning(isDaytime);

            // Adjust ambient light intensity
            RenderSettings.ambientIntensity = isDaytime ? dayAmbientIntensity : nightAmbientIntensity;

            // Force re-rendering to apply the changes immediately
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;

            // Wait for the next day or night cycle
            yield return dayWait;
        }
    }
}
