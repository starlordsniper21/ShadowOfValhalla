using UnityEngine;

public class ArmorBarManager : MonoBehaviour
{
    public static ArmorBarManager instance;
    private GameObject[] armorBars;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        armorBars = GameObject.FindGameObjectsWithTag("ArmorBar");
    }

    public void DisableAllArmorBars()
    {
        foreach (GameObject armorBar in armorBars)
        {
            armorBar.SetActive(false);
        }
    }

    public void EnableAllArmorBars()
    {
        foreach (GameObject armorBar in armorBars)
        {
            armorBar.SetActive(true);
        }
    }
}
