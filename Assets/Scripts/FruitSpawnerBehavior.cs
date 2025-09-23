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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FruitGenerator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FruitGenerator()
    {
        while (true)
        {
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
                        Instantiate(tomato, transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(coconut, transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(banana, transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(watermelon, transform.position, Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(redApple, transform.position, Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(greenApple, transform.position, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(pear, transform.position, Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(orange, transform.position, Quaternion.identity);
                        break;
                }
            } 
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }
}
