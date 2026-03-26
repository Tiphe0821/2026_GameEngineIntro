using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject helpPannel;
    public void StartButton()
    {
        Debug.Log("StartButton Clicked");
        SceneManager.LoadScene("PlayScene_Door1");
    }

    public void OpenHelp()
    {
        helpPannel.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPannel.SetActive(false);
    }

    public void OpenTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
