using UnityEngine;

public class HealingData : MonoBehaviour
{
    [SerializeField]
    private float healingAmount;
    
    void Update()
    {
        if (Vector2.Distance(transform.position, ItemData.playerPos) > 40f)
        {
            Destroy(gameObject);
        }
    }

    public float GetHealingAmount()
    {
        return healingAmount;
    }
}
