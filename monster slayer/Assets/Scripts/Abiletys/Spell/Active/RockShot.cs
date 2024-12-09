using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public class RockShot : ActiveAbility
   {
       protected override void OnStartAbility()
       {
           SetAbilityInformation("rock shot", "shouts a rock bullet", 1, 2, 0, "Active");
       }
   }

