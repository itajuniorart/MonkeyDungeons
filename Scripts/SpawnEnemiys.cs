using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiys : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float spawnRate = 5f;
    private float nextSpawn = 0f;

    [SerializeField] private PlayerVariables playerVariables;
    [SerializeField] private SystemVariables systemVariables;

    // Update is called once per frame
    void Update()
    {
        if (playerVariables.fullRubies == false && systemVariables.enemySpawnRate <= 10)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            systemVariables.enemySpawnRate += 1;
            GameObject effect = Instantiate(enemy, transform.position, Quaternion.identity);
            yield return null;
        }
          
            yield return new WaitForSeconds(5f);
        
    }
}
