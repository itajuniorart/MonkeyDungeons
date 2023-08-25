using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour
{
    public GameObject hitEffect;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}
