using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireballGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private float delay;
    private bool canSpawn;
    private int spawnCount;
    private int spawned;
    private GameObject newFireball;

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

    public void UpdateFireballl(Button button)
    {
        fireball.GetComponent<Fireball>().UpdateFireball(button, this);
    }

    public void UpdateDelay()
    {
        delay = delay * 0.85f;
    }

    public void UpdateCount()
    {
        spawnCount++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canSpawn && collision.GetComponent<Enemy>())
        {
            newFireball = Instantiate(fireball, player.position, Quaternion.FromToRotation(Vector3.up, collision.transform.position - player.position));
            newFireball.SetActive(true);
            newFireball.GetComponent<Rigidbody2D>().velocity = (collision.transform.position - newFireball.transform.position).normalized * newFireball.GetComponent<Fireball>().GetSpeed();

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
