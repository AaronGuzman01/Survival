using System.Collections;
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
    private GameObject target;
    private GameObject newLightning;
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

        if (canSpawn && !target)
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
            target = collision.gameObject;

            if (canSpawn)
            {
                target = null;
                HandleSpawn();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (target == collision.gameObject)
            {
                target = null;
            }
        }
    }

    private void HandleSpawn()
    {
        newLightning = Instantiate(field, position, player.rotation);
        newLightning.SetActive(true);

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
