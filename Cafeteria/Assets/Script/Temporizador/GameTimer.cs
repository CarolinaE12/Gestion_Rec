using UnityEngine;
using TMPro;


/*public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Duraci�n del temporizador en segundos
    public TextMeshProUGUI timerText;
    public PointsManager pointsManager; // Referencia al PointsManager para enviar los puntos al terminar
    private bool isTimerRunning = true;
    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            timerText.text = "Tiempo: " + Mathf.Round(totalTime).ToString();
        }
        else
        {
            timerText.text = "�Se acab� el tiempo!";
            pointsManager.SendPointsToAPI(); // Env�a los puntos a la API al finalizar el tiempo
        }
    }
    public void StopTimer()
    {
        Debug.Log("StopTimer llamado.");
        isTimerRunning = false;
        totalTime = 0; // Asegura que el tiempo se detenga completamente
        timerText.text = "Temporizador detenido.";
        Debug.Log("Temporizador detenido.");
        if (pointsManager != null)
        {
            pointsManager.SendPointsToAPI(); // Env�a los puntos a la API si se detiene antes de tiempo
            Debug.Log("Puntos enviados a la API.");
        }
        else
        {
            Debug.LogWarning("PointsManager no est� asignado.");
        }
    }
}*/
public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Duraci�n del temporizador en segundos
    public TextMeshProUGUI timerText;
    public PointsManager pointsManager; // Referencia al PointsManager para enviar los puntos al terminar
    private bool isTimerRunning = true;// Variable para controlar el estado del temporizador
    void Update()
    {
        if (isTimerRunning && totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            timerText.text = "Tiempo: " + Mathf.Round(totalTime).ToString();
        }
        else if (totalTime <= 0 && isTimerRunning)
        {
            timerText.text = "Time is over";
            pointsManager.SendPointsToAPI();//Envia los puntos a la API
            isTimerRunning = false;
        }
    }
    public void StopTimer()
    {
        Debug.Log("StopTimer llamado.");
        isTimerRunning = false;//Detiene el Temporizador
        totalTime = 0; // Asegura que el tiempo se detenga completamente
        timerText.text = "Temporizador detenido.";
        Debug.Log("Temporizador detenido.");
        if (pointsManager != null)
        {
            pointsManager.SendPointsToAPI(); // Env�a los puntos a la API si se detiene antes de tiempo
            Debug.Log("Puntos enviados a la API.");
        }
        else
        {
            Debug.LogWarning("PointsManager no est� asignado.");
        }
    }
}
/*
public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Duraci�n del temporizador en segundos
    public TextMeshProUGUI timerText;
    public PointsManager pointsManager; // Referencia al PointsManager para enviar los puntos al terminar
    private bool isTimerRunning = true;

    void Update()
    {
        if (isTimerRunning && totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            timerText.text = "Tiempo: " + Mathf.Round(totalTime).ToString();
            //Debug.Log("Tiempo actual: " + totalTime);
        }
        else if (totalTime <= 0 && isTimerRunning)
        {
            timerText.text = "�Se acab� el tiempo!";
            Debug.Log("�Se acab� el tiempo!");
            pointsManager.SendPointsToAPI(); // Env�a los puntos a la API al finalizar el tiempo
            isTimerRunning = false;
        }
    }

    public void StopTimer()
    {
        Debug.Log("StopTimer llamado.");
        isTimerRunning = false;
        totalTime = 0; // Asegura que el tiempo se detenga completamente
        timerText.text = "Temporizador detenido.";
        Debug.Log("Temporizador detenido.");
        if (pointsManager != null)
        {
            pointsManager.SendPointsToAPI(); // Env�a los puntos a la API si se detiene antes de tiempo
            Debug.Log("Puntos enviados a la API.");
        }
        else
        {
            Debug.LogWarning("PointsManager no est� asignado.");
        }
    }

}
*/

