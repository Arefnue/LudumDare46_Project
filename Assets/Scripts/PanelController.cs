using UnityEngine;

namespace MenuScripts
{
    public class PanelController : MonoBehaviour
    {
        public void OpenPanel(GameObject panelObject)
        {
            panelObject.SetActive(true);
        }

        public void ClosePanel(GameObject panelObject)
        {
            panelObject.SetActive(false);
        }
    }
}
