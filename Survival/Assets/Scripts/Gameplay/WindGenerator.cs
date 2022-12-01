using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class WindGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject wind;
    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private float stopDelay;
    private bool canGenerate;
    private bool stopGenerating;
    private GameObject newWind;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        canGenerate = true;
        stopGenerating = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>()) 
        {
            if (canGenerate)
            {
                position = collision.transform.position;

                canGenerate = false;

                StartCoroutine(Spawn());
                StartCoroutine(DelaySpawn());
            }
        }
    }

    private int PosOrNeg()
    {
        if (Random.value < 0.5f)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    IEnumerator Spawn()
    {
        Vector3 variation = new Vector3(Random.Range(0f, 1f) * PosOrNeg(), Random.Range(0f, 1f) * PosOrNeg(), 0);
        position += variation;

        newWind = Instantiate(wind, player.position, Quaternion.FromToRotation(Vector3.up, position - player.position));

        newWind.SetActive(true);
        newWind.GetComponent<Rigidbody2D>().velocity = (position - newWind.transform.position).normalized * newWind.GetComponent<Wind>().GetSpeed();

        if (!stopGenerating)
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Spawn());
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(stopDelay);

        stopGenerating = true;

        yield return new WaitForSeconds(spawnDelay);

        canGenerate = true;
        stopGenerating= false;
    }
}
