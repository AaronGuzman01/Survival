using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

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
