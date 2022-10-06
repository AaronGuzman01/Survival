using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static int orbCount;
    public static bool isMoving;
    public GameObject player;
    public List<GameObject> orbs;
    public int[] orbChance;
    public int[] orbQuantity;
    private bool canGenerate;
    private float generationDelay;
    private int maxOrbs;

    void Start()
    {
        isMoving = false;
        canGenerate = true;
        orbCount = 0;
        generationDelay = 1f;
        maxOrbs = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            GenerateOrbs();
            /*
            GameObject orb = Instantiate(orbs[0], transform);
            orbs.Add(orb);
            orb.transform.position = RandomPositionGenerator(player.transform.position, 5f, 20f);
            orb.gameObject.SetActive(true);
            */
        }
    }

    private void GenerateOrbs()
    {
        if (canGenerate && orbCount < maxOrbs)
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                for (int j = 0; j < orbQuantity[i]; j++)
                {
                    if (Random.value < orbChance[i] / 100f)
                    {
                        GameObject orb = Instantiate(orbs[i], transform);
                        orb.transform.position = RandomPositionGenerator(player.transform.position, 5f, 25f);
                        orb.gameObject.SetActive(true);
                        orbCount++;
                    }
                }
            }

            canGenerate = false;

            StartCoroutine(DelayGeneration());
        }
    }

    IEnumerator DelayGeneration()
    {
        yield return new WaitForSeconds(generationDelay);
        canGenerate = true;
    }

    private Vector2 RandomPositionGenerator(Vector2 playerPos, float minRange, float maxRange)
    {
        float playerXPos = playerPos.x;
        float playerYPos = playerPos.y;
        float randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
        float randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);

        while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange))
        {
            randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
            randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
        }

        return new Vector2(randomXPos, randomYPos);
    }
}
