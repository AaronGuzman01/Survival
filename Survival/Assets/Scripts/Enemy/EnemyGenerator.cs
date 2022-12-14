using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float minSpawnDist, maxSpawnDist;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private int[] spawnAmount;
    [SerializeField]
    private bool[] canSpawn;
    [SerializeField]
    private float[] delays;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GenerateEnemies();
    }

    private void GenerateEnemies()
    {
        int spawnCount = 0;

        for (int i = 0; i < enemies.Count; i++)
        {
            if (canSpawn[i])
            {
                for (int j = 0; j < spawnAmount[i]; j++)
                {
                    enemy = Instantiate(enemies[i], transform);

                    spawnCount++;

                    if (spawnCount == 1)
                    {
                        enemy.transform.position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, minSpawnDist, maxSpawnDist, 1);
                    }
                    else if (spawnCount == 2)
                    {
                        enemy.transform.position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, minSpawnDist, maxSpawnDist, 2);
                    }
                    else if (spawnCount == 3)
                    {
                        enemy.transform.position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, minSpawnDist, maxSpawnDist, 3);
                    }
                    else
                    {
                        enemy.transform.position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, minSpawnDist, maxSpawnDist, 4);

                        spawnCount = 0;
                    }


                    enemy.gameObject.SetActive(true);
                }

                canSpawn[i] = false;
                spawnCount = 0;

                StartCoroutine(DelayEnemy(i));
            }
        }
    }

    IEnumerator DelayEnemy(int index)
    {
        yield return new WaitForSeconds(delays[index] * PlayerPrefs.GetFloat("EnemyDelay"));
        canSpawn[index] = true;
    }
}
