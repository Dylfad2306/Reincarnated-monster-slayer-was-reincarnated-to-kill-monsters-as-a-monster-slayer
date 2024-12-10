using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public class RockShot : ActiveAbility, IAbility
   {
       protected override void OnStartAbility()
       {
           SetAbilityInformation("RockShot", "shouts a rock bullet", 1, 2, 0, "Active");
       }
       public void ActivateAbility()
       {
           Debug.Log("rock shot activated!");
       }
   }

