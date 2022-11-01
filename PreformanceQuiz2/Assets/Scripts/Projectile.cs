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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject launchedObject = Instantiate(projectile, transform.position, transform.rotation);
            launchedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 950f));

        }

        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
