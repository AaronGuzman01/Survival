using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameObject newProj;
    private float genDelay;
    private bool hasGenerated;

    // Start is called before the first frame update
    void Start()
    {
        hasGenerated = false;
        genDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() && !hasGenerated)
        {
            newProj = Instantiate(projectile, player.position, Quaternion.FromToRotation(Vector3.up, collision.transform.position - player.position));

            newProj.GetComponent<Projectile>().SetOriginPosition(player.position);

            newProj.GetComponent<Rigidbody2D>().velocity = (collision.transform.position - newProj.transform.position).normalized * speed;

            hasGenerated = true;

            StartCoroutine(GenerationDelay());
        }
    }

    IEnumerator GenerationDelay()
    {
        yield return new WaitForSeconds(genDelay * PlayerPrefs.GetFloat("ProjDelay"));

        hasGenerated = false;
    }
}
