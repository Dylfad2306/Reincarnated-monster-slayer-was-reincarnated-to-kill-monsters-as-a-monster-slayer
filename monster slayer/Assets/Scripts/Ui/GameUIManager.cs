using System;
using player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Ui
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        [SerializeField] private StyleSheet styleSheet;

        public PlayerStats playerstats;
        public LevelHandeler levelHandeler;

        private void Update()
        {
            createHudStats();
        }

        private void createHudStats()
        {
            var root = document.rootVisualElement;
            
            root.styleSheets.Add(styleSheet);
            root.Clear();

            var playerStatsBox = Create<VisualElement>();
            var playerhealth = Create<Label>();
            var playerLevel = Create<Label>();
            var playerLevelXp = Create<Label>();
            var playerMana = Create<Label>();
            
            playerhealth.text = "Health: " + playerstats.getPlayerHealth() + "/" + playerstats.getPlayerMaxHealth();
            playerLevel.text = "Level: " + levelHandeler.playerLevel;
            playerLevelXp.text = "xp: " + levelHandeler.currentXp + "/" + levelHandeler.requirerdXp;
            playerMana.text = "Mana: " + playerstats.getPlayerMana() + "/" + playerstats.getPlayerMaxMana();
            
            playerStatsBox.Add(playerhealth);
            playerStatsBox.Add(playerMana);
            playerStatsBox.Add(playerLevel);
            playerStatsBox.Add(playerLevelXp);
            
            root.Add(playerStatsBox);
        }
        
        private T Create<T>(params string[] classNames) where T : VisualElement, new()
        {
            var ele = new T();
            foreach (var className in classNames)
            {
                ele.AddToClassList(className);
            }
            return ele;
        }
    }
}