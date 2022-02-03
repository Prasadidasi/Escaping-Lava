using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] string menuName;
    public bool open;

    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    public void Close() {
        open = false;
        gameObject.SetActive(false);
    }

}