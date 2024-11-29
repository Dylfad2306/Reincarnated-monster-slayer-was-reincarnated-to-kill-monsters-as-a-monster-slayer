using UnityEngine;

namespace Abiletys.Spell
{
    public class FireBall : ActiveAbility
    {
        // Start is called before the first frame update
        protected override void OnStartAbility()
        {
            SetAbilityInformation("FireBall", "ball of fire", 1, 2, 0 );
        }
    }
}
