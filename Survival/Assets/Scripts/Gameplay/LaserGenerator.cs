using System.Collections;
using UnityEngine;

public class LaserGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float delay;
    private bool canSpawn;
    private int spawnCount;
    private int spawned;
    private GameObject newLaser;

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
        if (canSpawn && collision.GetComponent<Enemy>())
        {
            newLaser = Instantiate(laser, player.position, Quaternion.FromToRotation(Vector3.up, collision.transform.position - player.position));
            newLaser.GetComponent<Laser>().SetPlayer(player);
            newLaser.SetActive(true);
            
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
