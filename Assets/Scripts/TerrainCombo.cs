using UnityEngine;

public class TerrainCombo : MonoBehaviour
{
    [SerializeField]
    private GameOver_and_UI UIScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("1PointFruit") || collision.gameObject.CompareTag("3PointFruit") || collision.gameObject.CompareTag("Pearto"))
        {
            UIScreen.comboMult = 1;
        }
    }
}
