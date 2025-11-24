using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Main");
    }
}
