using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationHandler : MonoBehaviour
{
    public GameObject notificationPanel;

    public TMP_Text notificationText;
    public Image notificationImage;

    private IEnumerator HideNotification()
    {
        yield return new WaitForSeconds(3f); // Yield the code to allow for reading time

        notificationPanel.SetActive(false); // Hide panel
    }

    public void CreateNotification(string notificationMessage, Sprite notificationSprite)
    {
        // Change notification details
        notificationText.text = notificationMessage;
        notificationImage.sprite = notificationSprite;
        notificationPanel.SetActive(true); // Show panel

        StartCoroutine(HideNotification());
    }

}
