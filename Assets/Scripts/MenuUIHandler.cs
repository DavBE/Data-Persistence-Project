using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField PlayerNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        PlayerNameInputField.text = DataManager.Instance.LastPlayerName;
        BestScoreText.text = "Best Score : " + DataManager.Instance.BestPlayerName +
            " : " + DataManager.Instance.BestPlayerScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void StartNew()
    {
        DataManager.Instance.LastPlayerName = PlayerNameInputField.text;
        DataManager.Instance.SaveDataToFile();
        SceneManager.LoadScene(1);
    }
}
