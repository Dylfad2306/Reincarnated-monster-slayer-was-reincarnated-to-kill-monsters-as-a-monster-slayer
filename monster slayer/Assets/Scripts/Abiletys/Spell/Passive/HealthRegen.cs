using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : PassiveAbility
{
    protected override void OnStartAbility()
    {
        SetAbilityInformation("HealthRegen", "regenerates health", 1, 2, 0, "passive");
    }
}
