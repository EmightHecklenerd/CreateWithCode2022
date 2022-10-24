using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        //overcomlicated movement//
        float translation = Input.GetAxis("Vertical") * speed;
        float translation1 = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        translation1 *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Translate(translation1, 0, 0);


    }

    private void OnCollisionEnter(Collision other)
    { 
        //if touch coin, delete coin and say coin hit//
        if (other.gameObject.CompareTag("Coin")) 
        {
            Destroy(other.gameObject);
            Debug.Log("Coin Hit");
        }
        
        // if touch enemy, delete player//
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy Hit");
        }
    }
}
