using System.Collections;
using UnityEngine;

public class FruitSpawnerBehavior : MonoBehaviour
{
    public int randomFruitGen;
    public int randomFruit;
    [SerializeField]
    private GameObject tomato;
    [SerializeField]
    private GameObject coconut;
    [SerializeField]
    private GameObject banana;
    [SerializeField]
    private GameObject watermelon;
    [SerializeField]
    private GameObject Apple;
    [SerializeField]
    private GameObject pear;
    [SerializeField]
    private GameObject orange;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private GameObject pearto;
    [SerializeField]
    public int difficulty;
    [SerializeField]
    private GameObject spawner;
    private float spawnFrequency;
    private float bombSpawnFrequency;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FruitGenerator());
        StartCoroutine(BombSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        switch (difficulty)
        {
            case 0:
                spawnFrequency = Random.Range(4f, 6f);
                bombSpawnFrequency = Random.Range(5f, 7.5f);
                break;
            case 1:
                spawnFrequency = Random.Range(3f, 5f);
                bombSpawnFrequency = Random.Range(4f, 6f);
                break;
            case 2:
                spawnFrequency = Random.Range(2f, 4f);
                bombSpawnFrequency = Random.Range(3f, 5f);
                break;
            case 3:
                spawnFrequency = Random.Range(1f, 3f);
                bombSpawnFrequency = Random.Range(2f, 4f);
                break;
            case 4:
                spawnFrequency = 1f;
                bombSpawnFrequency = 1f;
                break;
        }
    }

    private IEnumerator FruitGenerator()
    {
        while (true)
        {
            int peartospawn = Random.Range(0, 100);
            if (peartospawn == 69) Instantiate(pearto, spawner.transform.position, Quaternion.identity);
            int randomFruitGenProba = Random.Range(0, 5);
            if (randomFruitGenProba == 0)
            {
                randomFruitGen = Random.Range(0, 3);
            }
            else
            {
                randomFruitGen = 0;
            }
            for (int i = 0; i <= randomFruitGen; i++)
            {
                int randomFruitInt = Random.Range(0, 5);
                if (randomFruitInt == 0)
                {
                    randomFruit = Random.Range(0, 2);
                }
                else
                {
                    randomFruit = Random.Range(2, 7);
                }
                switch (randomFruit)
                {
                    case 0:
                        Instantiate(tomato, spawner.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(coconut, spawner.transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(banana, spawner.transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(watermelon, spawner.transform.position, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(Apple, spawner.transform.position, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(pear, spawner.transform.position, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(orange, spawner.transform.position, Quaternion.identity);
                        break;
                }
            } 
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    private IEnumerator BombSpawner()
    {
        while (true)
        {
            Instantiate(bomb, spawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(bombSpawnFrequency);
        }

    }

    public void SetDifficulty(int diff)
    {
        difficulty = diff;
    }
}
