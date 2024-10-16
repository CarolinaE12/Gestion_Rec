using UnityEngine;
using System.Collections;

/*public class ProcessorSolder : MonoBehaviour
{
    public Transform targetPosition; // La posición de soldadura en la board
    public PointsManager pointsManager;

    private bool isSoldered = false;

    void OnMouseDown()
    {
        if (!isSoldered) // Solo permitimos la soldadura si aún no está soldado
        {
            StartCoroutine(SolderProcessor());
        }
    }

    private IEnumerator SolderProcessor()
    {
        // Simulamos el tiempo que tomaría la soldadura
        float solderTime = 2.0f; // Por ejemplo, 2 segundos para soldar
        float elapsedTime = 0.0f;

        while (elapsedTime < solderTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Una vez completado el tiempo de soldadura
        transform.position = targetPosition.position;
        isSoldered = true;
        pointsManager.AddPoints(15); // Suponiendo 15 puntos por soldar correctamente
        Debug.Log("Procesador soldado correctamente");
    }

    public void SolderComplete()
    {
        if (!isSoldered)
        {
            transform.position = targetPosition.position;
            isSoldered = true;
            pointsManager.AddPoints(15); // Suponiendo 15 puntos por soldar correctamente
            Debug.Log("Procesador soldado correctamente a través del cautín");
        }
    }
}
*/
public class ProcessorSolder : MonoBehaviour
{
    public Transform targetPosition; // La posición de soldadura en la board
    public PointsManager pointsManager;

    private bool isSoldered = false;

    public void SolderComplete() 
    { 
    StartCoroutine(SolderProcessor());
    }
    void OnMouseDown()
    {
        if (!isSoldered) // Solo permitimos la soldadura si aún no está soldado
        {
            StartCoroutine(SolderProcessor());
        }
    }

    private IEnumerator SolderProcessor()
    {
        // Simulamos el tiempo que tomaría la soldadura
        float solderTime = 2.0f; // Por ejemplo, 2 segundos para soldar
        float elapsedTime = 0.0f;

        while (elapsedTime < solderTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Una vez completado el tiempo de soldadura
        transform.position = targetPosition.position;
        isSoldered = true;
        pointsManager.AddPoints(15); // Suponiendo 15 puntos por soldar correctamente
        Debug.Log("Procesador soldado correctamente");
    }
}



