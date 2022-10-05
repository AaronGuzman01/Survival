using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static Vector3 playerPos;
    public static float scale;
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
        }

        accel += 0.001f;

        CheckDestroy();
    }

    private void CheckDestroy()
    {
        if (Vector2.Distance(transform.position, playerPos) > 40f)
        {
            --ItemGenerator.orbCount;
            Destroy(transform.gameObject);
        }
    }

    public void DestroyOrb()
    {
        --ItemGenerator.orbCount;
        Destroy(transform.gameObject);
    }

    public void SetFollow()
    {
        followPlayer = true;
    }
}
