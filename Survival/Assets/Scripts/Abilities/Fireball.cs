using UnityEngine;
using UnityEngine.UI;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float existTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Ability info;

    // Start is called before the first frame update
    void Start()
    {
        info.SetExistTime(existTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void UpdateFireball(Button button, FireballGenerator generator)
    {
        string text = "";
        int level = GetComponent<Ability>().GetLevel();

        if (level == 0)
        {
            text = "Shoot a fireball at an enemy";
            button.onClick.AddListener(generator.GetComponent<Generator>().StartGenerator);
        }
        else if (level == 1 || level == 4 || level == 7)
        {
            text = "Increase fireball damage by 33%";
            button.onClick.AddListener(IncreaseFireballDamage);
        }
        else if (level == 2 || level == 5 || level == 8)
        {
            text = "Decrease fireball cooldown by 15%";
            button.onClick.AddListener(generator.UpdateDelay);
        }
        else if (level == 3 || level == 6 || level == 9)
        {
            text = "Shoot an additional fireball";
            button.onClick.AddListener(generator.UpdateCount);
        }
        else
        {
            text = "FINAL UPGRADE TBA";
        }

        info.UpdateLevel();
        button.transform.parent.GetComponentInChildren<Text>().text = text;
    }

    private void IncreaseFireballDamage()
    {
        info.UpdateDamage(info.GetDamage() * 1.33f);
    }
}
