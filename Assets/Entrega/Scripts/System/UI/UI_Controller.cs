using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public List<GameObject> canvasWindows = new List<GameObject>();

    public void ActivateWindow(GameObject window)
    {
        foreach (GameObject var in canvasWindows) {
            if (var == window) var.SetActive(true);
            else var.SetActive(false);
        }
    }

    public void DeactivateAll()
    {
        foreach (GameObject var in canvasWindows)
        {
            var.SetActive(false);
        }
    }
}
