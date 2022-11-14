using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AddressableAssets;

public class FiringSystem : Controller
{
    [SerializeField] private Transform projectileSpawnPosition; // Turret barrel / cylinder.
    [SerializeField] private AssetReference projectileAsset;

    private void Awake()
    {
        base.Init();
    }

    public async void Fire_performed(Transform t)
    {
        GameObject newBullet = await Addressables.InstantiateAsync(projectileAsset).Task; // (Y)
        newBullet.GetComponent<BulletBasic>().Setup(t.eulerAngles, t.position, 1f, 1f);
    }
}