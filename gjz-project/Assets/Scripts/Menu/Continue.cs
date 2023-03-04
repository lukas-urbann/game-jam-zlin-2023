using UI;

namespace Menu
{
    public class Continue : Button
    {
        public override void ButtonAction()
        {
            Pause.Instance.SwitchPauseState();
        }
    }
}
