using System.Collections.Generic;
using UnityEngine;

public class UI_Windows_Controller : MonoBehaviour
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
