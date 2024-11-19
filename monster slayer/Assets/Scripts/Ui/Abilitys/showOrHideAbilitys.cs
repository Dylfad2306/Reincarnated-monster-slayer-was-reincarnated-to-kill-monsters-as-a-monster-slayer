using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class showOrHideAbilitys : MonoBehaviour
{
    public GameObject abilityMenu;

    public SpawnSeketons spawnSeketons;

    bool gameIsPaused;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!gameIsPaused)
            {
                // opens menu
                abilityMenu.SetActive(true);
                spawnSeketons.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0f;
                gameIsPaused = true;
            }
            else
            {
                // cloases menu
                abilityMenu.SetActive(false);
                spawnSeketons.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                gameIsPaused = false;
            }
        }
    }
}
