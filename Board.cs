using UnityEngine;

public class Board : MonoBehaviour
{
    PickAndDrag pad = new PickAndDrag();
    
    void Update()
    {
        pad.Action();   
    }
}

class PickAndDrag
{
    State state;
    GameObject item;
    enum State
    {
        none,
        drag
    }

    public void Action()
    {
        switch (state)
        {
            case State.none:
                if (IsMouseButtonPressed())
                    PickUp();
                break;
            case State.drag:

                break;
        }
    }

    bool IsMouseButtonPressed()
    {
        return Input.GetMouseButton(0);
    }

    void PickUp()
    {
        Vector2 clickPosition = GetClickPosition();
        Transform clickedItem = GetItemAt(clickPosition);
        if (clickedItem == null)
            return;
    }

    Vector2 GetClickPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Transform GetItemAt(Vector2 position)
    {
       RaycastHit2D[] figures = Physics2D.RaycastAll(position, position, 0.5f);
        if (figures.Length == 0)
            return null;
        return figures[0].transform;
    }
}
