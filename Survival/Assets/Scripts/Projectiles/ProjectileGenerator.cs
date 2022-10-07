using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float speed;
    private bool hasGenerated;

    // Start is called before the first frame update
    void Start()
    {
        hasGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;

        if (!hasGenerated)
        {
            Collider2D col = Physics2D.OverlapBox(transform.position, transform.localScale, 0f);

            if (col.GetComponent<Enemy>())
            {
                GameObject newProj = Instantiate(projectile, player.position, Quaternion.FromToRotation(Vector3.up, col.transform.position - player.position));

                newProj.GetComponent<Projectile>().SetOriginPosition(player.position);

                newProj.GetComponent<Rigidbody2D>().velocity = (col.transform.position - newProj.transform.position).normalized * speed;

                hasGenerated = true;

                StartCoroutine(GenerationDelay());
            }
        }
    }

    IEnumerator GenerationDelay()
    {
        yield return new WaitForSeconds(1f);

        hasGenerated = false;
    }
}
