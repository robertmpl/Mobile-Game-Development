using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button playLevelOneButton;

    void PlayButtonClicked()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    void BackButtonClicked()
    {
        levelSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    void PlayLevelOneButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        backButton.onClick.AddListener(BackButtonClicked);
        playLevelOneButton.onClick.AddListener(PlayLevelOneButtonClicked);
    }
}
