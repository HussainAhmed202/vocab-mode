using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void MoveToScene(int sceneID){
        SceneManager.LoadScene(sceneID);

    }


}
