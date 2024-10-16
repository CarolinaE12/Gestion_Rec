using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string sceneName; // Campo para insertar el nombre de la escena en el inspector

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡Colisión detectada! Cambiando de escena...");
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está especificado.");
        }
    }
}
