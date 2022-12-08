using System.Collections;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private float delay, wait;
    public float xmin, xmax, ymin, ymax;
    private bool canSpawn, hasWaited;
    private Vector2 position;
    private GameObject newRock;
    private int next, spawnCount, spawned, currQuad;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        hasWaited = true;
        next = 1;
        spawnCount = 1;
        spawned = 0;
        currQuad = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        if (canSpawn)
        {
            canSpawn = false;

            StartCoroutine(HandleSpawn());
        }
    }

    private void SetPosition()
    {
        switch(currQuad)
        {
            case 1:
                position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, xmin, xmax, ymin, ymax, 1);
                currQuad++;
                break;
            case 2:
                position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, xmin, xmax, ymin, ymax, 2);
                currQuad++;
                break;
            case 3:
                position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, xmin, xmax, ymin, ymax, 3);
                currQuad++;
                break;
            default:
                position = PositionGenerator.GenerateRandomQuadrantPosition(player.position, xmin, xmax, ymin, ymax, 4);
                currQuad = 1;
                break;
        }
    }

    IEnumerator HandleSpawn()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitUntil(() => i + 1 == next);
            StartCoroutine(SpawnAndWait());
        }

        StartCoroutine(DelaySpawn());
    }

    IEnumerator SpawnAndWait()
    {
        yield return new WaitUntil(() => hasWaited);

        for (int i = 0; i < spawnCount; i++)
        {
            if (i == 0)
            {
                SetPosition();
            }
            else
            {
                if (currQuad == 1)
                {
                    currQuad = 4;
                    SetPosition();
                }
                else
                {
                    currQuad--;
                    SetPosition();
                }

            }

            newRock = Instantiate(rock, position, player.rotation);
            newRock.SetActive(true);
            spawned++;
        }

        hasWaited = false;
        StartCoroutine(SpawnWait());
        next++;
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(wait);

        hasWaited = true;
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitUntil(() => spawned >= spawnCount * 4);
        yield return new WaitForSeconds(delay);

        canSpawn = true;
        hasWaited = true;
        spawned = 0;
        next = 1;
    }
}
