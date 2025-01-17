using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AbilityManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AbilityBehaviour> _abilityList;
    private List<AbilityBehaviour> _availableAbilities;
    void Start()
    {
        _abilityList = new List<AbilityBehaviour>();
        _availableAbilities = new List<AbilityBehaviour>();
        AddAbilities();
    }

    // Find all ability behaviours and add them to the list
    private void AddAbilities()
    {
        AbilityBehaviour[] abilities = GetComponents<AbilityBehaviour>();
        foreach (AbilityBehaviour abilityBehaviour in abilities)
        {
            _abilityList.Add(abilityBehaviour);
        }
    }

    public void OnPlayerLevelUp(int playerLevel)
    {
        foreach (AbilityBehaviour ability in _abilityList)
        {
            if (ability.GetRequiredPlayerLevel() <= playerLevel)
            {
                if (!_availableAbilities.Contains(ability))
                {
                    SetAbilityToAvailable(ability);
                }
            }
        }
    }

    void SetAbilityToAvailable(AbilityBehaviour ability)
    {
       // Debug.Log("Ability "+ ability.AbilityName +" available");
        _availableAbilities.Add(ability);
    }

    public List<AbilityBehaviour> GetActiveAbilities()
    {
        List<AbilityBehaviour> activeAbilities = new List<AbilityBehaviour>();
        foreach (AbilityBehaviour availableAbility in _availableAbilities)
        {
            if (availableAbility is ActiveAbility)
            {
                activeAbilities.Add(availableAbility);
            }
        }

        return activeAbilities;
    }
    
    public List<AbilityBehaviour> GetPassiveAbilities()
    {
        List<AbilityBehaviour> passiveAbilities = new List<AbilityBehaviour>();
        foreach (AbilityBehaviour availableAbility in _availableAbilities)
        {
            if (availableAbility is PassiveAbility)
            {
                passiveAbilities.Add(availableAbility);
            }
        }

        return passiveAbilities;
    }
}