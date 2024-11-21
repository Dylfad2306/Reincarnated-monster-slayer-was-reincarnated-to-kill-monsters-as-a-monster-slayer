using Test;
using UnityEngine;

namespace Ui.Abilitys
{
    public class ShowOrHideAbilitys : MonoBehaviour
    {
        public GameObject abilityMenu;

        public SpawnSeketons spawnSeketons;

        bool _gameIsPaused;

        private void Start()
        {
        
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (!_gameIsPaused)
                {
                    // opens menu
                    abilityMenu.SetActive(true);
                    spawnSeketons.enabled = false;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    Time.timeScale = 0f;
                    _gameIsPaused = true;
                }
                else
                {
                    // cloases menu
                    abilityMenu.SetActive(false);
                    spawnSeketons.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1f;
                    _gameIsPaused = false;
                }
            }
        }
    }
}
