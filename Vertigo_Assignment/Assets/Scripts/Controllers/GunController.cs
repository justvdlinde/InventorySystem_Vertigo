using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public float bulletSpeed;
    public float timeBetweenShots;

    public BulletController bullet;
    public Transform bulletSpawn;
    
    private float shotCounter;
    private float singleShot = 1f;
    private float automaticShot = .2f;
    private Ammo ammo;

    private void Update () {
        ammo = FindObjectOfType<Ammo>();
        shotCounter -= Time.deltaTime;
        if (isFiring) {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            SwitchGunMode();
        }
	}

    private void Shoot() {
        if (shotCounter <= 0) {
            if (ammo != null) {
                if (ammo.curAmmo.Count > 1) {
                    shotCounter = timeBetweenShots;
                    BulletController newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                    ammo.RemoveAmmo();
                }
            }
        }
    }

    private void SwitchGunMode() {
        if (timeBetweenShots == singleShot) {
            timeBetweenShots = automaticShot;
        }
        else {
            timeBetweenShots = singleShot;
        }
    }
}
