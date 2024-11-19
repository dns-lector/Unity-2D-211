using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;

    private static ModalScript instance;
    private string titleDefault;
    private string messageDefault;

    void Start()
    {
        instance = this;
        titleDefault = titleTMP.text;
        messageDefault = messageTMP.text;
        // Debug.Log("ModalScript::Start " + content.activeInHierarchy);
        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (content.activeInHierarchy) 
            {
                content.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                _Show();
            }
        }
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
        if (GameState.isLevelFailed)
        {
            SceneManager.LoadScene(GameState.levelIndex);
        }
        else if(GameState.isLevelCompleted)
        {
            GameState.levelIndex += 1;
            if (GameState.levelIndex >= SceneManager.sceneCountInBuildSettings)
            {
                GameState.levelIndex = 0;
            }
            SceneManager.LoadScene(GameState.levelIndex);
        }
    }
    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    private void _Show(string title = null, string message = null)
    {
        Time.timeScale = 0.0f;
        this.content.SetActive(true);

        if (title != null) titleTMP.text = title;
        else titleTMP.text = titleDefault;

        if (message != null) messageTMP.text = message;
        else messageTMP.text = messageDefault;
    }
    public static void ShowModal(string title = null, string message = null)
    {
        instance._Show(title,message);
    }
}
/* Д.З. Завершити проєкт 2D
 * - реалізувати щонайменше 3 сцени
 * - забезпечити відмінність між сценами у 
 *  = кількості спроб
 *  = часу тривалості спроби (timeout)
 * - змінювати надпис кнопки "Продовжити" у залежності від її функції
 *    ("Наново", "Повторити")
 */