using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class OpenScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void GoToRestaurant()
    {
        SceneManager.LoadScene(1);
    }
}
