using UnityEngine;

public class HexagonScript : MonoBehaviour
{
    private Rigidbody2D rb2d;   // посилання на об'єкт компонента

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);
        }
    }
}
/* Д.З. Наповнити композицію сцени проєкту
 * (розмістити різні спрайти, підібрати фон, тощо)
 */
