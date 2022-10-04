using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public MovementJoystick joystick;
    public Slider health;
    public float playerSpeed;
    private Rigidbody2D rb;
    private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>(); 
        playerData = GetComponent<PlayerData>();
    }

    void FixedUpdate()
    {
        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * playerSpeed, joystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        health.transform.localPosition = transform.position + new Vector3(0, 150, 0);

        if (playerData.GetHealth() == 100f)
        {
            health.gameObject.SetActive(false);
        }
        else
        {
            health.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            float damageAmount = collision.GetComponent<Enemy>().enemyDamage;

            if (playerData.GetHealth() > 0f && playerData.GetHealth() - damageAmount * Time.deltaTime >= 0f)
            {
                playerData.UpdateHealth(playerData.GetHealth() - damageAmount * Time.deltaTime);
                health.value = (playerData.GetHealth() - damageAmount * Time.deltaTime) / 100f;
            }
            else if (playerData.GetHealth() <= damageAmount)
            {
                playerData.UpdateHealth(0f);
                health.value = 0f;
            }
        }
    }
}
