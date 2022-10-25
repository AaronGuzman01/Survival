using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    [SerializeField]
    private GameObject selection;
    [SerializeField]
    private GameObject joystick;

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

    public void HandleLevelUp()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("ExpGain", PlayerPrefs.GetFloat("ExpGain") * 0.98f);
        PlayerPrefs.SetFloat("EnemyDamage", PlayerPrefs.GetFloat("EnemyDamage") * 1.05f);

        HandleSelection();
    }

    private void HandleSelection()
    {
        for (int i = 0; i < selection.transform.childCount; i++)
        {
            GameObject panel = selection.transform.GetChild(i).gameObject;
            panel.GetComponentInChildren<Text>().text = "Increase projectile damage by 20%";
            panel.GetComponentInChildren<Button>().onClick.AddListener(IncreaseProjectileDamage);
        }

        selection.SetActive(true);
        joystick.SetActive(false);
    }

    public void IncreaseProjectileDamage()
    {
        PlayerPrefs.SetFloat("ProjDamage", PlayerPrefs.GetFloat("ProjDamage") * 1.20f);
        Debug.Log(PlayerPrefs.GetFloat("ProjDamage"));

        CloseSelection();
    }

    private void CloseSelection()
    {
        selection.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1;
    }
}
