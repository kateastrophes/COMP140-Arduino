using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color currentColour;
    public float lightTimer;
    public string[] wireColours = { "Red", "Green", "Blue", "Yellow" };

    private Animator anim;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ChooseRandomWire();
    }



    void ChooseRandomWire()
    {
        string chosenWire = wireColours[Random.Range(0, wireColours.Length)];
        if (chosenWire == "Red")
        {
            Debug.Log("Red wire has been selected.");
            RedWire();
        }
        if (chosenWire == "Green")
        {
            Debug.Log("Green wire has been selected");
            GreenWire();
        }
        if (chosenWire == "Yellow")
        {
            Debug.Log("Yellow wire has been selected"); 
            YellowWire();
        }
        if (chosenWire == "Blue")
        {
            Debug.Log("Blue wire has been selected"); 
            BlueWire();
        }
    }

    void RedWire()
    {
        anim.SetBool("RedLight", true);
    }


    void GreenWire()
    {
        anim.SetBool("GreenLight", true);
    }

    void YellowWire()
    {
        anim.SetBool("YellowLight", true);
    }

    void BlueWire()
    {
        anim.SetBool("BlueLight", true);
    }
}
