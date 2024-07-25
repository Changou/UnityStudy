
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //-------------------------
    public void OnLoadScene(string name)
    { SceneManager.LoadScene(name); }
}
