using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Camera cameraPos;
    Vector2 mousePos;
    public Rigidbody2D rbFire;

    //int xDir;
    //int yDir;
    [SerializeField] PlayerVariables playerVariables;
    [SerializeField] SystemVariables systemVariables;
    [SerializeField] private Animator anime;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cameraPos.ScreenToWorldPoint(Input.mousePosition);

        

        PlayerSpriteAnimations();

    }

    private void FixedUpdate()
    {
        if(systemVariables.state == SystemVariables.StateGame.START && playerVariables.playerLife >= 1) 
        { 
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            rbFire.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rbFire.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rbFire.rotation = angle;
        }
    }

    void PlayerSpriteAnimations() 
    {
        anime.SetFloat("Xaxis", movement.x);
        anime.SetFloat("Yaxis", movement.y);
        anime.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.y <= -1)
        {
            anime.SetInteger("Xidle", 0);
            anime.SetInteger("Yidle", -1);
            //YDir = -1;
        }
        else if (movement.y >= 1)
        {
            anime.SetInteger("Xidle", 0);
            anime.SetInteger("Yidle", 1);
            //YDir = 1;
        }

        if (movement.x <= -1)
        {
            anime.SetInteger("Yidle", 0);
            anime.SetInteger("Xidle", -1);
            //xDir = -1;
        }
        else if (movement.x >= 1)
        {
            anime.SetInteger("Yidle", 0);
            anime.SetInteger("Xidle", 1);
            //xDir = 1;
        }

    }
}
