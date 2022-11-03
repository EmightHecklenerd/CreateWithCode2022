using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floater")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shooter")
        {         
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "E_Projectile")
        {
            Destroy(gameObject);
        }
    }
}
