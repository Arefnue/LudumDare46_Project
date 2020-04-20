using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScripts
{
   public class ChangeScene : MonoBehaviour
   {
      public string changeToSceneName;

      public void ChangeByPublicValue()
      {
         SceneManager.LoadScene(changeToSceneName);
      }

      public void ChangeByFunction(string sceneName)
      {
         SceneManager.LoadScene(sceneName);
      }
   
   
   }
}
