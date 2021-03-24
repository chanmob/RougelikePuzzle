using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public GameObject cardsParents;

    public Player player { get; private set; }

    private Card[] _cards;

    private int _cardsLen;

    private int _getCoin = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void GetCoin(int coin)
    {
        _getCoin += coin;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
        }
    }
}
