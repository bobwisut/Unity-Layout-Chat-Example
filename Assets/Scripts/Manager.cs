using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum EChatBoxType
{
    Sent,
    Received
}

public class Manager : MonoBehaviour
{
    [SerializeField] private ScrollRect _chatScroll;
    [SerializeField] private RectTransform _chatContent;
    [SerializeField] private ChatBox _sentChat;
    [SerializeField] private ChatBox _receivedChat;

    [SerializeField] private TMP_InputField _inputMessage;
    [SerializeField] private Button _receivedButton;
    [SerializeField] private Button _sentButton;

    private void Start()
    {
        SetCallback();
    }

    private void SetCallback()
    {
        _receivedButton.onClick.AddListener(() =>
        {
            GenerateMessageBox(EChatBoxType.Received);
        });
        _sentButton.onClick.AddListener(() =>
        {
            GenerateMessageBox(EChatBoxType.Sent);
        });
    }

    private void GenerateMessageBox(EChatBoxType chatBoxType)
    {
        // Get ChatBox from enum type
        ChatBox chatBox = GetChatBoxFromType(chatBoxType);

        // Create new ChatBox
        ChatBox newChatBox = Instantiate(chatBox);
        newChatBox.transform.SetParent(_chatContent, false);
        newChatBox.SetMessage(_inputMessage.text);

        // Update size to new ChatBox
        Vector2 newChatBoxSize = newChatBox.GetComponent<RectTransform>().sizeDelta;
        float newChatBoxHeight = newChatBox.GetChatBoxHeight() + 150;
        newChatBox.GetComponent<RectTransform>().sizeDelta = new Vector2(newChatBoxSize.x, newChatBoxHeight);

        // Update height to Chat Content
        Vector2 contentSize = _chatContent.sizeDelta;
        float newHeightContent = contentSize.y + newChatBoxHeight;
        _chatContent.sizeDelta = new Vector2(contentSize.x, newHeightContent);

        // Scroll to Bottom
        _chatScroll.verticalNormalizedPosition = 0;
    }

    private ChatBox GetChatBoxFromType(EChatBoxType chatBoxType)
    {
        switch (chatBoxType)
        {
            case EChatBoxType.Sent:
                return _sentChat;
            case EChatBoxType.Received:
                return _receivedChat;
        }
        return null;
    }
}
