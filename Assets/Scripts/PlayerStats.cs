using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int PlayerLevel;
    public Slider ExpBar;
    public Text LevelIndicatorText;

    public int Strength;
    public int Agility;
    public int Neural;

    int ExpTillLevel = 100;
    int currentExp;
 


    void Start()
    {
        currentExp = 0;
        PlayerLevel = 1;
        LevelIndicatorText.text = PlayerLevel.ToString();

        Strength = 5;
        Agility = 5;
        Neural = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUp(1, 1, 1, 1);
        }
    }

    public void GainExp (int ExpAmount)
    {
        currentExp += ExpAmount;

        if (currentExp >= ExpTillLevel)
        {
            LevelUp(1, 1, 1, 1);
            PlayerLevel = +1;
        }
        ExpBar.value = currentExp;
    }

    void LevelUp (int AddedStrength, int AddedAgility, int AddedNeural, int AddedEnergy)
    {
        PlayerLevel++;
        currentExp = 0;

        Strength += AddedStrength;
        Agility += AddedAgility;
        Neural += AddedNeural;

        GetComponent<EnergyManager>().MaxEnergyUp(AddedEnergy);
        LevelIndicatorText.text = PlayerLevel.ToString();

        ExpTillLevel += 100;
    }
}
