using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardButtonHandler : MonoBehaviour
{
    public Button LeaderboardButton;

    void Start()
    {
        Button btn = LeaderboardButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("LeaderboardMenu");
    }
}