using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image Image;
    [SerializeField] private Sprite Default, Pressed;
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip CompressClip, UncompressClip;

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
