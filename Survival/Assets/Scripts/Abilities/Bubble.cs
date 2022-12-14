using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    [SerializeField]
    private float speed, accel;
    private GameObject target;
    private bool targetSet;
    private bool targetReached;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        targetReached = false;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitForExistTime());
    }

    void Update()
    {
        if (target != null && targetSet)
        {
            if (!targetReached)
            {
                rb.velocity = (target.transform.position - transform.position).normalized * speed;

                speed += accel * Time.deltaTime;

                if (Vector2.Distance(transform.position, target.transform.position)  <= 0.5f)
                {
                    targetReached = true;
                }
            }
            else
            {
                transform.position = target.transform.position;
            }
        }
        else if (target == null && targetSet)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(GameObject tar)
    {
        target = tar;
        target.GetComponent<Enemy>().SetDrowning(true);
        targetSet = true;
    }

    public bool IsTarget(GameObject enemy)
    {
        return target.Equals(enemy);
    }

    IEnumerator WaitForExistTime()
    {
        yield return new WaitForSeconds(existTime);

        target.GetComponent<Enemy>().SetDrowning(false);

        Destroy(gameObject);
    }
}
