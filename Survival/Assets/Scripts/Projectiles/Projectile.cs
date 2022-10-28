using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private int projLevel;
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

    public void ResetLevel()
    {
        projLevel = 0;
    }

    public void SetOriginPosition(Vector3 pos)
    {
        origPos = pos;
        origSet = true;
    }

    public void UpdateLevel()
    {
        projLevel++;
    }

    public float GetDamage()
    {
        return damage * PlayerPrefs.GetFloat("ProjDamage");
    }

    public int GetLevel()
    {
        return projLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() && !canPierce)
        {
            Destroy(gameObject);
        }
    }
}
