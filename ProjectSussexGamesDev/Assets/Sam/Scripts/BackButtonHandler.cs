using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    public Button BackButton;

    void Start()
    {
        Button btn = BackButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Back");
    }
}
