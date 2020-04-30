using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Updates the score display in the UI.
/// </summary>
public class Score : MonoBehaviour
{
    private Text scoreText;
    private int scoreAmount;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = GameManager.score;
    }

    void Update()
    {
        scoreText.text = "SCORE: " + scoreAmount;
    }
}
