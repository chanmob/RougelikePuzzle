using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public Bomb bomb;

    public CardReset cardReset;

    public ChangeCardPosition changeCardPosition;

    public Weapon weapon;

    public Coin coin;

    public FlameThrower flameThrower;
    public FlameThrower2Way flameThrower2Way;
    public Thorn thorn;

    public Monster monster;

    public RedPotion potion;

    public void TempVoid()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
    }

    protected override void OnAwake()
    {
        bomb = Resources.Load<Bomb>("Objects/Bomb");
        cardReset = Resources.Load<CardReset>("Objects/CardReset");
        changeCardPosition = Resources.Load<ChangeCardPosition>("Objects/ChangeCardPosition");
        weapon = Resources.Load<Weapon>("Objects/Weapon");
        coin = Resources.Load<Coin>("Objects/Coin");
        //flameThrower2Way = Resources.Load<FlameThrower2Way>("Objects/FlameThrower2Way");
        flameThrower = Resources.Load<FlameThrower>("Objects/Flame");
        thorn = Resources.Load<Thorn>("Objects/Thorn");
        monster = Resources.Load<Monster>("Objects/Monster");
        potion = Resources.Load<RedPotion>("Objects/Potion");
    }
}