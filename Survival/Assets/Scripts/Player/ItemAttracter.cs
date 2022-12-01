using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttracter : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemData>())
        {
            collision.GetComponent<ItemData>().SetFollow();
        }
    }
}
