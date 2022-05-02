using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestillerScript : MonoBehaviour
{
    public Zones zone_0;
    public Zones zone_1;
    public Zones zone_2;
    public Zones zone_3;

    public ParticleSystem flameEffect;

    public AntiGravity antigZone;

    private void Update()
    {
        if (zone_0.isActive)
        {
            var emission = flameEffect.emission;
            emission.rateOverTime = 0;
            antigZone.gravityDirection = 1;
        }
        if (zone_1.isActive)
        {
            var emission = flameEffect.emission;
            emission.rateOverTime = 10;
            antigZone.gravityDirection = -0.33f;
        }
        if (zone_2.isActive)
        {
            var emission = flameEffect.emission;
            emission.rateOverTime = 20;
            antigZone.gravityDirection = -0.66f;
        }
        if (zone_3.isActive)
        {
            var emission = flameEffect.emission;
            emission.rateOverTime = 30;
            antigZone.gravityDirection = -1;
        }
    }
}
