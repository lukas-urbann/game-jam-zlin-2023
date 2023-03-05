using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    /// <summary>
    /// Hlavní třída čudlíku. Slouží jako základ pro všechna tlačítka na scénách.
    /// </summary>
    public abstract class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        //Nastavení barev
        [Header("- Button Color -")] private Color normal, hover, pressed;
        public TMP_Text _text; //Textový objekt

        private void Start()
        {
            //Kontrola, aby nenastala chyba, kdyžtak vyhodíme vlastní
            if (_text == null)
            {
                ErrorReporter.ReportError(gameObject, "Nedosazený text", this, "Nebyl dosazen TMP_Text komponent");
                return;
            }
            
            //Hardcodnuté barvy
            normal = new Color(1,1,1,1);
            hover = new Color(1,1,0.6f,1);
            pressed = new Color(1,0,0,1);
            
            //Nastaví defaultní barvu
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
            //Efekt pro čudlík
            _text.color = pressed;
            Manager.Audio.Instance.PlayButtonClick();
            _text.color = normal; //Musí se vyresetovat barva
        }

        //Tu se narve funkce v každých jednotlivých buttonech, ať nemusíme tvořit milion skriptů.
        //Při kliknutí pak můžeme volat jen tu jednu funkci a nebude v tom bordel.
        public abstract void ButtonAction();
    }
}