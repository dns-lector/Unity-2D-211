using UnityEngine;

public class PigsCountScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI pigsCountTMP;

    void Start()
    {
        pigsCountTMP = GetComponent<TMPro.TextMeshProUGUI>();

        GameState.needRecalculatePigs = true;
    }

    void Update()
    {
        if(GameState.needRecalculatePigs)
        {
            int pigsCount = 
                GameObject
                .FindGameObjectsWithTag("Pig")
                .Length;

            pigsCountTMP.text = pigsCount.ToString();

            GameState.needRecalculatePigs = false;
            GameState.isLevelCompleted = pigsCount == 0;

            if (pigsCount == 0)
            {
                ModalScript.ShowModal("УСПІХ", "Рівень пройдено, знищено усіх ворогів");
            }
        }
    }
}
