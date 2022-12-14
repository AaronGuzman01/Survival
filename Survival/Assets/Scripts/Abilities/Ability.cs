using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private float existTime;
    private float disableTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }

    public void DestroyAbility()
    {
        Destroy(gameObject);
    }

    public void SetExistTime(float existTime)
    {
        this.existTime = existTime;

        StartCoroutine(WaitForExistTime());
    }

    public void SetDisableTime(float disableTime)
    {
        this.disableTime = disableTime;

        StartCoroutine(WaitForDisableTime());
    }

    IEnumerator WaitForExistTime()
    {
        yield return new WaitForSeconds(existTime);

        Destroy(gameObject);
    }

    IEnumerator WaitForDisableTime()
    {
        yield return new WaitForSeconds(disableTime);

        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
