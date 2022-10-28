using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject selection;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private List<GameObject> enenmies;
    [SerializeField]
    private List<GameObject> projectiles;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("ExpGain", 1f);
        PlayerPrefs.SetFloat("ProjDamage", 1f);
        PlayerPrefs.SetFloat("ProjDelay", 1f);
        PlayerPrefs.SetFloat("EnemyDelay", 1f);
        PlayerPrefs.SetFloat("ItemDelay", 1f);

        ResetProjectiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetProjectiles()
    {
        foreach (GameObject projectile in projectiles)
        {
            projectile.GetComponent<Projectile>().ResetLevel();
        }
    }

    public void HandleLevelUp()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("ExpGain", PlayerPrefs.GetFloat("ExpGain") * 0.98f);

        UpdateEnemies();
        HandleSelection();
    }

    private void UpdateEnemies()
    {
        foreach (GameObject enemy in enenmies)
        {
            Enemy enemyInfo = enemy.GetComponent<Enemy>();

            enemyInfo.UpdateHealth(enemyInfo.GetEnemyHealth() * 1.05f);
            enemyInfo.UpdateDamage(enemyInfo.GetEnemyDamage() * 1.05f);
        }
    }

    private void HandleSelection()
    {
        for (int i = 0; i < /*selection.transform.childCount*/ 1; i++)
        {
            GameObject panel = selection.transform.GetChild(i).gameObject;
            panel.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
            UpdateProjectile(panel);
        }

        selection.SetActive(true);
        joystick.SetActive(false);
        joystick.GetComponent<MovementJoystick>().PointerUp();
    }

    public void UpdateProjectile(GameObject panel)
    {
        string text = "";
        Projectile projectile;

        projectile = projectiles[0].GetComponent<Projectile>();

        switch(projectile.GetLevel())
        {
            case 0:
                text = "Increase projectile damage by 20%";
                panel.GetComponentInChildren<Button>().onClick.AddListener(IncreaseProjectileDamage);
                break;
            case 1:
                text = "Increase projectile speed by 15%";
                panel.GetComponentInChildren<Button>().onClick.AddListener(IncreaseProjectileSpeed);
                break;
            case 2:
                text = "Increase projectile damage by 20%";
                panel.GetComponentInChildren<Button>().onClick.AddListener(IncreaseProjectileDamage);
                break;
            case 3:
                text = "Increase projectile speed by 15%";
                panel.GetComponentInChildren<Button>().onClick.AddListener(IncreaseProjectileSpeed);
                break;
            default:
                text = "FINAL UPGRADE TBA";
                panel.GetComponentInChildren<Button>().onClick.AddListener(CloseSelection);
                break;

        }

        projectile.UpdateLevel();
        panel.GetComponentInChildren<Text>().text = text;
    }

    public void IncreaseProjectileDamage()
    {
        PlayerPrefs.SetFloat("ProjDamage", PlayerPrefs.GetFloat("ProjDamage") * 1.20f);

        CloseSelection();
    }

    public void IncreaseProjectileSpeed()
    {
        PlayerPrefs.SetFloat("ProjDelay", PlayerPrefs.GetFloat("ProjDelay") - 0.15f);

        CloseSelection();
    }

    private void CloseSelection()
    {
        selection.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1;
    }
}
