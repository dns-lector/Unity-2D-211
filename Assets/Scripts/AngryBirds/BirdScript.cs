using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;

    private Rigidbody2D rb2d;
    private ForceScript forceScript;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float shotTimeout = 7.0f;
    private float shotTime;
    private bool isShot;

    void Start()
    {
        GameState.triesCount = 2;
        shotTime = 0.0f;
        isShot = false;
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = 
            GameObject
            .Find("ForceCanvasIndicator")
            .GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isShot)
        {
            float forceFactor = 1000.0f;
            if (forceScript != null)
            {
                forceFactor *=  (forceScript.forceFactor + 0.5f);
            }
            else
            {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
            isShot = true;
            shotTime = shotTimeout;
        }
        if (isShot)
        {
            shotTime -= Time.deltaTime;
            if( shotTime <= 0.0f)
            {
                GameState.triesCount -= 1;
                if (GameState.triesCount <= 0)
                {
                    GameState.triesCount = 0;
                    GameState.isLevelFailed = true;
                    ModalScript.ShowModal("ПРОГРАШ", "Вичерпано кількість спроб");
                }
                else
                {
                    isShot = false;
                    // Start Position
                    this.transform.position = startPosition;
                    this.transform.rotation = startRotation;
                    // Stop
                    rb2d.linearVelocity = Vector2.zero;
                    rb2d.angularVelocity = 0.0f;
                }                
            }
        }
    }
}
/* Д.З. Створити додаткову сцену
 * Використати іншого персонажа (жовтий)
 * Розмістити стартову позицію в іншому місці
 * Підібрати та встановити обмеження для напряму початкового руху (Стрілки)
 */
