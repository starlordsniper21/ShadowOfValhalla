using UnityEngine;

public class ArmorBarManager : MonoBehaviour
{
    public static ArmorBarManager instance;
    private ArmorBar[] armorBars;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        armorBars = FindObjectsOfType<ArmorBar>();
    }

    public void DisableAllArmorBars()
    {
        foreach (ArmorBar armorBar in armorBars)
        {
            armorBar.gameObject.SetActive(false);
        }
    }

    public void EnableAllArmorBars()
    {
        foreach (ArmorBar armorBar in armorBars)
        {
            armorBar.gameObject.SetActive(true);
        }
    }
}
