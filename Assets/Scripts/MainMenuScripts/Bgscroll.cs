using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgScroll : MonoBehaviour
{

    private void Update()
    {
        transform.position += new Vector3(-10 * Time.deltaTime, 0);
        
    }
}
