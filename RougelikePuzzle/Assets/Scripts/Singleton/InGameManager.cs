using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public Player player { get; private set; }

    private int _getCoin = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void GetCoin(int coin)
    {
        _getCoin += coin;
    }
}
