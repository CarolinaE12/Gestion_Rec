using UnityEngine;

public class DraggableObject : MonoBehaviour
{

    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

/*
public class DraggableObject : MonoBehaviour
{
    public int objectIndex; // �ndice del objeto en la lista del gestor
    public ObjectManager objectManager; // Referencia al gestor de objetos

    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        // Al soltar, verificar si el objeto est� en la posici�n correcta
        // El estado del objeto se manejar� mediante OnTriggerEnter y OnTriggerExit
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CorrectArea"))
        {
            objectManager.SetObjectInPlace(objectIndex, true);
            Debug.Log($"Objeto {objectIndex} colocado correctamente.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CorrectArea"))
        {
            objectManager.SetObjectInPlace(objectIndex, false);
            Debug.Log($"Objeto {objectIndex} removido de la posici�n correcta.");
        }
    }
}
*/