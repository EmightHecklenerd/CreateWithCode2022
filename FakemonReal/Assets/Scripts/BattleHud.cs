using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHud : MonoBehaviour
{
    public GameObject health;
    public float hpText;

    private void Start()
    {

    }

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1.0f);

    }

}
