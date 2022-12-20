using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(playerPrefab);
        Instantiate(enemyPrefab);
    }
}
