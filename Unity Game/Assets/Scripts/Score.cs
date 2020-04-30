using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Updates the score display in the UI.
/// </summary>
public class Score : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "SCORE: " + GameManager.score;
    }
}
