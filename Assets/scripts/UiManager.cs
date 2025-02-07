using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;
using Unity.VisualScripting;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance {get; private set;}

    public TextMeshProUGUI Player1ScoreText;
    public TextMeshProUGUI Player2ScoreText;

    private void Awake()
    {
        //Ensure that there is only one instance of gameManager
        if (Instance == null)
        {
            Instance = this;
            //Intermediate Unity tip and trick 
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateScore(Player player, int score)
    {

        if (player == Player.Player1)
        {
            Player1ScoreText.text = score.ToString();
        }
        else if (player == Player.Player2)
        {
            Player2ScoreText.text = score.ToString();
        }
    }

    public void DisplayWinMessage(Player player)
    {

        if (player == Player.Player1)
        {
            Player1ScoreText.text = "Player 1 Wins!";
            Player2ScoreText.text = "You Lose!";
        }
        else if (player == Player.Player2)
        {
            Player2ScoreText.text = "Player 2 Wins!";
            Player1ScoreText.text = "You Lose!";
        }
    }
}
