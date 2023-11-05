using UnityEngine;

public class Label : MonoBehaviour
{
    public float rotationAngleDot1, rotationAngleDot2;
    public Vector2 line1HeightWeidth, line2HeightWeidth;

    [System.Serializable]
    public enum AncPos { left, right, top, bottom }

    public AncPos anchorPos;

    [SerializeField]
    private RectTransform dot1;

    [SerializeField]
    private RectTransform dot2;

    [SerializeField]
    private RectTransform line1HW;

    [SerializeField]
    private RectTransform line2HW;

    public void RotateToAngleDot1(float angle)
    {
        dot1.rotation = Quaternion.Euler(-180, 0, angle);
    }

    public void RotateToAngleDot2(float angle)
    {
        dot2.rotation = Quaternion.Euler(-180, 0, angle);
    }

    public void ChangeLine1HeightWeidth(Vector2 heightWeidth)
    {
        line1HW.sizeDelta = heightWeidth;
    }

    public void ChangeLine2HeightWeidth(Vector2 heightWeidth)
    {
        line2HW.sizeDelta = heightWeidth;
    }

    public void ChangeAnchorPosLable(int id)
    {
        switch (id)
        {
            case 0:
                line2HW.pivot = new Vector2(0, .5f);
                break;
            case 1:
                line2HW.pivot = new Vector2(1, .5f);
                break;
            case 2:
                line2HW.pivot = new Vector2(0.5f, 1);
                break;
            case 3:
                line2HW.pivot = new Vector2(0.5f, 0);
                break;
            default:
                break;
        }
    }
}


