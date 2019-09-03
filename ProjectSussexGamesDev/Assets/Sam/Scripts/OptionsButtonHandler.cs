using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsButtonHandler : MonoBehaviour
{
    public Button OptionsButton;

    void Start()
    {
        Button btn = OptionsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
