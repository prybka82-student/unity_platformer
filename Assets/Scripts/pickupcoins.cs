using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupcoins : MonoBehaviour
{
    public int pointsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //wykrycie dotknięcia monety przez obiekt o tagu "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject); //usunięcie monety
            Debug.Log("Coin was picked up");

            ScoreManager.AddPoints(pointsToAdd); //dodanie punktu
        }
    }
}
