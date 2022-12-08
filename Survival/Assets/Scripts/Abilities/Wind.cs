using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float force;
    [SerializeField]
    private float alphaChange;
    [SerializeField]
    private float pushTime;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        GetComponent<Ability>().SetExistTime(existTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.color.a > 0)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, rend.color.a - (alphaChange * Time.deltaTime));
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Rigidbody2D body = collision.GetComponent<Rigidbody2D>();

            collision.GetComponent<Enemy>().SetPushed(pushTime);

            body.velocity = Vector3.zero;   
            body.AddForce((collision.transform.position - transform.position).normalized * force);
        }
    }
}
