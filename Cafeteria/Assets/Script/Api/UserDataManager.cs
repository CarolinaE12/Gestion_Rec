using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Networking;

public class UserDataManager : MonoBehaviour
{
    public TMP_Dropdown companyDropdown;
    public TMP_InputField nameInputField;
    public TMP_InputField areaInputField;
    public Button submitButton;
    public TextMeshProUGUI resultText;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    private void OnSubmit()
    {
        string companyName = companyDropdown.options[companyDropdown.value].text;
        string userName = nameInputField.text;
        string userArea = areaInputField.text;

        StartCoroutine(SendUserDataToAPI(companyName, userName, userArea));
    }

    private IEnumerator SendUserDataToAPI(string company, string name, string area)
    {
        string url = "http://appsystemrewards.somee.com/swagger/index.html";

        WWWForm form = new WWWForm();
        form.AddField("company", company);
        form.AddField("name", name);
        form.AddField("area", area);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                resultText.text = "Error enviando datos: " + www.error;
                Debug.LogError("Error enviando datos: " + www.error);
            }
            else
            {
                resultText.text = "Datos enviados correctamente";
                Debug.Log("Datos enviados correctamente");
            }
        }
    }
}