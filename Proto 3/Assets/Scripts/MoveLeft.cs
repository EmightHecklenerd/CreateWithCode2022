using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerContollerScript;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerContollerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContollerScript.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

    }
}
