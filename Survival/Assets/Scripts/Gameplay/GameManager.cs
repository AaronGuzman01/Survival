using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject selection;
    [SerializeField]
    private List<Button> options;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private List<GameObject> projectiles;
    [SerializeField]
    private List<GameObject> abilities;
    private List<float> probabilites;
    private List<int> accessed, maxed;

    // Start is called before the first frame update
    void Start()
    {
        probabilites = new List<float>();
        accessed = new List<int>();
        maxed = new List<int>();    

        PlayerPrefs.SetFloat("ExpGain", 1f);
        PlayerPrefs.SetFloat("ProjDamage", 1f);
        PlayerPrefs.SetFloat("ProjDelay", 1f);
        PlayerPrefs.SetFloat("EnemyDelay", 1f);
        PlayerPrefs.SetFloat("ItemDelay", 1f);

        ResetProjectiles();
        SetProbabilites();
    }

    void Update()
    {

    }

    private void ResetProjectiles()
    {
        foreach (GameObject projectile in projectiles)
        {
            projectile.GetComponent<Projectile>().ResetLevel();
        }
    }

    private void SetProbabilites()
    {
        for (var i = 0; i < abilities.Count; i++)
        {
            probabilites.Add(1f);
        }
    }

    public void HandleLevelUp()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("ExpGain", PlayerPrefs.GetFloat("ExpGain") * 0.98f);
        
        if  (player.GetComponent<PlayerData>().GetLevel() %  5  == 0)
        {
            PlayerPrefs.SetFloat("ExpGain", PlayerPrefs.GetFloat("ExpGain") * 0.95f);
        }

        UpdateEnemies();
        HandleSelection();
    }

    private void UpdateEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Enemy enemyInfo = enemy.GetComponent<Enemy>();

            enemyInfo.UpdateHealth(enemyInfo.GetEnemyHealth() * 1.05f);
            enemyInfo.UpdateDamage(enemyInfo.GetEnemyDamage() * 1.05f);
        }
    }

    private void HandleSelection()
    {
        selection.SetActive(true);
        joystick.SetActive(false);
        joystick.GetComponent<MovementJoystick>().PointerUp();

        foreach (Button option in options)
        {
            option.transform.parent.GetComponentInChildren<Text>().text = "";
            option.onClick.RemoveAllListeners();
            DisplayOption(option);
        }

        accessed.Clear();
        UpdateMaxedUpgrades();
    }

    private void DisplayOption(Button option)
    {
        bool displayed = false;
        int index;
        float prob;

        while (!displayed)
        {
            index = Random.Range(0, abilities.Count);
            prob = Random.value;

            if (!accessed.Contains(index) && prob <= probabilites[index]) {
                accessed.Add(index);
                displayed = true;

                switch(index)
                {
                    case 0:
                        abilities[index].GetComponent<ProjectileGenerator>().UpdateProjectile(option);
                        option.onClick.AddListener(delegate { UpdateProbability(index, 0.2f); });
                        break;
                        /*
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                        */
                    case 7:
                        abilities[index].GetComponent<FireballGenerator>().UpdateFireballl(option);
                        option.onClick.AddListener(delegate { UpdateProbability(index, 0.1f); });
                        break;
                        /*
                    case 8:
                        break;
                         */
                    default:
                        break;
                }
            }

            option.onClick.AddListener(CloseSelection);
        }
    }

    private void UpdateProbability(int index, float change)
    {
        if (probabilites[index] - change >= 0f)
        {
            probabilites[index] -= change;
        }
        else
        {
            probabilites[index] = 0f;
            maxed.Add(index);
        }

        foreach (var prob in probabilites)
        {
            Debug.Log(prob);
        }
    }

    private void UpdateMaxedUpgrades()
    {
        foreach (var index in maxed)
        {
            probabilites[index] += 0.01f;
        }
    }

    private void CloseSelection()
    {
        selection.SetActive(false);
        joystick.SetActive(true);
        Time.timeScale = 1;
    }
}
