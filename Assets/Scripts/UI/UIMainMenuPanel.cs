using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class UIMainMenuPanel : UIMainPanel
    {        
        protected override void OnPlayClicked()
        {
            base.OnPlayClicked();
            SceneManager.LoadScene(1);
        }
    }
}

