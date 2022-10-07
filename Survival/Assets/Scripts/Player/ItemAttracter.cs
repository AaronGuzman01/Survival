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
        ItemData.scale = transform.localScale.x;
        transform.position = player.position;

        foreach (Collider2D col in Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f))
        {
            if (col.GetComponent<ItemData>())
            {
                col.GetComponent<ItemData>().SetFollow();
            }
        }
    }
}
