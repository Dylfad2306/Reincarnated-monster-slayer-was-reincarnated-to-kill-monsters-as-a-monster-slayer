using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessOrb : ActiveAbility
{
    protected override void OnStartAbility()
    {
        SetAbilityInformation("darknessOrb", "shouts a rock bullet", 1, 2, 0, "Active", 3);
    }
}
