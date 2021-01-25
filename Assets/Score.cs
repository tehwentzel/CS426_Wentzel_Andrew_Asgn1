using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int maxScore = 5;
    public int maxFails = 2;
    int score;
    int fails;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        fails = 0;
        scoreText.text = "Score: " + score;
    }

    //we will call this method from our target script
    // whenever the player collides or shoots a target a point will be added
    public void AddPoint()
    {
        score++;

        if ( (score+fails) != maxScore)
            scoreText.text = "Score: " + score;
        else
            scoreText.text = "You won!";
    }
    public void RemovePoint()
    {
        if (score > 0){
            score = score - 1;
            scoreText.text = "Score: " + score;
        }
        fails++;
        if (fails > maxFails){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
