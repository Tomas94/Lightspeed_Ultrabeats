using UnityEngine;

public class ChangeLangButton : MonoBehaviour
{
   public void ChangeCurrentLanguage()
    {
        LocalizationManager.instance.ChangeLang();
    }
}
