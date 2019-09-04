using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
	public Text gameOverText;
	public Text goodJobText;
    public Text nbCoinLeftText;
    public Text timeText;
    public Text gradeText;
    public Text gradeOn20Text;

    Dictionary<string, int> achievements = new Dictionary<string, int>();
    public int coins;
    float time;

    public GameObject achievementPanel;
    public GameObject achievementTxtPrefab;

    int nbTotalCoinAtStart;
    // Use this for initialization
	void Start ()
    {
        gameOverText.enabled = false;
        initAchievements();
        nbTotalCoinAtStart = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void initAchievements()
    {
        achievements.Add("9 - Last more than 1 minutes 1pt", 0);
        achievements.Add("8 - Do not just rely on FindObjectWithTag 1pt", 0);
        achievements.Add("7 - Successfuly Dig Up Healthpack 1pt", 0);        
        achievements.Add("6 - Target One Digging Area 1pt", 0);
        achievements.Add("5 - Target One Shovel 1pt", 0);
        achievements.Add("4 - Target One Healthpack 1pt", 0);
        achievements.Add("3 - Target One Coin 1pt", 0);
        achievements.Add("2 - Make the character move 1pt", 0);
        achievements.Add("1 - Collect coin 12pt for all of them", 0);
        
        int i = 0;
        float xPos = 175.15f;
        float yPos = -15f;
        float height = 30f;
        
        foreach (KeyValuePair<string, int> node in achievements)
        {
            GameObject newLabel = GameObject.Instantiate(achievementTxtPrefab, new Vector3(xPos, yPos + height * i, 0), Quaternion.identity , achievementPanel.transform);
            newLabel.GetComponent<RectTransform>().localPosition = new Vector3(0, yPos + height * i++, 0);
            newLabel.name = node.Key;
            newLabel.transform.Find("TextAchievement").GetComponent<Text>().text = node.Key;
            newLabel.transform.Find("TextAchievementScore").GetComponent<Text>().text = node.Value.ToString();                        
        }
    }

    // Update is called once per frame
    void Update ()
    {
		nbCoinLeftText.text = GameObject.FindGameObjectsWithTag ("Coin").Length.ToString();
        if (GameObject.FindGameObjectsWithTag("Coin").Length <= 0)
            SetGameOver(true);

        int minute = (int)(Time.time / 60.0f);
        int seconde = (int)(Time.time % 60.0f);

        timeText.text = minute.ToString() + ":" + seconde.ToString();

        if(Time.time > 60.0f)
            SetAchievementScore("9 - Last more than 1 minutes 1pt", 1);                

        int totalScore = 0;
        foreach (KeyValuePair<string, int> node in achievements)
        {        
            achievementPanel.transform.Find(node.Key).transform.Find("TextAchievementScore").GetComponent<Text>().text = node.Value.ToString();
            totalScore += node.Value;
        }

        gradeText.text = ((totalScore / 20.0f) * 100).ToString();
        gradeOn20Text.text = totalScore.ToString();
    }

    public void SetGameOver(bool winning = false)
    {
        if(winning)
            goodJobText.enabled = true;
        else
            gameOverText.enabled = true;

        Time.timeScale = 0;
    }

    public void AddCoin()
    {
        coins += 1;

        int score = (int)(((float)coins / (float)nbTotalCoinAtStart) * 12);

        SetAchievementScore("1 - Collect coin 12pt for all of them", score);
    }

    public void SetAchievementScore(string achievementName, int score)
    {
        achievements[achievementName] = score;
    }
}
