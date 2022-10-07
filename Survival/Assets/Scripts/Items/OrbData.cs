using UnityEngine;

public class OrbData : MonoBehaviour
{
    [SerializeField]
    private float expGain;

    void Update()
    {
        if (Vector2.Distance(transform.position, ItemData.playerPos) > 40f)
        {
            DestroyOrb();
        }
    }

    public float GetExpGain()
    {
        return expGain;
    }

    public void DestroyOrb()
    {
        --ItemGenerator.orbCount;
        Destroy(transform.gameObject);
    }
}
