using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public Stack<IScreen> _screens = new Stack<IScreen>();

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
    }

    void Update() { if (Input.GetKeyDown(KeyCode.Escape)) DesactiveScreen(); }

    public void ActiveScreen(IScreen screen)
    {
        screen.Activate();

        if (_screens.Count > 0)
            _screens.Peek().Desactivate();

        _screens.Push(screen);
    }

    public void DesactiveScreen()
    {
        if (_screens.Count > 0)
        {
            _screens.Pop().Desactivate();

            if (_screens.Count > 0)
                _screens.Peek().Activate();
        }
    }

    public void CloseWindow(GameObject window) => window.SetActive(false);
}
