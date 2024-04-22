using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private TMP_Text _textMessage;

    public float GetChatBoxHeight()
    {
        return _background.sizeDelta.y;
    }

    public void SetMessage(string message)
    {
        _textMessage.text = message;
        Canvas.ForceUpdateCanvases();
        Vector2 backgroundSize = _background.sizeDelta;
        _background.sizeDelta = new Vector2(backgroundSize.x, _textMessage.rectTransform.rect.height + 100);
    }
}
