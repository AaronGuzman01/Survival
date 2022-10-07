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

    public void SetDamageTaken(float damage)
    {
        if (health - damage > 0f)
        {
            health -= damage;
        }
        else
        {
            health = 0f;
        }
    }

    public float GetEnemyDamage()
    {
        return enemyDamage;
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
    }
}
