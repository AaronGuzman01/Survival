using System.Collections;
using UnityEngine;

public class IceSpikesGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject iceSpikes;
    [SerializeField]
    private float delay;
    private bool canSpawn;
    private GameObject newSpikes;

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

            newSpikes = Instantiate(iceSpikes);
            newSpikes.transform.position = player.position;
            newSpikes.SetActive(true);

            StartCoroutine(DelaySpawn());
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);

        canSpawn = true;
    }
}
