using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static int orbCount;
    public static bool isMoving;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private List<GameObject> orbs;
    [SerializeField]
    private GameObject healingItem;
    [SerializeField]
    private int[] orbChance;
    [SerializeField]
    private int[] orbQuantity;
    private bool canGenerateOrbs;
    private bool canGenerateHealing;
    private float orbDelay;
    private float healingDelay;
    private int maxOrbs;

    void Start()
    {
        isMoving = false;
        canGenerateOrbs = true;
        canGenerateHealing = true;
        orbCount = 0;
        orbDelay = 1f;
        healingDelay = 5f;
        maxOrbs = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            GenerateOrbs();
            GenerateHealing();
        }
    }

    private void GenerateOrbs()
    {
        if (canGenerateOrbs && orbCount < maxOrbs)
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                for (int j = 0; j < orbQuantity[i]; j++)
                {
                    if (Random.value < orbChance[i] / 100f)
                    {
                        GameObject orb = Instantiate(orbs[i], transform);
                        orb.transform.position = PositionGenerator.GenerateRandomPosition(player.position, 5f, 25f);
                        orb.gameObject.SetActive(true);
                        orbCount++;
                    }
                }
            }

            canGenerateOrbs = false;

            StartCoroutine(DelayOrbGeneration());
        }
    }

    public void GenerateHealing()
    {
        if (canGenerateHealing)
        {
            if (Random.value < 0.15f)
            {
                GameObject healing = Instantiate(healingItem, transform);
                healing.transform.position = PositionGenerator.GenerateRandomPosition(player.position, 5f, 25f);
                healing.gameObject.SetActive(true);

                canGenerateHealing = false;

                StartCoroutine(DealyHealingGeneration());
            }
        }
    }

    IEnumerator DelayOrbGeneration()
    {
        yield return new WaitForSeconds(orbDelay * PlayerPrefs.GetFloat("ItemDelay"));
        canGenerateOrbs = true;
    }

    IEnumerator DealyHealingGeneration()
    {
        yield return new WaitForSeconds(healingDelay * PlayerPrefs.GetFloat("ItemDelay"));
        canGenerateHealing = true;
    }
}
