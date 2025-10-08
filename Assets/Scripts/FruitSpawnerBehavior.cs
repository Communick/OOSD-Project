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
                spawnFrequency = Random.Range(2f, 4f);
                bombSpawnFrequency = Random.Range(3f, 5f);
                break;
            case 2:
                spawnFrequency = Random.Range(1f, 2f);
                bombSpawnFrequency = Random.Range(1.5f, 2.5f);
                break;
            case 3:
                spawnFrequency = 0.5f;
                bombSpawnFrequency = 0.5f;
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
                    randomFruit = Random.Range(2, 7);
                }
                switch (randomFruit)
                {
                    case 0:
                        Instantiate(tomato, spawner.transform.position, Quaternion.identity);
                        tomato.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        tomato.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            tomato.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            tomato.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 1:
                        Instantiate(coconut, spawner.transform.position, Quaternion.identity);
                        coconut.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        coconut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            coconut.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            coconut.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 2:
                        Instantiate(banana, spawner.transform.position, Quaternion.identity);
                        banana.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        banana.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            banana.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            banana.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 3:
                        Instantiate(watermelon, spawner.transform.position, Quaternion.identity);
                        watermelon.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        tomato.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            watermelon.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            watermelon.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 4:
                        Instantiate(Apple, spawner.transform.position, Quaternion.identity);
                        Apple.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        Apple.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            Apple.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            Apple.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 5:
                        Instantiate(pear, spawner.transform.position, Quaternion.identity);
                        pear.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        pear.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            pear.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            pear.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
                        break;
                    case 6:
                        Instantiate(orange, spawner.transform.position, Quaternion.identity);
                        orange.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
                        orange.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                        if (Random.Range(0, 10) < 5)
                        {
                            orange.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
                        }
                        else
                        {
                            orange.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
                        }
                        if (Time.timeSinceLevelLoad < 1)
                        {
                            Destroy(gameObject, 0.001f);
                        }
                        else Destroy(gameObject, 7f);
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
            bomb.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), 0f);
            bomb.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            if (Random.Range(0, 10) < 5)
            {
                bomb.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, -50f), Random.Range(500f, 800f)));
            }
            else
            {
                bomb.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(50f, 100f), Random.Range(500f, 800f)));
            }
            if (Time.timeSinceLevelLoad < 1)
            {
                Destroy(gameObject, 0.001f);
            }
            else Destroy(gameObject, 7f);
            yield return new WaitForSeconds(bombSpawnFrequency);
        }

    }
}
