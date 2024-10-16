using UnityEngine;
using TMPro; // Para TextMeshPro
using System.Collections; // Para IEnumerator
using UnityEngine.Networking; // Para UnityWebRequest

public class PointsManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Cambia a TextMeshProUGUI
    private int points;

    void Start()
    {
        points = 0;
        UpdatePointsText();
    }

    public void AddPoints(int value)
    {
        points += value;
        UpdatePointsText();
        //StartCoroutine(SendPointsToAPI()); // Puedes comentar esto si solo quieres enviar al final
    }

    void UpdatePointsText()
    {
        pointsText.text = "Puntos: " + points.ToString();
    }

    public void SendPointsToAPI()
    {
        StartCoroutine(SendPointsToAPIRequest());
    }

    IEnumerator SendPointsToAPIRequest()
    {
        // Suponiendo que tienes una URL de la API para enviar los puntos
        string url = "http://appsystemrewards.somee.com/swagger/index.html";
        WWWForm form = new WWWForm();
        form.AddField("points", points);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error enviando puntos: " + www.error);
            }
            else
            {
                Debug.Log("Puntos enviados correctamente");
            }
        }
    }
}





