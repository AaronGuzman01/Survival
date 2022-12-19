using UnityEngine;
using UnityEngine.UI;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() && !canPierce)
        {
            Destroy(gameObject);
        }
    }
    public void UpdateProjectile(Button button)
    {
        string text = "";

        if (projLevel == 0 || projLevel == 2)
        {
            text = "Increase projectile damage by 20%";
            button.onClick.AddListener(IncreaseProjectileDamage);
        }
        else if (projLevel == 1 || projLevel == 3)
        {
            text = "Decrease projectile cooldown by 15%";
            button.onClick.AddListener(DecreaseProjectileCooldown);
        }
        else
        {
            text = "FINAL UPGRADE TBA";
        }

        UpdateLevel();
        button.transform.parent.GetComponentInChildren<Text>().text = text;
    }

    public void IncreaseProjectileDamage()
    {
        PlayerPrefs.SetFloat("ProjDamage", PlayerPrefs.GetFloat("ProjDamage") * 1.20f);
    }

    public void DecreaseProjectileCooldown()
    {
        PlayerPrefs.SetFloat("ProjDelay", PlayerPrefs.GetFloat("ProjDelay") - 0.15f);
    }
}
