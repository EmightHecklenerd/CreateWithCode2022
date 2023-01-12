using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHud : MonoBehaviour
{
    public GameObject health;
    public float hpText;

    private void Start()
    {
        health.transform.localScale = new Vector3(0.5f, 1.0f);
    }

   
  
}
