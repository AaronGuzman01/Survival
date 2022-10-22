using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("ExpGain", 1f);
        PlayerPrefs.SetFloat("ProjDamage", 1f);
        PlayerPrefs.SetFloat("EnemyDamage", 1f);
        PlayerPrefs.SetFloat("ProjDelay", 1f);
        PlayerPrefs.SetFloat("EnemyDelay", 1f);
        PlayerPrefs.SetFloat("ItemDelay", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void HandleLevelUp()
    {
        PlayerPrefs.SetFloat("ExpGain", PlayerPrefs.GetFloat("ExpGain") * 0.99f);
        PlayerPrefs.SetFloat("ProjDelay", PlayerPrefs.GetFloat("ProjDelay") * 0.8f);
        PlayerPrefs.SetFloat("EnemyDamage", PlayerPrefs.GetFloat("EnemyDamage") * 1.05f);
    }
}
