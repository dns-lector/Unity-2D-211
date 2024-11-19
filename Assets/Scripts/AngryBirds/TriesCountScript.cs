using UnityEngine;

public class TriesCountScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI triesCountTMP;

    void Start()
    {
        triesCountTMP = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        if (triesCountTMP.text != GameState.triesCount.ToString())
        {
            triesCountTMP.text = GameState.triesCount.ToString();
        }
    }
}
