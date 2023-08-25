using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerVariables playerVariables;
    //public SystemVariables.StateGame stade;
    public SystemVariables systemVariables;

    [SerializeField] private Text rubyText;
    [SerializeField] private GameObject menuScrean;
    [SerializeField] private GameObject rubyInPlayer;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text alertText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text gameOverPointsText;
    [SerializeField] private Image displayWaterAmmunitionUI;
    [SerializeField] private Image displayPlayerLifeUI;
    [SerializeField] private Sprite[] spritesWaterAmmunition;
    [SerializeField] private Sprite[] spritesPlayerLife;



    // Start is called before the first frame update
    void Start()
    {
        playerVariables.playerLife = 100;
        playerVariables.playerPoints = 0;
        playerVariables.playerRubys = 0;
        
        playerVariables.rechargeAvailable = false;
        playerVariables.rechargeAnimation = false;
        playerVariables.fullRubies = false;
        playerVariables.rubyInPlayer = false;

        systemVariables.fullAltar = false;
        systemVariables.enemySpawnRate = 0;
        systemVariables.rubySpawnRate = 0;

        systemVariables.state = SystemVariables.StateGame.START;

        if (systemVariables.tutorial == true)
        {
            playerVariables.playerWaterAmmunition = 0;
        }
        else {
            playerVariables.playerWaterAmmunition = 10;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if(playerVariables.playerLife <= 0)
        {
            PlayerDeath();
        }

        if (Input.GetKeyDown(KeyCode.R) && systemVariables.fullAltar == true)
        {
           systemVariables.state = SystemVariables.StateGame.WIN;
        }

        UiPlayer();
    }

    void PlayerDeath() 
    {
        systemVariables.state = SystemVariables.StateGame.GAMEOVER;
    }

    void UiPlayer()
    {

        if (playerVariables.playerRubys >= 1)
        {
            rubyText.text = ":" + playerVariables.playerRubys;
        }

        if (playerVariables.playerWaterAmmunition >= 0 && playerVariables.playerWaterAmmunition <= 10)
        {
            displayWaterAmmunitionUI.sprite = spritesWaterAmmunition[playerVariables.playerWaterAmmunition];
        }

        if (playerVariables.playerPoints >= 1)
        {
            pointsText.text = "Score:" + playerVariables.playerPoints;
        }

        if (playerVariables.playerWaterAmmunition <= 0)
        {
            alertText.text = " Press R in the big pool!";
        }
        else {
            alertText.text = "";
        }

        if (playerVariables.playerLife >= 0)
        {
            displayPlayerLifeUI.sprite = spritesPlayerLife[(playerVariables.playerLife / 10)]; 
        }

        if (playerVariables.rubyInPlayer == true)
        {
            rubyInPlayer.SetActive(true);
        }else {
            rubyInPlayer.SetActive(false);
        }

        if (systemVariables.fullAltar == true)
        {
            alertText.text = "Press R!";
        }


        StadesGameUI();


    }
    void StadesGameUI()
    {
        if (systemVariables.state == SystemVariables.StateGame.START)
        {
            menuScrean.SetActive(false);
            
        }
        if (systemVariables.state == SystemVariables.StateGame.WIN)
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName( "START"))
            {
                systemVariables.tutorial = false;
                SceneManager.LoadScene("GAMEJAM");
            }
            else { StartCoroutine(WinGame()); }

            
        }
        if (systemVariables.state == SystemVariables.StateGame.GAMEOVER )
        {
            //float time = Time.time + 4f;
            //if (Time.time > time) 
            //{
                menuScrean.SetActive(true);
                gameOverText.text = "Game Over! :C";
                gameOverPointsText.text = "Score:" + playerVariables.playerPoints;
            //}
           
        }
    }

    IEnumerator WinGame()
    {
        //float time = 0f;

       // time = Time.time + 2f;
        //if (Time.time > time)
        //{
            menuScrean.SetActive(true);

            gameOverText.text = "You Win!";
            gameOverPointsText.text = "Score:" + playerVariables.playerPoints;
            yield return null;
        //}

        //yield return new WaitForSeconds(0.5f);

        

    }
}
