using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Image Cell_1;
    public Image Cell_2;
    public Image Cell_3;
    public Image Cell_4;
    public Image Cell_5;

    public Sprite Empty;
    public Sprite EmptyCell;
    public Sprite FullCell;

    public bool hasEnergy;
    public int maxEnergy;
    public int currentEnergy;

    void Start()
    {
        maxEnergy = 2;
        currentEnergy = 0;
        hasEnergy = false;
        UpdateEnergyGUI();
    }

    public void GainEnergy(int amount)
    {
        hasEnergy = true;
        currentEnergy += amount;

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        UpdateEnergyGUI();
    }

    void UpdateEnergyGUI ()
    {
       switch (maxEnergy)
       {
            case 1:
                Cell_1.sprite = EmptyCell;
                Cell_2.sprite = Empty;
                Cell_3.sprite = Empty;
                Cell_4.sprite = Empty;
                Cell_5.sprite = Empty;
                break;
            case 2:
                Cell_1.sprite = EmptyCell;
                Cell_2.sprite = EmptyCell;
                Cell_3.sprite = Empty;
                Cell_4.sprite = Empty;
                Cell_5.sprite = Empty;
                break;
            case 3:
                Cell_1.sprite = EmptyCell;
                Cell_2.sprite = EmptyCell;
                Cell_3.sprite = EmptyCell;
                Cell_4.sprite = Empty;
                Cell_5.sprite = Empty;
                break;
            case 4:
                Cell_1.sprite = EmptyCell;
                Cell_2.sprite = EmptyCell;
                Cell_3.sprite = EmptyCell;
                Cell_4.sprite = EmptyCell;
                Cell_5.sprite = Empty;
                break;
            case 5:
                Cell_1.sprite = EmptyCell;
                Cell_2.sprite = EmptyCell;
                Cell_3.sprite = EmptyCell;
                Cell_4.sprite = EmptyCell;
                Cell_5.sprite = EmptyCell;
                break;
       }
       switch (currentEnergy)
       {
            case 0:
                break;
            case 1:
                Cell_1.sprite = FullCell;
                break;
            case 2:
                Cell_1.sprite = FullCell;
                Cell_2.sprite = FullCell;
                break;
            case 3:
                Cell_1.sprite = FullCell;
                Cell_2.sprite = FullCell;
                Cell_3.sprite = FullCell;
                break;
            case 4:
                Cell_1.sprite = FullCell;
                Cell_2.sprite = FullCell;
                Cell_3.sprite = FullCell;
                Cell_4.sprite = FullCell;
                break;
            case 5:
                Cell_1.sprite = FullCell;
                Cell_2.sprite = FullCell;
                Cell_3.sprite = FullCell;
                Cell_4.sprite = FullCell;
                Cell_5.sprite = FullCell;
                break;
        }
    }

    public bool HasEnoughEnergy (int amount)
    {
        if (amount <= currentEnergy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MaxEnergyUp (int amount) 
    {
        maxEnergy += amount;
        UpdateEnergyGUI();
    }
}
