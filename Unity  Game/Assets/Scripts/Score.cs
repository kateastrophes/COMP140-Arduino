using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Updates the score display in the UI.
/// </summary>
public class Score : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    void Update()
    {
        scoreText.text = "SCORE: " + scoreAmount;
    }
}
