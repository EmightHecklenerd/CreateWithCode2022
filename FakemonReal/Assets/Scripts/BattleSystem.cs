using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost} 

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!");
        state = BattleState.Start;
        SetUpBattle();
    }

    
    public void SetUpBattle()
    {

    }
}
