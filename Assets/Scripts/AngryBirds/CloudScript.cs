using UnityEngine;

public class CloudScript : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector2.left * 
            // 0.01f -- �� ��������� �� �����
            Time.deltaTime);

        if(this.transform.position.x < -10f)
        {
            this.transform.position = 
                new Vector3(10f, this.transform.position.y);
        }
    }
}
