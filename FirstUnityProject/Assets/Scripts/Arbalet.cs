using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Arbalet : MonoBehaviour
{
    InputAction shoot;
    public Transform FpsCam;
    public float range = 50;// дальность стрельбы 
    public float force = 150;// сила удара
    public int fireRate = 10;
    private float nextTimeFire = 0;
    public int currentAmmo;//кол-во пуль 
    public int maxAmmo = 10;
    public int magazineSize = 30;

    public Animator animatorr;

    public float reloadTime = 1f;
    private bool isReloading;


    public ParticleSystem muzzleFlash;//эффект при стрельбе
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo == 0 && magazineSize ==0) {
            // animator.SetBool("isShooting", false);
            // return;
        }
        bool isShooting = shoot.ReadValue<float>() == 1;

        if(isShooting && Time.time >= nextTimeFire) { 

            nextTimeFire = Time.time + 1f / fireRate;
            Fire();
        }

        if(currentAmmo == 0 && !isReloading) {

        }

    }


    private void Fire() {
        RaycastHit hit;// попадание в объект
        muzzleFlash.Play();
        currentAmmo--;
        
        if(Physics.Raycast(FpsCam.position, FpsCam.forward, out hit, range)) {
            if(hit.rigidbody != null) {
                hit.rigidbody.AddForce(-hit.normal * force);
            }

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 5);//через сколько секунд исчезнет пуля
        }
    }

    // IEnumerator Reload() {
    //     isReloading = true;
    //     if(magazineSize >= maxAmmo) {
    //         currentAmmo = maxAmmo;
    //         magazineSize -= maxAmmo;
    //     } else {
    //         currentAmmo = magazineSize;
    //         magazineSize = 0;
    //     }
    //     isReloading = false;
    // }




}
