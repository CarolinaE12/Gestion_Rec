using UnityEngine;

public class DropZone : MonoBehaviour
{
    [System.Serializable]
    public class DraggableObject
    {
        public string expectedObjectTag; // Etiqueta esperada para el objeto
        public Transform snapPosition; // Posición específica donde el objeto debe colocarse
    }

    public DraggableObject[] draggableObjects; // Array de objetos draggables
    public PointsManager pointsManager; // Referencia al PointsManager

    void OnTriggerEnter(Collider other)
    {
        foreach (DraggableObject draggable in draggableObjects)
        {
            if (other.CompareTag(draggable.expectedObjectTag))
            {
                Debug.Log("Objeto " + other.name + " soltado correctamente en la zona.");
                other.transform.position = draggable.snapPosition.position; // Mueve el objeto a la posición de ajuste
                other.transform.SetParent(transform); // Asegura que el objeto se mueva con la board si es necesario

                // Añadir puntos
                pointsManager.AddPoints(10); // Suponiendo 10 puntos por cada objeto colocado correctamente

                return;
            }
        }
        Debug.LogWarning("Objeto incorrecto soltado en la zona: " + other.name);
    }
}

