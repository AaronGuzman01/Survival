using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject earthquake;
    [SerializeField]
    private float delay;
    private bool canSpawn;
    private GameObject newEarthquake;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;

            newEarthquake = Instantiate(earthquake);
            newEarthquake.transform.position = player.position;
            newEarthquake.SetActive(true);

            StartCoroutine(DelaySpawn());
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);

        canSpawn = true;
    }
}
