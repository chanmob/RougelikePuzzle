using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [Header("CardReset")]
    private Stack<CardReset> _stack_CardReset;
    [SerializeField]
    private Transform _tr_CardReset;

    [Header("ChangeCardPosition")]
    private Stack<ChangeCardPosition> _stack_ChangeCardPosition;
    [SerializeField]
    private Transform _tr_ChangeCardPosition;

    [Header("Trap")]
    private Stack<FlameThrower> _stack_FlameThrower;
    [SerializeField]
    private Transform _tr_FlameThrower;

    private Stack<FlameThrower2Way> _stack_FlameThrower2Way;
    [SerializeField]
    private Transform _tr_FlameThrower2Way;

    private Stack<Thorn> _stack_Thorn;
    [SerializeField]
    private Transform _tr_Thorn;

    [Header("Potion")]
    private Stack<RedPotion> _stack_RedPotion;
    [SerializeField]
    private Transform _tr_RedPotion;

    [Header("Monster")]
    private Stack<Monster> _stack_Monster;
    [SerializeField]
    private Transform _tr_Monster;

    [Header("Weapon")]
    private Stack<Weapon> _stack_Weapon;
    [SerializeField]
    private Transform _tr_Weapon;

    [Header("Bomb")]
    private Stack<Bomb> _stack_Bomb;
    [SerializeField]
    private Transform _tr_Bomb;

    [Header("Coin")]
    private Stack<Coin> _stack_Coin;
    [SerializeField]
    private Transform _tr_Coin;

    protected override void OnAwake()
    {
        base.OnAwake();

        _stack_Bomb = new Stack<Bomb>();
        _stack_CardReset = new Stack<CardReset>();
        _stack_ChangeCardPosition = new Stack<ChangeCardPosition>();
        _stack_Coin = new Stack<Coin>();
        _stack_FlameThrower = new Stack<FlameThrower>();
        _stack_FlameThrower2Way = new Stack<FlameThrower2Way>();
        _stack_Monster = new Stack<Monster>();
        _stack_RedPotion = new Stack<RedPotion>();
        _stack_Thorn = new Stack<Thorn>();
        _stack_Weapon = new Stack<Weapon>();
    }

    #region CardReset
    private void MakeCardReset(int count)
    {
        for(int i = 0; i < count; i++)
        {
            CardReset newCardReset = Instantiate(DataManager.instance.cardReset);
            newCardReset.gameObject.SetActive(false);
            newCardReset.transform.SetParent(_tr_CardReset);

            _stack_CardReset.Push(newCardReset);
        }
    }

    public CardReset GetCardReset()
    {
        int cnt = _stack_CardReset.Count;

        if (cnt == 0)
            MakeCardReset(1);

        return _stack_CardReset.Pop();
    }

    public void ReturnCardReset(CardReset card)
    {
        if(card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_CardReset);
        _stack_CardReset.Push(card);
    }
    #endregion

    #region ChangeCardPosition
    private void MakeChangeCardPosition(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ChangeCardPosition newChangeCardPosition = Instantiate(DataManager.instance.changeCardPosition);
            newChangeCardPosition.gameObject.SetActive(false);
            newChangeCardPosition.transform.SetParent(_tr_ChangeCardPosition);

            _stack_ChangeCardPosition.Push(newChangeCardPosition);
        }
    }

    public ChangeCardPosition GetChangeCardPosition()
    {
        int cnt = _stack_ChangeCardPosition.Count;

        if (cnt == 0)
            MakeChangeCardPosition(1);

        return _stack_ChangeCardPosition.Pop();
    }

    public void ReturnChangeCardPosition(ChangeCardPosition card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_ChangeCardPosition);
        _stack_ChangeCardPosition.Push(card);
    }
    #endregion

    #region Trap
    private void MakeFlameThrower(int count)
    {
        for (int i = 0; i < count; i++)
        {
            FlameThrower newFlameThrower = Instantiate(DataManager.instance.flameThrower);
            newFlameThrower.gameObject.SetActive(false);
            newFlameThrower.transform.SetParent(_tr_FlameThrower);

            _stack_FlameThrower.Push(newFlameThrower);
        }
    }

    public FlameThrower GetFlameThrower()
    {
        int cnt = _stack_FlameThrower.Count;

        if (cnt == 0)
            MakeFlameThrower(1);

        return _stack_FlameThrower.Pop();
    }

    public void ReturnFlameThrower(FlameThrower card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_FlameThrower);
        _stack_FlameThrower.Push(card);
    }

    private void MakeFlameThrower2Way(int count)
    {
        for (int i = 0; i < count; i++)
        {
            FlameThrower2Way newFlameThrower2Way = Instantiate(DataManager.instance.flameThrower2Way);
            newFlameThrower2Way.gameObject.SetActive(false);
            newFlameThrower2Way.transform.SetParent(_tr_FlameThrower2Way);

            _stack_FlameThrower2Way.Push(newFlameThrower2Way);
        }
    }

    public FlameThrower2Way GetFlameThrower2Way()
    {
        int cnt = _stack_FlameThrower2Way.Count;

        if (cnt == 0)
            MakeFlameThrower2Way(1);

        return _stack_FlameThrower2Way.Pop();
    }

    public void ReturnFlameThrower(FlameThrower2Way card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_FlameThrower2Way);
        _stack_FlameThrower2Way.Push(card);
    }

    private void MakeThorn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Thorn newThorn = Instantiate(DataManager.instance.thorn);
            newThorn.gameObject.SetActive(false);
            newThorn.transform.SetParent(_tr_Thorn);

            _stack_Thorn.Push(newThorn);
        }
    }

    public Thorn GetThorn()
    {
        int cnt = _stack_Thorn.Count;

        if (cnt == 0)
            MakeThorn(1);

        return _stack_Thorn.Pop();
    }

    public void ReturnThorn(Thorn card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_Thorn);
        _stack_Thorn.Push(card);
    }
    #endregion

    #region Potion
    private void MakeRedPotion(int count)
    {
        for (int i = 0; i < count; i++)
        {
            RedPotion newRedPotion = Instantiate(DataManager.instance.potion);
            newRedPotion.gameObject.SetActive(false);
            newRedPotion.transform.SetParent(_tr_RedPotion);

            _stack_RedPotion.Push(newRedPotion);
        }
    }

    public RedPotion GetRedPotion()
    {
        int cnt = _stack_RedPotion.Count;

        if (cnt == 0)
            MakeRedPotion(1);

        return _stack_RedPotion.Pop();
    }

    public void ReturnRedPotion(RedPotion card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_RedPotion);
        _stack_RedPotion.Push(card);
    }
    #endregion

    #region Monster
    private void MakeMonster(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Monster newMonster = Instantiate(DataManager.instance.monster);
            newMonster.gameObject.SetActive(false);
            newMonster.transform.SetParent(_tr_Monster);

            _stack_Monster.Push(newMonster);
        }
    }

    public Monster GetMonster()
    {
        int cnt = _stack_Monster.Count;

        if (cnt == 0)
            MakeMonster(1);

        return _stack_Monster.Pop();
    }

    public void ReturnMonster(Monster card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_Monster);
        _stack_Monster.Push(card);
    }
    #endregion

    #region Weapon
    private void MakeWeapon(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Weapon newWeapon = Instantiate(DataManager.instance.weapon);
            newWeapon.gameObject.SetActive(false);
            newWeapon.transform.SetParent(_tr_Weapon);

            _stack_Weapon.Push(newWeapon);
        }
    }

    public Weapon GetWeapon()
    {
        int cnt = _stack_Weapon.Count;

        if (cnt == 0)
            MakeWeapon(1);

        return _stack_Weapon.Pop();
    }

    public void ReturnWeapon(Weapon card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_Weapon);
        _stack_Weapon.Push(card);
    }
    #endregion

    #region Bomb
    private void MakeBomb(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bomb newBomb = Instantiate(DataManager.instance.bomb);
            newBomb.gameObject.SetActive(false);
            newBomb.transform.SetParent(_tr_Bomb);

            _stack_Bomb.Push(newBomb);
        }
    }

    public Bomb GetBomb()
    {
        int cnt = _stack_Bomb.Count;

        if (cnt == 0)
            MakeBomb(1);

        return _stack_Bomb.Pop();
    }

    public void ReturnBomb(Bomb card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_Bomb);
        _stack_Bomb.Push(card);
    }
    #endregion

    #region Coin
    private void MakeCoin(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Coin newCoin = Instantiate(DataManager.instance.coin);
            newCoin.gameObject.SetActive(false);
            newCoin.transform.SetParent(_tr_Coin);

            _stack_Coin.Push(newCoin);
        }
    }

    public Coin GetCoin()
    {
        int cnt = _stack_Coin.Count;

        if (cnt == 0)
            MakeCoin(1);

        return _stack_Coin.Pop();
    }

    public void ReturnCoin(Coin card)
    {
        if (card.gameObject.activeSelf)
            card.gameObject.SetActive(false);

        card.transform.SetParent(_tr_Coin);
        _stack_Coin.Push(card);
    }
    #endregion
}
