using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class FruitSpawnerBehavior : MonoBehaviour
{
    public int randomFruitGen, randomFruit, difficulty;
    [SerializeField]
    private GameObject tomato, coconut, banana, watermelon, Apple, pear, orange, bomb, pearto, spawner;
    [SerializeField]
    private int spawnerID;
    private float spawnFrequency, bombSpawnFrequency, fruitforce;
    [SerializeField]
    private GameOver_and_UI UIScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FruitGenerator());
        StartCoroutine(BombSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        FruitPropulsionBehavior ApplepropulsionBehavior = Apple.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior tomatopropulsionBehavior = tomato.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior coconutpropulsionBehavior = coconut.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior bananapropulsionBehavior = banana.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior watermelonpropulsionBehavior = watermelon.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior pearpropulsionBehavior = pear.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior orangepropulsionBehavior = orange.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior peartopropulsionBehavior = pearto.GetComponent<FruitPropulsionBehavior>();
        FruitPropulsionBehavior bombpropulsionBehavior = bomb.GetComponent<FruitPropulsionBehavior>();
        ApplepropulsionBehavior.force = tomatopropulsionBehavior.force = coconutpropulsionBehavior.force = bananapropulsionBehavior.force = watermelonpropulsionBehavior.force = pearpropulsionBehavior.force = orangepropulsionBehavior.force = peartopropulsionBehavior.force = bombpropulsionBehavior.force = fruitforce;
        switch (difficulty)
        {
            case 0:
                switch (spawnerID)
                {
                    case 0:                     
                        spawnFrequency = 20f;
                        if (Time.timeSinceLevelLoad <= 5f) bombSpawnFrequency = 16f;
                        else bombSpawnFrequency = 20f;
                        break;
                    case 1:
                        if (Time.timeSinceLevelLoad <= 5f) spawnFrequency = 4f;
                        else spawnFrequency = 20f;
                        break;
                    case 2:
                        if (Time.timeSinceLevelLoad <= 5f) spawnFrequency = 8f;
                        else spawnFrequency = 20f;
                        break;
                    case 3:
                        if (Time.timeSinceLevelLoad <= 5f) spawnFrequency = 12f;
                        else spawnFrequency = 20f;
                        break;
                }
                fruitforce = 100;
                break;
            case 1:
                switch (spawnerID)
                {
                    case 0:
                        spawnFrequency = Random.Range(4f, 6f);
                        bombSpawnFrequency = Random.Range(5.5f, 7.5f);
                        break;
                    case 1:
                        spawnFrequency = Random.Range(4f, 6f) + 2;
                        bombSpawnFrequency = Random.Range(5.5f, 7.5f) + 2;
                        break;
                    case 2:
                        spawnFrequency = Random.Range(4f, 6f) + 4;
                        bombSpawnFrequency = Random.Range(5.5f, 7.5f) +4;
                        break;
                    case 3:
                        spawnFrequency = Random.Range(4f, 6f) + 6;
                        bombSpawnFrequency = Random.Range(5.5f, 7.5f) + 6;
                        break;
                }
                fruitforce = 3;
                break;
            case 2:
                switch (spawnerID)
                {
                    case 0:
                        spawnFrequency = Random.Range(3f, 5f);
                        bombSpawnFrequency = Random.Range(4f, 6f);
                        break;
                    case 1:
                        spawnFrequency = Random.Range(3f, 5f) + 2;
                        bombSpawnFrequency = Random.Range(4f, 6f) + 2;
                        break;
                    case 2:
                        spawnFrequency = Random.Range(3f, 5f) + 4;
                        bombSpawnFrequency = Random.Range(4f, 6f) + 4;
                        break;
                    case 3:
                        spawnFrequency = Random.Range(3f, 5f) + 6;
                        bombSpawnFrequency = Random.Range(4f, 6f) + 6;
                        break;
                }
                fruitforce = 4;
                break;
            case 3:
                switch (spawnerID)
                {
                    case 0:
                        spawnFrequency = Random.Range(2f, 4f);
                        bombSpawnFrequency = Random.Range(3f, 5f);
                        break;
                    case 1:
                        spawnFrequency = Random.Range(2f, 4f) + 2;
                        bombSpawnFrequency = Random.Range(3f, 5f) + 2;
                        break;
                    case 2:
                        spawnFrequency = Random.Range(2f, 4f) + 4;
                        bombSpawnFrequency = Random.Range(3f, 5f) + 4;
                        break;
                    case 3:
                        spawnFrequency = Random.Range(2f, 4f) + 6;
                        bombSpawnFrequency = Random.Range(3f, 5f) + 6;
                        break;
                }
                fruitforce = 5;
                break;
            case 4:
                switch (spawnerID)
                {
                    case 0:
                        spawnFrequency = Random.Range(1f, 3f);
                        bombSpawnFrequency = Random.Range(2f, 4f);
                        break;
                    case 1:
                        spawnFrequency = Random.Range(1f, 3f) + 1;
                        bombSpawnFrequency = Random.Range(2f, 4f) + 1;
                        break;
                    case 2:
                        spawnFrequency = Random.Range(1f, 3f) + 3;
                        bombSpawnFrequency = Random.Range(2f, 4f) + 3;
                        break;
                    case 3:
                        spawnFrequency = Random.Range(1f, 3f) + 5;
                        bombSpawnFrequency = Random.Range(2f, 4f) + 5;
                        break;
                }
                fruitforce = 6;
                break;
            case 5:
                switch (spawnerID)
                {
                    case 0:
                        spawnFrequency = 1f;
                        bombSpawnFrequency = 1.5f;
                        break;
                    case 1:
                        spawnFrequency = 2f;
                        bombSpawnFrequency = 2.5f;
                        break;
                    case 2:
                        spawnFrequency = 3f;
                        bombSpawnFrequency = 3.5f;
                        break;
                    case 3:
                        spawnFrequency = 4f;
                        bombSpawnFrequency = 4.5f;
                        break;
                }
                fruitforce = 7;
                break;
        }
    }

    private IEnumerator FruitGenerator()
    {
        while (true)
        {
            int peartospawn = Random.Range(0, 100);
            if (peartospawn == 69) Instantiate(pearto, spawner.transform.position, Quaternion.identity);
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
