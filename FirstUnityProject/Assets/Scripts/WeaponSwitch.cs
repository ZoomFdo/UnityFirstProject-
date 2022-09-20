using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class WeaponSwitch : MonoBehaviour
{
    public int selectWeapon = 0;
    public TextMeshProUGUI AmmoInfoText;

    public float mouseSensitivity = 0.5f;

    InputAction switching;
    // Start is called before the first frame update
    void Start()
    {
        switching = new InputAction("Scroll", binding: "<Mouse>/scroll");
        switching.AddBinding("<Gamepad>/Dpad");
        switching.Enable();
        SelectWeapon();

       
    }

    // Update is called once per frame
    void Update()
    {
        Arbalet currentArbalet = FindObjectOfType<Arbalet>();
        AmmoInfoText.text = currentArbalet.currentAmmo + " / " + currentArbalet.magazineSize;
        float ScrollValue = switching.ReadValue<Vector2>().y;

        ScrollValue *= mouseSensitivity;

        int previousSelected = selectWeapon;
        if(ScrollValue > 0) {
            selectWeapon++;
            if(selectWeapon == 3) {
                selectWeapon = 0;
            }
        } else if(ScrollValue < 0) {
            selectWeapon--;
            if(selectWeapon == -1) {
                selectWeapon = 2;
            }
        }

        if(previousSelected != selectWeapon) {
            SelectWeapon();
        }
        
    }

    private void SelectWeapon() {
         foreach(Transform weapon in transform) {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectWeapon).gameObject.SetActive(true);
    }




}
