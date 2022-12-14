using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static Vector3 playerPos;
    [SerializeField]
    private float speed;
    private bool followPlayer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (followPlayer)
        {
            rb.velocity = (playerPos - transform.position).normalized * speed;

            speed += 2f * Time.deltaTime;
        }
    }

    public void SetFollow()
    {
        followPlayer = true;
    }
}
