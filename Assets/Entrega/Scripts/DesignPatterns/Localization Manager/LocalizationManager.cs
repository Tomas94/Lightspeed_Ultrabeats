using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;
    public SystemLanguage language;
    public DataLocalization[] data;
    Dictionary<SystemLanguage, Dictionary<string, string>> _translate = new Dictionary<SystemLanguage, Dictionary<string, string>>();

    public event Action EventTranslate;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            _translate = LanguageU.LoadTranslate(data);
        }
        else Destroy(this);
        DontDestroyOnLoad(this);
    }

    public void ChangeLang(SystemLanguage newLang)
    {
        if (language != newLang)
        {
            language = newLang;
            EventTranslate?.Invoke();
        }
    }

    public void ChangeLang()
    {
        var currentLangIndex = -1;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].language == language)
            {
                currentLangIndex = i;
                break;
            }
        }

        if (currentLangIndex != -1)
        {
            if (currentLangIndex == data.Length - 1) language = data[0].language;
            else language = data[currentLangIndex + 1].language;

            EventTranslate?.Invoke();
        }
    }

    public string GetTranslate(string id)
    {
        if (!_translate.ContainsKey(language))
            return "No lang";

        if (!_translate[language].ContainsKey(id))
            return "No ID";

        return _translate[language][id];
    }
}
