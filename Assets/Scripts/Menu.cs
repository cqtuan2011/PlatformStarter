using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI text;

    private void Start()
    {
        panel.enabled = false;
        text.enabled = false;
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnClickTutorial()
    {
        if (panel.enabled == false)
        {
            panel.enabled = true;
            text.enabled = true;
        } else
        {
            panel.enabled = false;
            text.enabled = false;
        }
    }
}
