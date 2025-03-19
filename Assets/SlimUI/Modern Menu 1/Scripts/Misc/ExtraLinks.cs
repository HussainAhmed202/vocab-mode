using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement namespace

namespace SlimUI.ModernMenu {
    public class ExtraLinks : MonoBehaviour {
        public void Restaurant() {
            SceneManager.LoadScene(1); // Loads the scene at index 1 in Build Settings
        }

        public void School() {
            SceneManager.LoadScene(2); // Loads the scene at index 2
        }

        public void House() {
            SceneManager.LoadScene(3); // Loads the scene at index 3
        }

        public void Essence() {
            SceneManager.LoadScene(4); // Loads the scene at index 4
        }
    }
}

// using UnityEngine;

// namespace SlimUI.ModernMenu{
//     public class ExtraLinks : MonoBehaviour{
//         public void CCP(){
//             Application.OpenURL("http://u3d.as/1JZG");
//         }

//         public void SciFi(){
//             Application.OpenURL("http://u3d.as/1AaR");
//         }

//         public void Clean1(){
//             Application.OpenURL("http://u3d.as/1hTi");
//         }

//         public void Essence(){
//             Application.OpenURL("http://u3d.as/1t11");
//         }
//     }
// }
