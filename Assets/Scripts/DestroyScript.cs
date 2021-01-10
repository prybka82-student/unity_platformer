using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
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
        //if (other.gameObject.CompareTag("Player"))
        if (CheckTag(other.gameObject, "Player"))
            Application.LoadLevel(Application.loadedLevel); //obsolete            
        
        if (CheckTag(other.gameObject, "Platform"))
            Destroy(other.gameObject);
    }

    //void OnCollision2D(GameObject other)
    //{
        //if (other.gameObject.CompareTag("Platform"))
            //Destroy(other.gameObject); //ma niszczyć spadające platformy, ale nie działa, gdy obiekt jest typu trigger
    //}

    bool CheckTag(GameObject obj, string tag) => obj.gameObject.CompareTag(tag);
}
