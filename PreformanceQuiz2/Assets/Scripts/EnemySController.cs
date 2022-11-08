using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySController : MonoBehaviour
{
    private float speed = 10;
    public GameObject enemyProjectile;
    private float delay = 2;
    public GameObject shootPoint;

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
        Instantiate(enemyProjectile, shootPoint.transform.position, transform.rotation);

    }

    

    IEnumerator OnEnableRoutine()
    {
        yield return new WaitForSeconds(delay);
        OnEnable();
        // Code to execute after the delay
    }
}
