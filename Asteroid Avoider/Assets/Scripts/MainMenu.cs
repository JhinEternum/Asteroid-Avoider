using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public const string MenuScene = "Scene_Menu";

    public const string GameScene = "Scene_Main";

    [SerializeField] private TMP_InputField nameInput;

    [SerializeField] private float fadeOutTime;

    [SerializeField] private TMP_Text warningText;
    
    [SerializeField] private PersistentData persistentData;

    private bool isInvalid;

    private float currentTime;

    private void Start()
    {
        warningText.text = "";
    }

    private void Update()
    {
        if (!isInvalid) return;

        warningText.text = "Nome inválido ou já existente!";

        currentTime += Time.deltaTime;

        if (currentTime >= fadeOutTime)
        {
            currentTime = 0;
            warningText.text = "";
            isInvalid = false;
        }
    }
    
    public void StartGame()
    {
        if (nameInput.text.Length == 0 || PlayerPrefs.HasKey(""))
        {
            isInvalid = true;
            return;
        }
        persistentData.currentName = nameInput.text;
        SceneManager.LoadScene(GameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
