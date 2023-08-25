using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private PlayerVariables playerVariables;
    [SerializeField] private SystemVariables systemVariables;
    [SerializeField] private GameObject ruby;
    private int lifeEnemy = 1;
    


    
    private int randomNumber;
    private int total;
    private int[] table = {
        90, 
        10  
    };

    // Start is called before the first frame update
    void Start()
    {
        //Total de numeros randomicos no peso da IA
        foreach (var item in table)
        {
            total += item;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && lifeEnemy >= 1)
        {
            lifeEnemy = 0;
            if (lifeEnemy <= 0)
            {
                Destroy(gameObject, 0.2f);
                systemVariables.enemySpawnRate -= 1;
                if (playerVariables.playerRubys < 4)
                {

                    
                    randomNumber = Random.Range(0, total);


                     
                    for (int i = 0; i < table.Length; i++)
                    {

                        if (randomNumber <= table[i])
                        {
                            InstantiateEnemyDeath(i);
                        }
                        else
                        {
                            randomNumber -= table[i];
                        }
                    }

                    
                }
            }
        }
    }

    void InstantiateEnemyDeath( int i) 
    {
        
        if (i == 0)
        {
            playerVariables.playerPoints += 100;
        }

        if (i == 1 && systemVariables.rubySpawnRate < 4)
        {
            GameObject effect = Instantiate(ruby, transform.position, Quaternion.identity);
            systemVariables.rubySpawnRate += 1;
        }

        if(i == 1 && systemVariables.rubySpawnRate >= 4)
        {
            playerVariables.playerPoints += 1000;
        }

    }
}
