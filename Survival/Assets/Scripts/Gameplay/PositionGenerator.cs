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
    
    public static Vector2 GenerateRandomPosition(Vector2 playerPos, float xMinRange, float xMaxRange, float yMinRange, float yMaxRange)
    {
        float playerXPos = playerPos.x;
        float playerYPos = playerPos.y;
        float randomXPos = Random.Range(playerXPos - xMaxRange, playerXPos + xMaxRange);
        float randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);

        while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange))
        {
            randomXPos = Random.Range(playerXPos - xMaxRange, playerXPos + xMaxRange);
            randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
        }

        return new Vector2(randomXPos, randomYPos);
    }

    public static Vector2 GenerateRandomQuadrantPosition(Vector2 playerPos, float minRange, float maxRange, int quadrant)
    {
        float playerXPos = playerPos.x;
        float playerYPos = playerPos.y;
        float randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
        float randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);

        if (quadrant == 1)
        {
            if (!(randomXPos >= playerXPos + minRange && randomYPos >= playerXPos) || !(randomYPos >= playerYPos + minRange && randomXPos >= playerYPos))
            {
                while ((randomXPos < playerXPos + minRange) && (randomYPos < playerYPos + minRange))
                {
                    randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
                    randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
                }
            }
        }
        else if (quadrant == 2)
        {
            if (!(randomXPos <= playerXPos - minRange && randomYPos >= playerXPos) || !(randomYPos >= playerYPos + minRange && randomXPos <= playerYPos))
            {
                while ((randomXPos > playerXPos - minRange) && (randomYPos < playerYPos + minRange))
                {
                    randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
                    randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
                }
            }
        }
        else if (quadrant == 3)
        {
            if (!(randomXPos <= playerXPos - minRange && randomYPos <= playerXPos) || !(randomYPos <= playerYPos - minRange && randomXPos <= playerYPos))
            {
                while ((randomXPos > playerXPos - minRange) && (randomYPos > playerYPos - minRange))
                {
                    randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
                    randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
                }
            }
        }
        else
        {
            if (!(randomXPos >= playerXPos + minRange && randomYPos <= playerXPos) || !(randomYPos <= playerYPos - minRange && randomXPos >= playerYPos))
            {
                while ((randomXPos < playerXPos + minRange) && (randomYPos > playerYPos - minRange))
                {
                    randomXPos = Random.Range(playerXPos - maxRange, playerXPos + maxRange);
                    randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
                }
            }
        }

        return new Vector2(randomXPos, randomYPos);
    }
}
