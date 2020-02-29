using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric_Cabinet_Script : MonoBehaviour
{
    public Sprite cabinetOn;
    public Sprite cabinetOff;

    public Sprite E_sprite;
    public Sprite Empty;

    public bool working;
    public int Energy;

    public BoxCollider2D bc2d;
    public GameObject ButtonIndicator;
    public bool collisionFlag = false;
    private GameObject collisionObject;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = cabinetOn;
        ButtonIndicator.GetComponent<SpriteRenderer>().sprite = Empty;
        Energy = 1;
        working = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && working && collisionFlag)
        {
            GetComponent<SpriteRenderer>().sprite = cabinetOff;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = Empty;
            working = false;
            collisionObject.GetComponent<EnergyManager>().GainEnergy(Energy);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        collisionFlag = true;
        collisionObject = col.gameObject;
        if (working) ButtonIndicator.GetComponent<SpriteRenderer>().sprite = E_sprite;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        collisionFlag = false;
        collisionObject = col.gameObject;
        ButtonIndicator.GetComponent<SpriteRenderer>().sprite = Empty;
    }
}
