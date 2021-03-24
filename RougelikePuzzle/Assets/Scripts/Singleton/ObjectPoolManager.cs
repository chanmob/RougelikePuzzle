using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public FlameThrower2Way monster;

    private void Start()
    {
        Debug.Log("HELLEOEO");
        Addressables.LoadAssetAsync<GameObject>("TestMonster").Completed += D;
    }

    public void D(AsyncOperationHandle<GameObject> t)
    {
        if(t.Status == AsyncOperationStatus.Succeeded)
        {
            monster = t.Result.GetComponent<Trap>() as FlameThrower2Way;
            Instantiate(monster);
        }
    }
}