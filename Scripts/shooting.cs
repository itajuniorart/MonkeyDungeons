using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public Camera cameraPos;
    

    public float bulletForce = 20f;

    Vector2 mousePos;

    [SerializeField] private PlayerVariables playerVariables;
    [SerializeField] private SystemVariables systemVariables;

    void Update()
    {
        if (systemVariables.state == SystemVariables.StateGame.START && playerVariables.playerLife >= 1) { 
            if (Input.GetButtonDown("Fire1")) 
            {
                Shoot();
                playerVariables.rechargeAnimation = false;
            }

            if (Input.GetKeyDown(KeyCode.R) && playerVariables.rechargeAvailable == true)
            {
                playerVariables.rechargeAnimation = true;
                Rechard(10);
            }
        }
    }

    void Shoot()

    {
        if(playerVariables.playerWaterAmmunition >= 1) { 

            playerVariables.playerWaterAmmunition -= 1;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    void Rechard(int value) {
        playerVariables.playerWaterAmmunition += value;
        if (playerVariables.playerWaterAmmunition >= 10)
        {
            playerVariables.playerWaterAmmunition = 10;
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "START") {

            systemVariables.tutorial = true;
        }
    }
}
