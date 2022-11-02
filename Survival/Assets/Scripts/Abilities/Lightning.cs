using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField]
    private float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
