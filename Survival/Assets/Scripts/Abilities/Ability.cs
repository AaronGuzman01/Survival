using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField]
    private float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDamage()
    {
        return damage;
    }
}
