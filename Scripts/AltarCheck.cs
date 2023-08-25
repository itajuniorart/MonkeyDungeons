using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarCheck : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesChange;
    [SerializeField] private SpriteRenderer spriteNow;
    [SerializeField] private Animator anime;
    [SerializeField] private int rubysInAltar;



    
    public PlayerVariables playerVariables;
    public SystemVariables systemVariables;
    // Start is called before the first frame update
    private void Start()
    {
        anime.enabled = false;

        
    }


    private void Update()
    {
        print(rubysInAltar);
        if (rubysInAltar >= 4)
        {
            playerVariables.fullRubies = true;
            anime.enabled = true;
            spriteNow.sprite = spritesChange[6];
            anime.Play("Altar Full"); //
            systemVariables.fullAltar = true;

        }
        else { spriteNow.sprite = spritesChange[rubysInAltar]; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            if (playerVariables.playerRubys >= 1)
            {
                if (playerVariables.playerRubys > 4)
                {
                    rubysInAltar = 4;
                    
                }
                else {
                    playerVariables.rubyInPlayer = false;
                    rubysInAltar = playerVariables.playerRubys;
                }
                 
            }


        }

    }
}
