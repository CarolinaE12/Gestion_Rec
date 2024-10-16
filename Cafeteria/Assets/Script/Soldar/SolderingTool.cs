using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

/*public class SolderingTool : MonoBehaviour
{
    public ProcessorSolder processorSolder; // Referencia al script del procesador
    public float solderTime = 2.0f; // Tiempo de soldadura
    private bool isSoldering = false;

    void OnMouseDown()
    {
        if (!isSoldering && processorSolder != null)
        {
            StartCoroutine(SolderingProcess());
        }
    }

    private IEnumerator SolderingProcess()
    {
        isSoldering = true;
        Debug.Log("Iniciando soldadura...");
        yield return new WaitForSeconds(solderTime);

        processorSolder.SolderComplete(); // Llamamos al m�todo del procesador para completar la soldadura
        Debug.Log("Soldadura completada.");
        isSoldering = false;
    }
}*/

/*public class SolderingTool : MonoBehaviour
{
    public ProcessorSolder processorSolder; // Referencia al script del procesador
    public GameTimer gameTimer; // Referencia al temporizador
    public ObjectManager objectManager; // Referencia al gestor de objetos
    public float solderTime = 2.0f; // Tiempo de soldadura
    private bool isSoldering = false;
    private Coroutine solderCoroutine;
    private float startTime;

    private Vector3 offset;
    private float zCoord;


    void OnMouseDown()
    {
        Debug.Log("OnMouseDown ejecutado.");
        if (!isSoldering && processorSolder != null && objectManager.AreAllObjectsInPlace())
        {
            startTime = Time.time;
            solderCoroutine = StartCoroutine(SolderingProcess());

            zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            offset = gameObject.transform.position - GetMouseWorldPos();
            Debug.Log("Offset del caut�n: " + offset);
        }
        else
        {
            Debug.Log("Condiciones para soldadura no cumplidas.");
        }
    }

    void OnMouseDrag()
    {
        if (!isSoldering)
        {
            Vector3 newPos = GetMouseWorldPos() + offset;
            newPos.x = Mathf.Clamp(newPos.x, -5f, 5f); // Ajusta estos valores seg�n el �rea visible en tu escena
            newPos.y = Mathf.Clamp(newPos.y, -5f, 5f); // Ajusta estos valores seg�n el �rea visible en tu escena
            newPos.z = Mathf.Clamp(newPos.z, 0.5f, 1.5f); // Mant�n el z dentro de un rango razonable
            transform.position = newPos;
            Debug.Log("Nueva posici�n del caut�n: " + newPos);
        }
    }

    void OnMouseUp()
    {
        Debug.Log("OnMouseUp ejecutado.");
        if (isSoldering)
        {
            StopCoroutine(solderCoroutine);
            float elapsedTime = Time.time - startTime;
            float remainingTime = solderTime - elapsedTime;
            Debug.Log("Tiempo restante: " + remainingTime);

            if (remainingTime > 0)
            {
                int bonusPoints = Mathf.RoundToInt(remainingTime * 2); // Doble de puntos por el tiempo sobrante
                Debug.Log($"Soldadura terminada antes de tiempo. Puntos extra: {bonusPoints}");
            }

            isSoldering = false;
            Debug.Log("Soldadura detenida.");
            if (gameTimer != null)
            {
                gameTimer.StopTimer(); // Detiene el temporizador del juego
                Debug.Log("gameTimer.StopTimer() llamado.");
            }
            else
            {
                Debug.LogWarning("gameTimer no est� asignado.");
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePoint);
        Debug.Log("Posici�n del mouse en el mundo: " + worldPos);
        return worldPos;
    }

    private IEnumerator SolderingProcess()
    {
        isSoldering = true;
        Debug.Log("Iniciando soldadura...");
        yield return new WaitForSeconds(solderTime);

        if (isSoldering) // Verificamos si todav�a est� soldando despu�s del tiempo de espera
        {
            processorSolder.SolderComplete(); // Llamamos al m�todo del procesador para completar la soldadura
            Debug.Log("Soldadura completada.");
            isSoldering = false;
        }
    }
}
*/


public class SolderingTool : MonoBehaviour
{
    public ProcessorSolder processorSolder; // Referencia al script del procesador
    public GameTimer gameTimer; // Referencia al temporizador
    public ObjectManager objectManager; // Referencia al gestor de objetos
    public PointsManager pointsManager; //Referencia al gestor de puntos
    public float solderTime = 2.0f; // Tiempo de soldadura
    private bool isSoldering = false;// Indica si se est� soldando actualmente
    private Coroutine solderCoroutine;// Variable para manejar la corrutina de soldadur
    private float startTime; //Tiempo en que inicia la soldadura

    private Vector3 offset;
    private float zCoord;

    public Transform targetPosition; // Posici�n objetivo para el caut�n

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown ejecutado.");
        if (!isSoldering && processorSolder != null && objectManager.AreAllObjectsInPlace())
        {
            // Solo permitimos soldar si el caut�n est� en la posici�n correcta
            if (IsSolderingPositionCorrect())
            {
                startTime = Time.time;
                solderCoroutine = StartCoroutine(SolderingProcess());

                zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                offset = gameObject.transform.position - GetMouseWorldPos();
                Debug.Log("Offset del caut�n: " + offset);
            }
            else
            {
                Debug.Log("El caut�n no est� en la posici�n correcta.");
            }
        }
        else
        {
            Debug.Log("Condiciones para soldadura no cumplidas.");
        }
    }

    void OnMouseDrag()
    {
        if (!isSoldering)
        {
            Vector3 newPos = GetMouseWorldPos() + offset;
            newPos.x = Mathf.Clamp(newPos.x, -5f, 5f);
            newPos.y = Mathf.Clamp(newPos.y, -5f, 5f);
            newPos.z = Mathf.Clamp(newPos.z, 0.5f, 1.5f);
            transform.position = newPos;
           // Debug.Log("Nueva posici�n del caut�n: " + newPos);
        }
    }

    void OnMouseUp()
    {
        Debug.Log("OnMouseUp ejecutado.");
        if (isSoldering)
        {
            StopCoroutine(solderCoroutine);
            float elapsedTime = Time.time - startTime;
            float remainingTime = solderTime - elapsedTime;
            Debug.Log("Tiempo restante: " + remainingTime);

            if (remainingTime > 0)
            {
                int bonusPoints = Mathf.RoundToInt(remainingTime * 2); // Doble de puntos por el tiempo sobrante
                Debug.Log($"Soldadura terminada antes de tiempo. Puntos extra: {bonusPoints}");
                pointsManager.AddPoints(bonusPoints); // Agrega puntos extra al gestor de puntos
            }

            isSoldering = false;
            Debug.Log("Soldadura detenida.");
            if (gameTimer != null)
            {
                gameTimer.StopTimer(); // Detiene el temporizador del juego
                Debug.Log("gameTimer.StopTimer() llamado.");
            }
            else
            {
                Debug.LogWarning("gameTimer no est� asignado.");
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePoint);
      //  Debug.Log("Posici�n del mouse en el mundo: " + worldPos);
        return worldPos;
    }

    private IEnumerator SolderingProcess()
    {
        isSoldering = true;
        Debug.Log("Iniciando soldadura...");
        yield return new WaitForSeconds(solderTime);

        if (isSoldering) // Verificamos si todav�a est� soldando despu�s del tiempo de espera
        {
            processorSolder.SolderComplete(); // Llamamos al m�todo del procesador para completar la soldadura
            Debug.Log("Soldadura completada.");
            isSoldering = false;
            gameTimer.StopTimer();// Detiene el temporizador del juego
            Debug.Log("gameTimer.StopTimer() llamado desde SolderingProcess.");
        }
    }

    // Comprueba si el caut�n est� en la posici�n correcta para soldar
    private bool IsSolderingPositionCorrect()
    {
        // Aseg�rate de definir correctamente la posici�n donde se debe soldar
        return Vector3.Distance(transform.position, targetPosition.position) < 0.1f;
    }
}
