using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject objectToShow;
    public GameObject objectToShow2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            objectToShow.SetActive(true);
            objectToShow2.SetActive(true);
        }
    }
}
