using UnityEngine;
using System.Collections.Generic;

public class SkinController : MonoBehaviour
{
    public MainMenuController mainMenuController;

    public List<GameObject> Skins;

    private void Start()
    {
        for (int i = 0; i < Skins.Count; i++)
        {
            if (GameManager.instance.skinavailable[i]) Skins[i].SetActive(true); ;
        }
    }

    public void EquipSkin(string id)
    {
        GameManager.instance.ChangeSkin(id);
    }

    public void UnlockSkin(int id)
    {
        Skins[id].SetActive(true);
        GameManager.instance.skinavailable[id] = true;
    }
}
