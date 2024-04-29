using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void ResetVR()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
