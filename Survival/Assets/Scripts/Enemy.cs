using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    public float enemyDamage;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime * enemySpeed);
    }
}
