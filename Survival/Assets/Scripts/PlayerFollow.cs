using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position; 
    }
}
