using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeWater : MonoBehaviour
{
    public PlayerVariables playerVariables;

   
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            playerVariables.rechargeAvailable = true;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerVariables.rechargeAvailable = false;
        }
    }
}
