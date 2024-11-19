using UnityEngine;

public class ClockScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI clock;
    private float gameTime;


    void Start()
    {
        clock = GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0.0f;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        clock.text = gameTime.ToString("F1");
    }
}
/* Д.З. Зробити композицію сцени (з попереднього ДЗ)
 * Додати елементи управління силою поштовху,
 * налаштувати під особливості персонажа.
 */
