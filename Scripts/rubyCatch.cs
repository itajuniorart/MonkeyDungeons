using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubyCatch : MonoBehaviour
{
    //public PlayerInteractions playerInteractions;
    public PlayerVariables playerVariables;
    private void Start()
    {
       if(GameObject.FindGameObjectWithTag("Enemy") != null)
        { 
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject terrain = GameObject.FindGameObjectWithTag("Terrain");
        Physics2D.IgnoreCollision(terrain.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerVariables.rubyInPlayer = true;
            playerVariables.playerRubys += 1;
            playerVariables.playerPoints += 200;
            Destroy(gameObject);
        }
    }
}
