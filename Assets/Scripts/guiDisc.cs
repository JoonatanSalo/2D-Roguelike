using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiDisc : MonoBehaviour
{
    public Image DiscImage;
    public Sprite GreyDisc;
    public Sprite BlueDisc;
    public Sprite DamagedDisc;
    public Sprite DeadDisc;
    public Sprite DamagedFadedDisc;

    public bool hasDisc;
    public bool damaged;
    public bool isDead;

    void Start ()
    {
        damaged = false;
        hasDisc = true;
        isDead = false;
    }

    public void ChangeGUIDiscSprite()
    {
        if (isDead)
        {
            DiscImage.sprite = DeadDisc;
        }
        else if(hasDisc && damaged)
        {
            DiscImage.sprite = DamagedDisc;
        }
        else if (hasDisc)
        {
            DiscImage.sprite = BlueDisc;
        }
        else if (damaged && !hasDisc)
        {
            DiscImage.sprite = DamagedFadedDisc;
        }
        else
        {
            DiscImage.sprite = GreyDisc;
        }
    }
}
