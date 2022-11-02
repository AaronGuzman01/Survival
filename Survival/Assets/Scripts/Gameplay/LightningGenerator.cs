using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject field;
    [SerializeField]
    private float delay;
    public float xmin, xmax, ymin, ymax;
    private bool canSpawn;
    private Vector2 position;
    private GameObject current;
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

        if (canSpawn && !current)
        {
            position = PositionGenerator.GenerateRandomPosition(player.position, xmin, xmax, ymin, ymax);

            HandleSpawn();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            position = collision.gameObject.transform.position;
            current = collision.gameObject;

            if (canSpawn)
            {
                current = null;
                HandleSpawn();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (current == collision.gameObject)
            {
                current = null;
            }
        }
    }

    private void HandleSpawn()
    {
        Instantiate(field, position, player.rotation);

        spawned++;

        if (spawned >= spawnCount)
        {
            canSpawn = false;
            StartCoroutine(DelaySpawn());
            spawned = 0;
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);

        canSpawn = true;
    }
}
