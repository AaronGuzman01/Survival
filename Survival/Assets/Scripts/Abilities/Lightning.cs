using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    [SerializeField]
    private float disableTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Ability>().SetExistTime(existTime);
        GetComponent<Ability>().SetDisableTime(disableTime);  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
