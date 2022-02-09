using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionUI : MonoBehaviour
{

    public UnityEngine.UI.Image rock;
    public UnityEngine.UI.Image paper;
    public UnityEngine.UI.Image scissors;




    enum SelectedWeapon
    {
        rock, paper, scissors
    }

    SelectedWeapon selectedWeapon;

    public int selectedWeaponAsINT = 1; //messy, couldn't figure out a way to pass enums from other script.

    public Color activatedColor;
    public Color inactiveColor;


    public void UpdateWeaponIcon()
    {


        switch (selectedWeaponAsINT)
        {
            case 1:
                selectedWeapon = SelectedWeapon.rock;
                break;
            case 2:
                selectedWeapon = SelectedWeapon.paper;
                break;
            case 3:
                selectedWeapon = SelectedWeapon.scissors;
                break;
            default:
                break;
        }


        switch (selectedWeapon)
        {
            case SelectedWeapon.rock:
                rock.color = activatedColor;
                paper.color = inactiveColor;
                scissors.color = inactiveColor;

                break;
            case SelectedWeapon.paper:
                rock.color = inactiveColor;
                paper.color = activatedColor;
                scissors.color = inactiveColor;
                break;
            case SelectedWeapon.scissors:
                rock.color = inactiveColor;
                paper.color = inactiveColor;
                scissors.color = activatedColor;
                break;
            default:
                break;
        }







    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
