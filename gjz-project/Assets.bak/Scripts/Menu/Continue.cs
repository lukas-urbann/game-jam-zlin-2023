using UI;

namespace Menu
{
    public class Continue : Button
    {
        /// <summary>
        /// Tlačítko znovu spustí hru z menu.
        /// </summary>
        public override void ButtonAction()
        {
            Pause.Instance.SwitchPauseState();
        }
    }
}
