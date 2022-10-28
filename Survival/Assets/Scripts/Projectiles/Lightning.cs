using System.Collections;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private Transform player;
    private float delay;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        delay = 3f;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;

        }
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(delay);

        canSpawn = true;
    }
}
