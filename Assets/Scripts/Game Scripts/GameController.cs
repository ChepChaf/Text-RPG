using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Conversation m_currentConversation = null;
    DialogLog m_dialogLog = null;

    [SerializeField]
    InputField m_textInput = null;
    // Start is called before the first frame update

    [SerializeField]
    Entity m_playerEntity = null;

    [SerializeField]
    Entity m_gameMasterEntity = null;

    void Start()
    {
        m_dialogLog = new DialogLog();

        m_currentConversation = new Conversation();
        m_currentConversation.AddParticipant(m_gameMasterEntity);
        m_currentConversation.AddParticipant(m_playerEntity);
    }

    private void OnEnable()
    {
        Conversation.newMessageEvent += NewDialog;
    }

    private void OnDisable()
    {
        Conversation.newMessageEvent -= NewDialog;
    }

    void NewDialog(Dialog message)
    {
        m_dialogLog.AddDialog(message);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (m_textInput.text.Length > 0)
            {
                Dialog playerDialog = ScriptableObject.CreateInstance<Dialog>();
                playerDialog.content = m_textInput.text;

                NewDialog(playerDialog);
                m_currentConversation.TransmitMessage(m_playerEntity, m_textInput.text);
                m_textInput.text = "";
            }
        }
    }
}
