using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private int[] spawnAmount;
    [SerializeField]
    private bool[] canSpawn;
    [SerializeField]
    private float[] delays;

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
        for (int i = 0; i < enemies.Count; i++)
        {
            if (canSpawn[i])
            {
                for (int j = 0; j < spawnAmount[i]; j++)
                {
                    GameObject enemy = Instantiate(enemies[i], transform);
                    enemy.transform.position = PositionGenerator.GenerateRandomPosition(player.position, 15f, 20f);
                    enemy.gameObject.SetActive(true);
                }

                canSpawn[i] = false;

                StartCoroutine(DelayEnemy(i));
            }
        }
    }

    IEnumerator DelayEnemy(int index)
    {
        yield return new WaitForSeconds(delays[index]);
        canSpawn[index] = true;
    }
}
