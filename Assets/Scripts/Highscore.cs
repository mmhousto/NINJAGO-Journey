using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI hiscoreText1, hiscoreText2, hiscoreText3, hiscoreText4, hiscoreText5;

    public TextMeshProUGUI titleText;

    private int hiScore1, hiScore2, hiScore3, hiScore4, hiScore5;
    private int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("Score", 0);

        hiScore1 = PlayerPrefs.GetInt("Highscore", 0);
        hiscoreText1.text = "Highscore #1: " + hiScore1.ToString();
        hiScore2 = PlayerPrefs.GetInt("Highscore2", 0);
        hiscoreText2.text = "Highscore #2: " + hiScore2.ToString();
        hiScore3 = PlayerPrefs.GetInt("Highscore3", 0);
        hiscoreText3.text = "Highscore #3: " + hiScore3.ToString();
        hiScore4 = PlayerPrefs.GetInt("Highscore4", 0);
        hiscoreText4.text = "Highscore #4: " + hiScore4.ToString();
        hiScore5 = PlayerPrefs.GetInt("Highscore5", 0);
        hiscoreText5.text = "Highscore #5: " + hiScore5.ToString();

        Debug.Log(playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore >= hiScore1)
            titleText.text = "NEW TOP HIGHSCORE!";
        else if(playerScore >= hiScore2 || playerScore >= hiScore3 || playerScore >= hiScore4 || playerScore >= hiScore5)
            titleText.text = "NEW HIGHSCORE!";
    }
}
