using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySController : MonoBehaviour
{
    private float speed = 10;
    public GameObject e_projectile;
    public float delay = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateUpdateRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        GameObject launchedObject = Instantiate(e_projectile, transform.position, transform.rotation);
        launchedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 20f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator LateUpdateRoutine()
    {
        yield return new WaitForSeconds(delay);
        LateUpdate();
        // Code to execute after the delay
    }
}
