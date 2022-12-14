using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Ability>().SetExistTime(existTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpeed()
    {
        return speed;
    }
}
