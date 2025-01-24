using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbilityBehaviour : MonoBehaviour
{
    [SerializeField] private int _requiredPlayerLevel;
    public int _abilityLevel;
    public int _experienceNeededToLevelUp;
    public int _abilityExperience;
    protected int reqpoints = 0;
    protected string _tagToDamage;
    protected Transform _Spawnpoint;

    [SerializeField] private string _abilityName;

    public string AbilityName
    {
        get { return _abilityName; }
        set { _abilityName = value; }
    }

    public int GetReqPoints()
    {
        return reqpoints;
    }

    public virtual void Init(string tagToDamage, Transform Spawnpoint)
    {
        _tagToDamage = tagToDamage;
        _Spawnpoint = Spawnpoint;
    }

    [SerializeField] private string _description;
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    
    [SerializeField] private int _AbilityTier;

    public int AbilityTier
    {
        get { return _AbilityTier; }
        set { _AbilityTier = value; }
    }
    
    [SerializeField] private string _abilityType;
    
    public string AbilityType
    {
        get { return _abilityType; }
        set { _abilityType = value; }
    }

    void Start()
    {
        _abilityLevel = 0;
        _abilityExperience = 0;
        _experienceNeededToLevelUp = 10; // change to real number
        OnStartAbility();
    }
    
    protected abstract void OnStartAbility();

    protected void SetAbilityInformation(string abilityName, string description, int abilityTier, int requiredPlayerLevel, int abilityLevel, string abilityType, int requiredPoint)
    {
        _abilityName = abilityName;
        _description = description;
        _AbilityTier = abilityTier;
        _requiredPlayerLevel = requiredPlayerLevel;
        _abilityLevel = abilityLevel;
        _abilityType = abilityType;
        reqpoints = requiredPoint;
    }

    public int GetRequiredPlayerLevel()
    {
        return _requiredPlayerLevel;
    }

    public void GainExperience()
    {
        _abilityExperience++;
        if (_abilityExperience >= _experienceNeededToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        _abilityLevel++;
        // increase _experienceNeededToLevelUp
    }

    // passive ability
    //public void ActivateAbility()
    //{
        // Passive: Run code that adds effects
      //  OnActivateAbility();
    //}


    public void DeactivateAbility()
    {
        // Passive: run code that removes effects
        OnDeactivateAbility();
    }

    // active ability
    public void UseAbility()
    {
        // used for active abilities
        OnUseAbility();
        //GainExperience();
    }

    protected virtual void OnActivateAbility() {}
    protected virtual void OnDeactivateAbility() {}
    protected virtual void OnUseAbility() {}
}