using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public UI uiScript;
    public float speed;
    public int hpEnemy;
    Vector3 dirNormalized;
    Vector3 target;
    float SlowTimer = 0;
    float speedHalved = 0.15f;
    float speedNormal = 0.3f;

    void Start()
    {
        hpEnemy = 100;
        dirNormalized = (target - transform.position).normalized;
    }

    void Update()
    {
        if (SlowTimer > 0)
        {
            SlowTimer -= Time.deltaTime;
        }
        else if(SlowTimer <= 0 && speed== speedHalved)
        {
            speed = speedNormal;
        }

        if (Vector3.Distance(target, transform.position) <= 1)
        {
            playerScript.ChangePlayerHP();
            Destroy(gameObject);
            uiScript.enemiesCount--;
        }
        else
        {
            transform.position = transform.position + dirNormalized * speed * Time.deltaTime;
        }
    }

    public void ChangeZombieHP(int dmgAmount)
    {
       hpEnemy -= dmgAmount;

        if (hpEnemy < 0)
        {
            uiScript.enemiesKilled++;
            uiScript.enemiesCount--;
            Destroy(gameObject);
        }
    }

    public void ZombieSlow()
    {
        speed = speedHalved;
        SlowTimer = 5;
    }

}
