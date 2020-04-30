using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the state of the game. 
/// </summary>
public class GameManager : MonoBehaviour
{
    public Color currentColour;
    public float lightTimer;
    public string[] wireColours = { "Red", "Green", "Blue", "Yellow" };
    public static int score;
    private Animator anim;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        score = 0;
        ChooseRandomWire();
    }


    /// <summary>
    /// Randomly chooses one colour out of four and the runs the relevent function.
    /// </summary>
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
        string redTag = "C3 17 F2 0A";
        if (redTag == Arduino.cardTag)
        {
            score = score + 5;
            ChooseRandomWire();
        }
        if (redTag != Arduino.cardTag)
        {
            ChooseRandomWire();
        }
    }


    void GreenWire()
    {
        anim.SetBool("GreenLight", true);
        string greenTag = "F3 F4 E1 0A";
        if (greenTag == Arduino.cardTag)
        {
            score = score + 5;
            ChooseRandomWire();
        }
        if (greenTag != Arduino.cardTag)
        {
            ChooseRandomWire();
        }
    }

    void YellowWire()
    {
        anim.SetBool("YellowLight", true);
        string yellowTag = "03 A6 B3 0C";
        if (yellowTag == Arduino.cardTag)
        {
            score = score + 5;
            ChooseRandomWire();
        }
        if (yellowTag != Arduino.cardTag)
        {
            ChooseRandomWire();
        }
    }

    void BlueWire()
    {
        anim.SetBool("BlueLight", true);
        string blueTag = "93 0F 33 0B";
        if (blueTag == Arduino.cardTag)
        {
            score = score + 5;
            ChooseRandomWire();
        }
        if (blueTag != Arduino.cardTag)
        {
            ChooseRandomWire();
        }
    }

}
