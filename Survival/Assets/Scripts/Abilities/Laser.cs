using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Ability>().SetExistTime(existTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
    }
}
