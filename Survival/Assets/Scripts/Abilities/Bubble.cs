using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private float speed;
    private GameObject target;
    private float accel;
    private bool targetSet;
    private bool targetReached;

    // Start is called before the first frame update
    void Start()
    {
        accel = 1.1f;
        targetReached = false;
        StartCoroutine(DestroyDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && targetSet)
        {
            if (!targetReached)
            {
                transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * accel);

                accel += accel * 1.3f * Time.deltaTime;

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

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(delay);

        target.GetComponent<Enemy>().SetDrowning(false);

        Destroy(gameObject);
    }
}
