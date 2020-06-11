using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    Text m_text = null;

    private void OnEnable()
    {
        Conversation.newMessageEvent += UpdateText;
    }

    private void OnDisable()
    {
        Conversation.newMessageEvent -= UpdateText;
    }

    void UpdateText(Dialog dialog)
    {
        Debug.Log("UI Dialog: " + dialog);
        m_text.text += dialog.content + "\n";
    }
}
