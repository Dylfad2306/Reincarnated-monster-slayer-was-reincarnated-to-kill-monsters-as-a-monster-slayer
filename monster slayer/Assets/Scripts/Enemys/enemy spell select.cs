using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Random = System.Random;

public class enemyspellselect : MonoBehaviour
{
    public GameObject player;
    public AbilityManager abilityManager;
    public int abilityPoints = 0; //11

    public Transform EnemySpellSpawnPoint;
    public List<AbilityBehaviour> addedAbilities;

    private void Start()
    {
        player = GameObject.Find("playerObj");
        abilityManager = player.GetComponent<AbilityManager>();
        
        List<AbilityBehaviour> availableAbilities = new List<AbilityBehaviour>();
        foreach (AbilityBehaviour ability in abilityManager._abilityList)
        {
            if (ability.GetReqPoints() <= abilityPoints)
            {
                availableAbilities.Add((ability));
            }
        }
        
        while (abilityPoints > 0)
        {
            availableAbilities = checkpossebalabiliety(availableAbilities);
        }
    }
    

    private List<AbilityBehaviour> checkpossebalabiliety(List<AbilityBehaviour> previousAbiliies)
    {
        List<AbilityBehaviour> availableAbilities = new List<AbilityBehaviour>();
        foreach (AbilityBehaviour ability in previousAbiliies)
        {
            if (ability.GetReqPoints() <= abilityPoints)
            {
                availableAbilities.Add((ability));
            }
        }

        if (availableAbilities.Count == 0)
        {
            abilityPoints = 0;
            return null;
        }
        
        Random random = new Random();
        int randomNumber = random.Next(0, availableAbilities.Count); // upper bound is exclusive
        string selectedAbility = availableAbilities[randomNumber].AbilityName;
        AbilityBehaviour abilityToAdd = AbilityAdderFactory.AddAbility(gameObject, selectedAbility);
        print(abilityToAdd);
        abilityToAdd.Init("Player", EnemySpellSpawnPoint);
        abilityPoints -= availableAbilities[randomNumber].GetReqPoints();
        availableAbilities.Remove(availableAbilities[randomNumber]);
        
        addedAbilities.Add(abilityToAdd);
        
        
        return availableAbilities;
    }
}
static class AbilityAdderFactory {
    
    static public AbilityBehaviour AddAbility(GameObject gameObjectToAdd, string abilityToAdd)
    {
        AbilityBehaviour ability = null;
        
        switch(abilityToAdd) {
            // tier 1
            //fire
                case "FireBall":
                ability = gameObjectToAdd.AddComponent<FireBall>();
                    break;
            //water
                case "waterball":
                ability = gameObjectToAdd.AddComponent<waterball>();
                    break;
            //wind
            
            //earth
                case "RockShot":
                ability = gameObjectToAdd.AddComponent<RockShot>();
                    break;
            //light
                case "HolyShot":
                ability = gameObjectToAdd.AddComponent<HolyShot>();
                    break;
            //dark
                case "darknessOrb":
                ability = gameObjectToAdd.AddComponent<darknessOrb>();
                    break;
            //passive
                case "HealthRegen":
                ability = gameObjectToAdd.AddComponent<HealthRegen>();
                    break;
            //tier 2
            //fire
                
            //water
                
            //wind
                case "windslash":
                ability = gameObjectToAdd.AddComponent<windslash>();
                    break;
            //earth
                
            //light
                
            //dark
            
            //passive
            default:
                return null;
        }
        
        return ability;
    }
}