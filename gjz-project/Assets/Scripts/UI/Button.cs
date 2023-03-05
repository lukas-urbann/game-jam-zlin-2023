using Manager;
using Miscellaneous;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI
{
    /// <summary>
    /// Hlavní třída čudlíku. Slouží jako základ pro všechna tlačítka na scénách.
    /// </summary>
    public abstract class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        //Nastavení barev
        [Header("- Button Color -")] private Color _normal, _hover, _pressed;
        [FormerlySerializedAs("_text")] public TMP_Text text; //Textový objekt

        private void Start()
        {
            //Kontrola, aby nenastala chyba, kdyžtak vyhodíme vlastní
            if (text == null)
            {
                ErrorReporter.ReportError(gameObject, "Nedosazený text", this, "Nebyl dosazen TMP_Text komponent");
                return;
            }
            
            _normal = new Color(1,1,1,1);
            _hover = new Color(1,0,1,1);
            _pressed = new Color(1,0,0,1);
            
            //Nastaví defaultní barvu
            SetButtonTextColor();
        }

        private void SetButtonTextColor()
        {
            text.color = _normal;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            text.color = _hover;
            Audio.Instance.PlayButtonHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            text.color = _normal;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            text.color = _pressed;
            Audio.Instance.PlayButtonClick();
            text.color = _normal;
        }

        //Tu se narve funkce v každých jednotlivých buttonech, ať nemusíme tvořit milion skriptů.
        //Při kliknutí pak můžeme volat jen tu jednu funkci a nebude v tom bordel.
        public abstract void ButtonAction();
    }
}