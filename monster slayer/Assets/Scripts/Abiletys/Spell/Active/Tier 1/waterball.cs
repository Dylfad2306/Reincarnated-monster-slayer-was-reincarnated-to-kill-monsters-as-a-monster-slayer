using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterball : ActiveAbility, IAbility
{
    protected override void OnStartAbility()
    {
        SetAbilityInformation("waterball", "shouts a rock bullet", 1, 2, 0, "Active", 3);
    }
    public void ActivateAbility()
    {
        Debug.Log("water shot activated!");
    }
}
