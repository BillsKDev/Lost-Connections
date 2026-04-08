using UnityEngine;

public class Delete : MonoBehaviour
{
    public void DeleteGameObject(GameObject objectToDelete)
    {
        if (objectToDelete != null)
            Destroy(objectToDelete);
    }
}
