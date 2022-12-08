using System.Collections;
using UnityEngine;

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
    [SerializeField]
    private float rotationRange;
    private bool canGenerate;
    private bool stopGenerating;
    private GameObject newWind;
    private Vector3 position;
    private Vector3 newPos;
    private Vector3 oldPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        canGenerate = true;
        stopGenerating = false;
        oldPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        position += player.position - oldPlayerPos;
        oldPlayerPos = player.position;

        Debug.DrawLine(player.position, position, Color.green);
        Debug.DrawLine(player.position, newPos, Color.red);
        Debug.DrawLine(player.position, (Quaternion.AngleAxis(-rotationRange / 2f, Vector3.forward) * (position - player.position)) + player.position, Color.white);
        Debug.DrawLine(player.position, (Quaternion.AngleAxis(rotationRange / 2f, Vector3.forward) * (position - player.position)) + player.position, Color.white);
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
        float rotationAngle = Random.Range(-rotationRange / 2f, rotationRange / 2f);
        newPos = (Quaternion.AngleAxis(rotationAngle, Vector3.forward) * (position - player.position)) + player.position;

        newWind = Instantiate(wind, player.position, Quaternion.FromToRotation(Vector3.up, newPos - player.position));

        newWind.SetActive(true);
        newWind.GetComponent<Rigidbody2D>().velocity = (newPos - newWind.transform.position).normalized * newWind.GetComponent<Wind>().GetSpeed();

        if (!stopGenerating)
        {
            yield return new WaitForSeconds(0.25f);
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
