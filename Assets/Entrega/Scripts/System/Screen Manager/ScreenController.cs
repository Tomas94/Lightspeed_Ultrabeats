using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour, IScreen
{
    //public ScreenController nextScreen;
    
    public void BTN_Active(ScreenController _nextScreen)
    {
        ScreenManager.instance._screens.Push((this));
        if(_nextScreen != null)    
        ScreenManager.instance.ActiveScreen(_nextScreen);
    }

    public void BTN_Close()
    {
        ScreenManager.instance.DesactiveScreen();

    }


    public void Activate()
    {
        gameObject.SetActive(true);

        foreach(var item in GetComponentsInChildren<Button>())
            item.interactable = true;
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        foreach(var item in GetComponentsInChildren<Button>())
            item.interactable = false;
    }
}
