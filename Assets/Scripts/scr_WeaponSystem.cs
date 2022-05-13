using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_WeaponSystem : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public scr_Bullet BulletPrefab;
    public float FireRate = 1f;

    private float fireRateCounter;

    // Update is called once per frame
    void Update()
    {
        fireRateCounter += Time.deltaTime;
    }
    public void Fire()
    {
        if(fireRateCounter >= FireRate)
        {
            fireRateCounter = 0;

            foreach(var spawnPoint in SpawnPoints)
            {
                Vector3 pos = spawnPoint.transform.position;
                Quaternion rot = spawnPoint.transform.rotation;
                Instantiate(BulletPrefab, pos, rot);
            }
        }
    }

}
