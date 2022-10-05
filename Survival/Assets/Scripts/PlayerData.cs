using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float health;
    private float experience;
    private int level;

    private void Start()
    {
        health = 100;
        experience = 0;
        level = 0;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetExperience()
    {
        return experience;
    }

    public void UpdateHealth(float health)
    {
        this.health = health;
    }

    public void UpdateExperience(float experience)
    {
        if (this.experience + experience > 100)
        {
            this.experience = 0;
            level++;
        }
        else
        {
            this.experience += experience;   
        }
    }
}
