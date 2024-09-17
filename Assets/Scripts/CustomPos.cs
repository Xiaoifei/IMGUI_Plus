using UnityEngine;

public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_down,
    Right_Up,
    Right_down,
}
[System.Serializable]
public class CustomPos
{
    public Rect inputRect = new Rect(0,0,100,50);
    public E_Alignment_Type pivotAlignType = E_Alignment_Type.Center;
    public E_Alignment_Type anchorAlignType = E_Alignment_Type.Center;
    public Vector2 offset;
    public float width = 100;
    public float height = 50;

    public Rect FinalRect {
        get
        {
            GetAnchorPos();
            GetScreenPos();
            CalFinalRect();
            inputRect.width = width;
            inputRect.height = height;
            return inputRect;
        }
    }
    private Rect innnerPivotOffset;//存储控件内支点偏移值的Offset
    private void GetAnchorPos(){
        switch (pivotAlignType)
        {
            case E_Alignment_Type.Up:
                innnerPivotOffset.x = -width/2;
                innnerPivotOffset.y = 0;
                break;
            case E_Alignment_Type.Down:
                innnerPivotOffset.x = -width/2;
                innnerPivotOffset.y = -height;
                break;
            case E_Alignment_Type.Left:
                innnerPivotOffset.x = 0;
                innnerPivotOffset.y = -height/2;
                break;
            case E_Alignment_Type.Right:
                innnerPivotOffset.x = -width;
                innnerPivotOffset.y = -height/2;
                break;
            case E_Alignment_Type.Center:
                innnerPivotOffset.x = -width/2;
                innnerPivotOffset.y = -height/2;
                break;
            case E_Alignment_Type.Left_Up:
                innnerPivotOffset.x = 0;
                innnerPivotOffset.y = 0;
                break;
            case E_Alignment_Type.Left_down:
                innnerPivotOffset.x = 0;
                innnerPivotOffset.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                innnerPivotOffset.x = -width;
                innnerPivotOffset.y = 0;
                break;
            case E_Alignment_Type.Right_down:
                innnerPivotOffset.x = -width;
                innnerPivotOffset.y = -height;
                break;
        }
    }
    private Rect screenAnchorOffset;//存储屏幕上锚点偏移值的Offset
    private void GetScreenPos(){
        switch (anchorAlignType)
        {
            case E_Alignment_Type.Up:
                screenAnchorOffset.x = Screen.width/2;
                screenAnchorOffset.y = 0;
                break;
            case E_Alignment_Type.Down:
                screenAnchorOffset.x = Screen.width/2;
                screenAnchorOffset.y = Screen.height;
                break;
            case E_Alignment_Type.Left:
                screenAnchorOffset.x = 0;
                screenAnchorOffset.y = Screen.height/2;
                break;
            case E_Alignment_Type.Right:
                screenAnchorOffset.x = Screen.width;
                screenAnchorOffset.y = Screen.height/2;
                break;
            case E_Alignment_Type.Center:
                screenAnchorOffset.x = Screen.width/2;
                screenAnchorOffset.y = Screen.height/2;
                break;
            case E_Alignment_Type.Left_Up:
                screenAnchorOffset.x = 0;
                screenAnchorOffset.y = 0;
                break;
            case E_Alignment_Type.Left_down:
                screenAnchorOffset.x = 0;
                screenAnchorOffset.y = Screen.height;
                break;
            case E_Alignment_Type.Right_Up:
                screenAnchorOffset.x = Screen.width;
                screenAnchorOffset.y = 0;
                break;
            case E_Alignment_Type.Right_down:
                screenAnchorOffset.x = Screen.width;
                screenAnchorOffset.y = Screen.height;
                break;
        }
    }
    private void CalFinalRect(){
        inputRect.x = screenAnchorOffset.x + innnerPivotOffset.x + offset.x;//控件最终渲染位置 = 屏幕布局位置 + 控件内支点位置 + 自定义偏移位置
        inputRect.y = screenAnchorOffset.y + innnerPivotOffset.y + offset.y;
    }
}