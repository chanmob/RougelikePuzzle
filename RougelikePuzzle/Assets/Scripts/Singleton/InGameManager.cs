using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    private Player _player;

    public bool CheckDistance(Card card)
    {
        return Mathf.Abs((_player.vector.x + card.vector.x) - (_player.vector.y - _player.vector.y)) == 1; 
    }
}
