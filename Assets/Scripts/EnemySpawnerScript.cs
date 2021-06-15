using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private PlayerScript playerScript;
    public Transform ZombieList;
    public GameObject ZombieObject;
    public UI uiScript;
    GameObject newZombie = null;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(SpawnZombies(StaticDifficulty.zombieSpawnSpeedOption, StaticDifficulty.zombieSpawnAmountOption));
        playerScript.hpPlayer = StaticDifficulty.playerHPOption;
    }

    IEnumerator SpawnZombies(float spawnTimer, int zombieAmmount)
    {
        yield return new WaitForSeconds(spawnTimer);

        for (int x = 0; x < zombieAmmount; x++)
        {

            Vector3 vector = RandomPointOnCircleEdge();
            newZombie = Instantiate(ZombieObject, vector, Quaternion.Euler(0, 0, 0));
            newZombie.transform.SetParent(ZombieList);
            newZombie.GetComponent<EnemyScript>().speed = 0.3f;
            newZombie.GetComponent<EnemyScript>().playerScript = playerScript;
            newZombie.GetComponent<EnemyScript>().uiScript = uiScript;

            newZombie.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 0.6f, 0.6f, 0.6f, 0.6f);
            //(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax);

            uiScript.enemiesCount++;
        }

        StartCoroutine(SpawnZombies(spawnTimer, zombieAmmount));
    }

    private Vector3 RandomPointOnCircleEdge()
    {
        var vector2 = Random.insideUnitCircle.normalized * 25;
        return new Vector3(vector2.x, 0, vector2.y);
    }
}
