using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public Transform[] coinSpawns;
    public GameObject coin;
    public GameObject bigCoin;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        for (int i = 0; i < coinSpawns.Length; i++)
        {
            if (CoinFlip())
            {
                if (CoinFlip())
                    CreateCoin(coin, i);
                else
                    CreateCoin(bigCoin, i);                
            }
        }
    }

    bool CoinFlip() => Random.Range(0, 2) > 0;
    void CreateCoin(GameObject coin, int index) => Instantiate(coin, coinSpawns[index].position, Quaternion.identity); 
}
