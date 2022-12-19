using System.Collections;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private int abillityLevel;
    private float existTime, disableTime;

    // Start is called before the first frame update
    void Start()
    {
        abillityLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLevel()
    {
        return abillityLevel;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void DestroyAbility()
    {
        Destroy(gameObject);
    }

    public void UpdateLevel()
    {
        abillityLevel++;
    }

    public void UpdateDamage(float damage)
    {
        this.damage = damage;
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
