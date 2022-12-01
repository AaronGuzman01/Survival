using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject bubble;
    [SerializeField]
    private float delay;
    private bool canSpawn;
    private int spawnCount;
    private int spawned;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;   
        spawnCount = 1;
        spawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canSpawn && spawned < spawnCount && collision.GetComponent<Enemy>() && !collision.GetComponent<Enemy>().IsDrowning())
        {
            GameObject newBubble = Instantiate(bubble);
            newBubble.transform.position = player.position;
            newBubble.SetActive(true);
            newBubble.GetComponent<Bubble>().SetTarget(collision.gameObject);

            spawned++;

            if (spawned >= spawnCount)
            {
                canSpawn = false;
                spawned = 0;

                StartCoroutine(DelaySpawn());
            }
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);

        canSpawn = true;
    }
}
