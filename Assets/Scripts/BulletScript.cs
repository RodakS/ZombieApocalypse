using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            collision.gameObject.GetComponent<EnemyScript>().ChangeZombieHP(75);
        }
        Destroy(gameObject);
    }

}
