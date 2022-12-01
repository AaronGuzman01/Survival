using System.Collections;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay;
    [SerializeField]
    private float disableDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelay());
        StartCoroutine(DestroyCollider());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }

    IEnumerator DestroyCollider()
    {
        yield return new WaitForSeconds(disableDelay);

        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
