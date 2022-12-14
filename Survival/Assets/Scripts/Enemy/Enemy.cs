using System.Collections;
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
    [SerializeField]
    private bool isFlying;
    private bool isDrowning;
    private bool isPushed;
    private float pushTime;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (!isPushed)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * enemySpeed;
        }

        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health == 0)
        {
            Destroy(gameObject);

            player.GetComponent<Player>().GetExperienceFromKill(enemyExp);
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

    public void SetDrowning(bool drowning)
    {
        isDrowning = drowning;
    }

    public void SetPushed(float time)
    {
        if (!isPushed)
        {
            isPushed = true;
            pushTime = time;
            StartCoroutine(WaitForPush());
        }

    }

    public float GetEnemyDamage()
    {
        return enemyDamage;
    }

    public float GetEnemyHealth()
    {
        return health;
    }

    public bool IsDrowning()
    {
        return isDrowning;
    }

    public bool IsFlying()
    {
        return isFlying;
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
        }
        else if (collision.GetComponent<Ability>())
        {
            if (collision.GetComponent<Lightning>() || collision.GetComponent<Rock>() ||
               (collision.GetComponent<Earthquake>() && !isFlying))
            {
                if (health - collision.GetComponent<Ability>().GetDamage() > 0f)
                {
                    health -= collision.GetComponent<Ability>().GetDamage();
                }
                else
                {
                    health = 0f;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Ability>())
        {
            if (collision.GetComponent<IceSpikes>() || collision.GetComponent<Wind>() || collision.GetComponent<Laser>() ||
               (collision.GetComponent<Bubble>() && collision.GetComponent<Bubble>().IsTarget(gameObject)))
            {
                if (health - collision.GetComponent<Ability>().GetDamage() * Time.deltaTime > 0f)
                {
                    health -= collision.GetComponent<Ability>().GetDamage() * Time.deltaTime;
                }
                else
                {
                    health = 0f;
                }
            }
            else if (collision.GetComponent<Fireball>())
            {
                if (health - collision.GetComponent<Ability>().GetDamage() > 0f)
                {
                    health -= collision.GetComponent<Ability>().GetDamage();
                }
                else
                {
                    health = 0f;
                }

                collision.GetComponent<Ability>().DestroyAbility();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ability>())
        {
            if (collision.collider.GetComponent<Wind>())
            {
                if (health - collision.collider.GetComponent<Ability>().GetDamage() > 0f)
                {
                    health -= collision.collider.GetComponent<Ability>().GetDamage();
                }
                else
                {
                    health = 0f;
                }
            }
        }
    }
    IEnumerator WaitForPush()
    {
        yield return new WaitForSeconds(pushTime);
        isPushed = false;
    }
}
