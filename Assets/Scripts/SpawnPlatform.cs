using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour
{
    public int maxPlatforms = 20;       //liczba wygenerowanych paltform

    public GameObject platform;         //prefabrykat platformy

    public float horizontalMin = 7.5f;  //zakres generowania platformy
    public float horizontalMax = 14f;   //w poziomie
    public float verticalMin = -6f;     //w pionie
    public float verticalMax = 6f;

    private Vector2 originPosition;     //położenie obiektu generującego spawner

    void Start()
    {
        originPosition = transform.position;    //ustalenie pozycji spawnera
        Spawn();                        //generowanie
    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            //nowa pozycja to suma wyjściowej i losowych wartości dla współrzędnych x i y
            Vector2 randomPosition = originPosition + new Vector2(
                Random.Range(horizontalMin, horizontalMax), 
                Random.Range(verticalMin, verticalMax));
            
            //właściwe stworzenie platformy 
            Instantiate(platform, randomPosition, Quaternion.identity);

            //nowa pozycja staje się wyjściową dla kolejnej platformy
            originPosition = randomPosition;
        }
    }


}
