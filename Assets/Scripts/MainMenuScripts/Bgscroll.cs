using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgScroll : MonoBehaviour
{

    private void Update()
    {
        transform.position += new Vector3(-50 * Time.deltaTime, 0);
        
    }
}
