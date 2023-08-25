using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float enemyVelocity;
    [SerializeField] private int damage = 10;
    private float nextAttack = 0f;
    private float attackRate = 3f;

    private Transform player;
    private float distanceToPlayer;
    [SerializeField] private PlayerVariables playerVariables;

    [SerializeField] private SystemVariables systemVariables;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyVelocity = 1f;
        distanceToPlayer = 0.6f;
    }

    private void FixedUpdate()
    {
        if (systemVariables.state == SystemVariables.StateGame.START && playerVariables.playerLife >= 1)
        {
            FollowAI();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            enemyVelocity = 0f;
        } 
    }

    void FollowAI() {
        if (Vector2.Distance(transform.position, player.position) > distanceToPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemyVelocity * Time.fixedDeltaTime);
        }
        else {
            enemyAttack();
        }
    }

    void enemyAttack()
    {
        StartCoroutine(Attack());
        
    }

    IEnumerator Attack()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            playerVariables.playerLife -= damage;
            yield return null;
            print(playerVariables.playerLife);
        }

        yield return new WaitForSeconds(1f);

    }

}

