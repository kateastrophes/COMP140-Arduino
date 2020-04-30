using UnityEngine;

/// <summary>
/// Handles the state of the game. 
/// </summary>
public class GameManager : MonoBehaviour
{
    // public float lightTimer; ----> LED Ring burnt out so no longer in use.

    public string[] wireColours = { "Red",  "Green", "Blue",  "Yellow" };
    private string currentWire;

    public static int score;
    private Animator anim;

    /// <summary>
    /// Sets up default values. Fetches animation controller.
    /// </summary>
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        score = 0;
        currentWire = GetRandomWire();
    }

    void Update()
    {
        ChooseRandomWire();
        
        // Keyboard input
        if (Input.GetKeyDown(KeyCode.W) && currentWire == "Red")
        {
            RedWire("C3 17 F2 0A");
        }
        if (Input.GetKeyDown(KeyCode.A) && currentWire == "Green")
        {
            GreenWire("F3 F4 E1 0A");
        }
        if (Input.GetKeyDown(KeyCode.S) && currentWire == "Yellow")
        {
            YellowWire("03 A6 B3 0C");
        }
        if (Input.GetKeyDown(KeyCode.D) && currentWire == "Blue")
        {
            BlueWire("93 0F 33 0B");
        }
    }

    /// <summary>
    /// Randomly chooses one colour out of four and the runs the relevent function.
    /// </summary>
    void ChooseRandomWire()
    {

        if (currentWire == "Red")
        {
            Debug.Log("Red wire has been selected.");
            RedWire(Arduino.cardTag);
        }
        if (currentWire == "Green")
        {
            Debug.Log("Green wire has been selected");
            GreenWire(Arduino.cardTag);
        }
        if (currentWire == "Yellow")
        {
            Debug.Log("Yellow wire has been selected");
            YellowWire(Arduino.cardTag);
        }
        if (currentWire == "Blue")
        {
            Debug.Log("Blue wire has been selected");
            BlueWire(Arduino.cardTag);
        }
    }

    /// <summary>
    /// Returns a random wire colour.
    /// </summary>
    /// <returns>A string that resembles the wire colour.</returns>
    string GetRandomWire()
    {
        return wireColours[Random.Range(0, wireColours.Length)];
    }

    /// <summary>
    /// Sets the animation to the red light. Checks if the user input is correct.
    /// </summary>
    /// <param name="tag"></param>
    void RedWire(string tag)
    {
        anim.SetBool("RedLight", true);
        anim.SetBool("GreenLight", false); ;
        anim.SetBool("YellowLight", false);
        anim.SetBool("BlueLight", false);

        string redTag = "C3 17 F2 0A";
        if (redTag == tag)
        {
            score = score + 5;
            currentWire = GetRandomWire();
        }

        
    }

    /// <summary>
    /// Sets the animation to the green light. Checks if the user input is correct.
    /// </summary>
    /// <param name="tag"></param>
    void GreenWire(string tag)
    {
        anim.SetBool("GreenLight", true);
        anim.SetBool("RedLight", false);
        anim.SetBool("YellowLight", false);
        anim.SetBool("BlueLight", false); ;

        string greenTag = "F3 F4 E1 0A";
        if (greenTag == tag)
        {
            score = score + 5;
            currentWire = GetRandomWire();
        }

        
    }

    /// <summary>
    /// Sets the animation to the yellow light. Checks if the user input is correct.
    /// </summary>
    /// <param name="tag"></param>
    void YellowWire(string tag)
    {
        anim.SetBool("YellowLight", true);
        anim.SetBool("GreenLight", false);
        anim.SetBool("RedLight", false);
        anim.SetBool("BlueLight", false);
        string yellowTag = "03 A6 B3 0C";
        if (yellowTag == tag)
        {
            score = score + 5;
            currentWire = GetRandomWire();
        }

        
    }

    /// <summary>
    /// Sets the animation to the blue light. Checks if the user input is correct.
    /// </summary>
    /// <param name="tag"></param>
    void BlueWire(string tag)
    {
        anim.SetBool("BlueLight", true);
        anim.SetBool("RedLight", false);
        anim.SetBool("GreenLight", false);
        anim.SetBool("YellowLight", false);

        string blueTag = "93 0F 33 0B";
        if (blueTag == tag)
        {
            score = score + 5;
            currentWire = GetRandomWire();
        }
        
    }

}
