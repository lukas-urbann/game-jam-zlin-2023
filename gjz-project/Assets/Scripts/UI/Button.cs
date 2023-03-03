using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public abstract class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("- Button Color -")] private Color normal, hover, pressed;
        public TMP_Text _text;

        private void Start()
        {
            if (_text == null)
            {
                ErrorReporter.ReportError(gameObject, "Nedosazený text", this, "Nebyl dosazen TMP_Text komponent");
                return;
            }
            
            normal = new Color(1,1,1,1);
            hover = new Color(1,0,1,1);
            pressed = new Color(1,0,0,1);
            
            SetButtonTextColor();
        }

        private void SetButtonTextColor()
        {
            _text.color = normal;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _text.color = hover;
            Manager.Audio.Instance.PlayButtonHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _text.color = normal;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _text.color = pressed;
            Manager.Audio.Instance.PlayButtonClick();
        }

        //Tu se narve funkce v každých jednotlivých buttonech, ať nemusíme tvořit milion skriptů.
        //Při kliknutí pak můžeme volat jen tu jednu funkci a nebude v tom bordel.
        public abstract void ButtonAction();
    }
}