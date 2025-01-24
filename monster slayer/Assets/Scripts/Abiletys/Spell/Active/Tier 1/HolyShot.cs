using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyShot : ActiveAbility
{
    protected override void OnStartAbility()
    {
        SetAbilityInformation("HolyShot", "shouts a rock bullet", 1, 2, 0, "Active", 3);
    }
}
