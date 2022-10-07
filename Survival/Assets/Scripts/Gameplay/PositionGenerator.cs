using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    public static Vector2 GenerateRandomPosition(Vector2 playerPos, float minRange, float maxRange)
    {
        float playerXPos = playerPos.x;
        float playerYPos = playerPos.y;
        float randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
        float randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);

        while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange))
        {
            randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
            randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
        }

        return new Vector2(randomXPos, randomYPos);
    }
}
