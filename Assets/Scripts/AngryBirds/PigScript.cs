using UnityEngine;

public class PigScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PigDestroy"))
        {
            // ModalScript.ShowModal("ЗНИЩЕНО", "-1 супротивник");
            GameObject.Destroy(this.gameObject);
            GameState.needRecalculatePigs = true;
        }
    }
}
