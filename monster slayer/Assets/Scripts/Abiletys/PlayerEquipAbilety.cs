using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipAbilety : MonoBehaviour
{
    List<int>cardNumber = new List<int>();

    int theNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0; theNumber == i; i++)
        {
            if (cardNumber[i] == 1)
            {
                
            }
            else if (cardNumber[i] == 2) {

            }
            else if (cardNumber[i] == 3)
            {

            }
            else if (cardNumber[i] == 4)
            {

            }
            else if (cardNumber[i] == 5)
            {

            }
            else if (cardNumber[i] == 6)
            {

            }
            else if (cardNumber[i] == 7)
            {

            }
            else if (cardNumber[i] == 8)
            {

            }
            else if (cardNumber[i] == 9)
            {

            }
            else if (cardNumber[i] == 10)
            {

            }
            else
            {
                theNumber = 0;
                break;
            }
        }
    }
}
