using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private const string PATH_POTION = "Objects/Potion/";
    private const string PATH_MONSTER = "Objects/Monster/";
    private const string PATH_TRAP = "Objects/Trap/";

    [Header("Bomb")]
    public Bomb bomb;

    
    [Header("Weapon")]
    public Weapon weapon;

    public Coin coin;

    public FlameThrower flameThrower;
    public FlameThrower2Way flameThrower2Way;
    public Thorn thorn;

    public Monster ghost;

    [Header("Potion")]
    public BlackPotion blackPotion;
    public BluePotion bluePotion;
    public PinkPotion pinkPotion;
    public PurplePotion purplePotion;
    public RedPotion redPotion;
    public YellowPotion yellowPotion;
    

    [Header("ETC")]
    public CardReset cardReset;

    public ChangeCardPosition changeCardPosition;


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
        flameThrower = Resources.Load<FlameThrower>("Objects/Flame");
        
        
        //Trap
        thorn = Resources.Load<Thorn>(PATH_TRAP + "Thorn");
        //Trap


        //Monster
        ghost = Resources.Load<Monster>(PATH_MONSTER + "Ghost");
        //Monster


        //Potion
        blackPotion = Resources.Load<BlackPotion>(PATH_POTION + "BlackPotion");
        bluePotion = Resources.Load<BluePotion>(PATH_POTION + "BluePotion");
        pinkPotion = Resources.Load<PinkPotion>(PATH_POTION + "PinkPotion");
        purplePotion = Resources.Load<PurplePotion>(PATH_POTION + "PurplePotion");
        redPotion = Resources.Load<RedPotion>(PATH_POTION + "RedPotion");
        yellowPotion = Resources.Load<YellowPotion>(PATH_POTION + "Yellowpotion");
        //Potion
    }
}