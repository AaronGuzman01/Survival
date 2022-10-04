using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float experience;

    private void Start()
    {
        health = 100;
        experience = 0;
    }

    public float GetHealth()
    {
        return health;
    }

    public void UpdateHealth(float health)
    {
        this.health = health;
    }
}
