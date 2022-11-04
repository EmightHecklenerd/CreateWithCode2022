using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySController : MonoBehaviour
{
    private float speed = 10;
    public GameObject enemyProjectile;
    public float delay = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnEnableRoutine());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnEnable()
    {
        GameObject launchedObject = Instantiate(enemyProjectile, transform.position, transform.rotation);
        launchedObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 20f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator OnEnableRoutine()
    {
        yield return new WaitForSeconds(delay);
        OnEnable();
        // Code to execute after the delay
    }
}
