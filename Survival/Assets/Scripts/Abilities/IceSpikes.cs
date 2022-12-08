using System.Collections;
using UnityEngine;

public class IceSpikes : MonoBehaviour
{
    [SerializeField]
    private float existTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Ability>().SetExistTime(existTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
