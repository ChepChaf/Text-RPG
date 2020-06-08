using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Text m_text = null;

    private void OnEnable()
    {
        DialogLog.newDialogEvent += UpdateText;
    }

    private void OnDisable()
    {
        DialogLog.newDialogEvent -= UpdateText;
    }

    void UpdateText(DialogLog dialogLog)
    {
        m_text.text = "";

        foreach(string dialog in dialogLog.Dialogs)
        {
            m_text.text += dialog + "\n";
        }
    }
}
