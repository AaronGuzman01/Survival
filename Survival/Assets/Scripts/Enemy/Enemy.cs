using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private float enemyDamage;
    [SerializeField]
    private float health;
    [SerializeField]
    private float enemyExp;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime * enemySpeed);
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealth(float health)
    {
        this.health = health;
    }

    public void UpdateDamage(float damage)
    {
        enemyDamage = damage;
    }

    public float GetEnemyDamage()
    {
        return enemyDamage;
    }

    public float GetEnemyHealth()
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            if (health - collision.GetComponent<Projectile>().GetDamage() > 0f)
            {
                health -= collision.GetComponent<Projectile>().GetDamage();
            }
            else
            {
                health = 0f;
            }

            player.GetComponent<Player>().GetExperienceFromKill(enemyExp);
        }
        else if (collision.GetComponent<Ability>())
        {
            if (health - collision.GetComponent<Ability>().GetDamage() > 0f)
            {
                health -= collision.GetComponent<Ability>().GetDamage();
            }
            else
            {
                health = 0f;
            }

            player.GetComponent<Player>().GetExperienceFromKill(enemyExp);
        }
    }
}
