using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunMode
{
    automatic,
    semiAutomatic
}

public class Gun : MonoBehaviour
{
    public bool safetyPin = true;
    public float firePower = 1.0f;    
    public float coolDown = 1.0f;
    public int magasineCapacity = 10;
    public int nbLoadedBulled;
    public int bulletInventory = 100;
    public int maxBulletInventory = 100;
    public float reloadTime = 0.5f;
    public Transform bulletSpawnPoint;
    public KeyCode fireInput = KeyCode.Mouse0;
    public KeyCode reloadInput = KeyCode.R;
    public GunMode gunMode = GunMode.semiAutomatic;
    public GameObject bulletPrefab;
    float lastShotTime;
    bool reloading;
    int nbReloadBullet;

    private void Start()
    {
        reloading = false;
        nbLoadedBulled = magasineCapacity;
        lastShotTime = -coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        switch(gunMode)
        {
            case GunMode.automatic:
                {
                    if (Input.GetKey(fireInput))
                    {
                        Shoot();
                    }
                }
                break;
            case GunMode.semiAutomatic:
                {
                    if (Input.GetKeyDown(fireInput))
                    {
                        Shoot();
                    }
                }
                break;            
        }
        if (Input.GetKeyDown(reloadInput))
        {
            Reload();
        }
    }

    public void AddBullet(int nbBullet)
    {
        bulletInventory += nbBullet;
        if (bulletInventory > maxBulletInventory)
            bulletInventory = maxBulletInventory;
    }

    private void Shoot()
    {
        if (safetyPin || reloading || lastShotTime + coolDown > Time.time || nbLoadedBulled <= 0)
            return;

        GameObject newBullet = Instantiate(bulletPrefab);
        nbLoadedBulled--;
        Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), GetComponent<Collider>());
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.rotation = bulletSpawnPoint.rotation;
        Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
        if(newBulletRigidbody)
        {
            newBulletRigidbody.AddForce(bulletSpawnPoint.forward * firePower, ForceMode.Impulse);
        }
        lastShotTime = Time.time;
    }

    private void Reload()
    {
        if (reloading)
            return;

        reloading = true;
        int nbEmptySlot = magasineCapacity - nbLoadedBulled;
        if(nbEmptySlot <= bulletInventory)
        {
            bulletInventory -= nbEmptySlot;
            nbReloadBullet = nbEmptySlot;            
        }
        else
        {
            nbReloadBullet = bulletInventory;
            bulletInventory = 0;
        }
        if (reloadTime > 0)
            Invoke("OnReloadComplete", reloadTime);
        else
            OnReloadComplete();
    }

    private void OnReloadComplete()
    {
        reloading = false;
        nbLoadedBulled += nbReloadBullet;
    }

}
