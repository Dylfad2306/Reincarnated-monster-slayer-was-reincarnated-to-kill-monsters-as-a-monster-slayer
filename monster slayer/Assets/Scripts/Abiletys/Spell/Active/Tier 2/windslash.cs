using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windslash : ActiveAbility
{
    protected override void OnStartAbility()
    {
        SetAbilityInformation("windslash", "shouts a blade of wind", 2, 5, 0, "Active", 6);
    }
}
