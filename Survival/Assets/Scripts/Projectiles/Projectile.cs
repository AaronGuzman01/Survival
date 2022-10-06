using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private Vector3 origPos;
    private bool origSet;
    private bool canPierce;

    void Update()
    {
        if (origSet && Vector3.Distance(transform.position, origPos) > 25f)
        {
            Destroy(gameObject);
        }
    }

    public void SetOriginPosition(Vector3 pos)
    {
        origPos = pos;
        origSet = true;
    }

    public float GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() && !canPierce)
        {
            Destroy(gameObject);
        }
    }
}
