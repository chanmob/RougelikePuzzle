using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
        Addressables.LoadAssetAsync<GameObject>("Bomb").Completed += AddressableToBomb;
        Addressables.LoadAssetAsync<GameObject>("CardReset").Completed += AddressableToCardReset;
        Addressables.LoadAssetAsync<GameObject>("ChangeCardPosition").Completed += AddressableToChangeCardPosition;
        Addressables.LoadAssetAsync<GameObject>("Coin").Completed += AddressableToCoin;
        Addressables.LoadAssetAsync<GameObject>("Flame").Completed += AddressableToFlameThrower;
        Addressables.LoadAssetAsync<GameObject>("Monster").Completed += AddressableToMonster;
        Addressables.LoadAssetAsync<GameObject>("Potion").Completed += AddressableToPotion;
        Addressables.LoadAssetAsync<GameObject>("Thorn").Completed += AddressableToThorn;
        Addressables.LoadAssetAsync<GameObject>("Weapon").Completed += AddressableToWeapon;
    }

    public void AddressableToBomb(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            bomb = obj.Result.GetComponent<Bomb>();
        }
    }

    public void AddressableToCardReset(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            cardReset = obj.Result.GetComponent<CardReset>();
        }
    }

    public void AddressableToChangeCardPosition(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            changeCardPosition = obj.Result.GetComponent<ChangeCardPosition>();
        }
    }

    public void AddressableToWeapon(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            weapon = obj.Result.GetComponent<Weapon>();
        }
    }

    public void AddressableToCoin(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            coin = obj.Result.GetComponent<Coin>();
        }
    }

    public void AddressableToFlameThrower(AsyncOperationHandle<GameObject> obj)
    {
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            flameThrower = obj.Result.GetComponent<FlameThrower>();
        }
    }

    public void AddressableToFlameThrower2Way(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            flameThrower2Way = obj.Result.GetComponent<FlameThrower2Way>();
        }
    }

    public void AddressableToThorn(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            thorn = obj.Result.GetComponent<Thorn>();
        }
    }

    public void AddressableToMonster(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            monster = obj.Result.GetComponent<Monster>();
        }
    }

    public void AddressableToPotion(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            potion = obj.Result.GetComponent<RedPotion>();
        }
    }
}