using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Floater")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

       else if (collision.gameObject.tag == "E_Projectile")
       {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
       }

        else if (collision.gameObject.tag == "Shooter")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
