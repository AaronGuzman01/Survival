using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static Vector3 playerPos;
    private float accel;
    private bool followPlayer;

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
        accel = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            transform.position = Vector2.Lerp(transform.position, playerPos, Time.deltaTime * accel);

            accel += accel * 2f * Time.deltaTime;
        }
    }

    public void SetFollow()
    {
        followPlayer = true;
    }
}
