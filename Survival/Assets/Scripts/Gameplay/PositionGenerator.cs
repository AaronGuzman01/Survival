using UnityEngine;

public class PositionGenerator : MonoBehaviour
{
    public static Vector2 GenerateRandomPosition(Vector2 playerPos, float minRange, float maxRange)
    {
        float startXPos = 0f;
        float playerYPos = 0f;
        float randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
        float randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);

        while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange))
        {
            randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
            randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
        }

        randomXPos += playerPos.x;
        randomYPos += playerPos.y;

        return new Vector2(randomXPos, randomYPos);
    }
    
    public static Vector2 GenerateRandomPosition(Vector2 playerPos, float xMinRange, float xMaxRange, float yMinRange, float yMaxRange)
    {
        float startXPos = 0f;
        float playerYPos = 0f;
        float randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
        float randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);

        while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange))
        {
            randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
            randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
        }

        randomXPos += playerPos.x;
        randomYPos += playerPos.y;

        return new Vector2(randomXPos, randomYPos);
    }

    public static Vector2 GenerateRandomQuadrantPosition(Vector2 playerPos, float minRange, float maxRange, int quadrant)
    {
        float startXPos = 0f;
        float playerYPos = 0f;
        float randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
        float randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);

        if (quadrant == 1)
        {
            while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange) ||
                   (randomXPos < 0f || randomYPos < 0f))
            {
                randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
                randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
            }
        }
        else if (quadrant == 2)
        {
            while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange) ||
                   (randomXPos > 0f || randomYPos < 0f))
            {
                randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
                randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
            }
        }
        else if (quadrant == 3)
        {
            while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange) ||
                   (randomXPos > 0f || randomYPos > 0f))
            {
                randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
                randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
            }
        }
        else
        {
            while ((randomXPos < minRange && randomXPos > -minRange) && (randomYPos < minRange && randomYPos > -minRange) ||
                   (randomXPos < 0f || randomYPos > 0f))
            {
                randomXPos = Random.Range(startXPos - maxRange, startXPos + maxRange);
                randomYPos = Random.Range(playerYPos - maxRange, playerYPos + maxRange);
            }
        }

        randomXPos += playerPos.x;
        randomYPos += playerPos.y;

        return new Vector2(randomXPos, randomYPos);
    }

    public static Vector2 GenerateRandomQuadrantPosition(Vector2 playerPos, float xMinRange, float xMaxRange, float yMinRange, float yMaxRange, int quadrant)
    {
        float startXPos = 0f;
        float playerYPos = 0f;
        float randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
        float randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);

        if (quadrant == 1)
        {
            while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange) ||
                   (randomXPos < 0f || randomYPos < 0f))
            {
                randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
                randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
            }
        }
        else if (quadrant == 2)
        {
            while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange) ||
                   (randomXPos > 0f || randomYPos < 0f))
            {
                randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
                randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
            }
        }
        else if (quadrant == 3)
        {
            while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange) ||
                   (randomXPos > 0f || randomYPos > 0f))
            {
                randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
                randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
            }
        }
        else
        {
            while ((randomXPos < xMinRange && randomXPos > -xMinRange) && (randomYPos < yMinRange && randomYPos > -yMinRange) ||
                   (randomXPos < 0f || randomYPos > 0f))
            {
                randomXPos = Random.Range(startXPos - xMaxRange, startXPos + xMaxRange);
                randomYPos = Random.Range(playerYPos - yMaxRange, playerYPos + yMaxRange);
            }
        }

        randomXPos += playerPos.x;
        randomYPos += playerPos.y;

        return new Vector2(randomXPos, randomYPos);
    }
}
