using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSystem : MonoBehaviour
{
    private float BonusTime = 0;// счетчие времени жизни бонуса [сек* Timestep(0.02 cек)]
    private float MaxBonusTime = 10f;//максимальное  время жизни бонуса [сек]

    //флаги
    public bool infinitieJump = false;
    public bool isFlying = false;
    private bool BonusActive = false; //индикатор активности бонуса

    public uiScript ui;

    private void Update()
    {
        BonusCheck();
    }

    public void FlyBonus()
    {
            DisableBonuses();//вызов отключения остальных бонусов
            BonusActive = true;
            ui.BonusesText.SetText("Fly Bonus!"); //вывод названия бонуса на экран
            ui.flyJoystick.SetActive(true);    
            ui.BonuseScreen.SetActive(true);
    }
    public void JumpBonus()
    {
        Debug.Log("БОНУС ПОДОБРАН");
        DisableBonuses();//вызов отключения остальных бонусов
        BonusActive = true;
        ui.BonusesText.SetText("Infinite Jump Bonus!");//вывод названия бонуса на экран
        ui.BonuseScreen.SetActive(true);
    }


    private void BonusCheck()
    {
        if (BonusActive && BonusTime < MaxBonusTime) //проверка наличия бонуса и не истекло ли время его жизни
        {
            BonusTime += 0.02f;//обновляем текущее врямя бонуса
        }
        else if (BonusTime > MaxBonusTime)
        {
            DisableBonuses();//отключаем бонус если время его жизни вышло
        }
    }

    private void DisableBonuses() //функция отключения всех бонусов
    {
        BonusActive = false;
        isFlying = false;
        infinitieJump = false;
        BonusTime = 0;
        ui.BonuseScreen.SetActive(false);
        ui.flyJoystick.SetActive(false);
    }
}
