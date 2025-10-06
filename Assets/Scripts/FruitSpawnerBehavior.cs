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
    private GameObject redApple;
    [SerializeField]
    private GameObject greenApple;
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
                spawnFrequency = Random.Range(2f, 4f);
                bombSpawnFrequency = Random.Range(3f, 5f);
                break;
            case 2:
                spawnFrequency = Random.Range(1f, 2f);
                bombSpawnFrequency = Random.Range(1.5f, 2.5f);
                break;
            case 3:
                spawnFrequency = 0.1f;
                bombSpawnFrequency = 0.1f;
                break;
            case 4:
                spawnFrequency = 3600;
                bombSpawnFrequency = 3600;
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
                    randomFruit = Random.Range(2, 8);
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
                        Instantiate(redApple, spawner.transform.position, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(greenApple, spawner.transform.position, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(pear, spawner.transform.position, Quaternion.identity);
                        break;
                    case 7:
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
}
