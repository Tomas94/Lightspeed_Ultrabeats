using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }

    AndroidNotificationChannel notifChannel;

    private void Awake()
    {
        if (Instance != this && Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
      //  AndroidNotificationCenter.CancelAllScheduledNotifications();
      //  AndroidNotificationCenter.CancelAllDisplayedNotifications();

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Reminder to play",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);
    //}

    //public int DisplayNotification(string title, string text, IconSelector small, IconSelector big, DateTime fireTime )
    //{
        var notification = new AndroidNotification();
        notification.Title = "Bienvenido a LighSpeed UltraBeats";
        notification.Text = "Esperamos que pases un buen rato <3";
        notification.SmallIcon = "icon_reminder";
        notification.LargeIcon = "icon_reminderbig";

        notification.FireTime = System.DateTime.Now.AddSeconds(15);

         AndroidNotificationCenter.SendNotification(notification, "reminder_notif_ch");
    }

    //public void CancelNotification(int id)
    //{
    //    AndroidNotificationCenter.CancelScheduledNotification(id);
    //}

    //private void OnApplicationQuit()
    //{
    //    DisplayNotification("Te extrañamos T-T", "No te olvides de jugar de vez en cuando <3", IconSelector.icon_reminder, IconSelector.icon_reminderbig, DateTime.Now.AddSeconds(10));
    //}
}

public enum IconSelector
{
    icon_reminder,
    icon_reminderbig
}
