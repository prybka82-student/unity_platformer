using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public Transform[] coinSpawns;  // tablica generowanych monet
    public GameObject coin;         // prototyp małej monety (obiekt prefab)
    public GameObject bigCoin;      // prototyp dużej monety (obiekt prefab)

    void Start()
    {
        Spawn(); //wygenerowanie monet
    }

    void Update() { }

    void Spawn()
    {
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            if (CoinFlip()) //rzut monetą -- losowanie występowania monety w danej pozycji
            {
                if (CoinFlip()) //jeśli moneta ma się pojawić, to jaka: mała czy duża
                    CreateCoin(coin, i);
                else
                    CreateCoin(bigCoin, i);                
            }
        }
    }

    bool CoinFlip() => Random.Range(0, 2) > 0; //rzut monetą
    void CreateCoin(GameObject coin, int index) //generowanie monety i dodanie na pozycji z tabeli  
        => Instantiate(coin, coinSpawns[index].position, Quaternion.identity); 
}
