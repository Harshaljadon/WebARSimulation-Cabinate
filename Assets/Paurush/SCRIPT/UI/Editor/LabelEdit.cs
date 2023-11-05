using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Label))]
public class LabelEdit : Editor
{
    private SerializedProperty rotationAnglePropertyDot1, rotationAnglePropertyDot2, line1HeightWeidthVectorProp,line2HeightWeidthVectorProp, labelAnchorPosProp;
    private SerializedProperty dottPoint1, dottPoint2;
    private SerializedProperty line1Height_Weidth, line2Height_Weidth;
    private Label label;

    private float previousRotationAngleDot1, previousRotationAngleDot2;
    private Vector2 previousHeidthWeidthLine1,previousHeidthWeidthLine2;
    private Label.AncPos previousAnchorPos;

    private void OnEnable()
    {
        label = (Label)target;
        rotationAnglePropertyDot1 = serializedObject.FindProperty("rotationAngleDot1");
        rotationAnglePropertyDot2 = serializedObject.FindProperty("rotationAngleDot2");
        line1HeightWeidthVectorProp = serializedObject.FindProperty("line1HeightWeidth");
        line2HeightWeidthVectorProp = serializedObject.FindProperty("line2HeightWeidth");

        labelAnchorPosProp = serializedObject.FindProperty("anchorPos");

        dottPoint1 = serializedObject.FindProperty("dot1");
        dottPoint2 = serializedObject.FindProperty("dot2");

        line1Height_Weidth = serializedObject.FindProperty("line1HW");
        line2Height_Weidth = serializedObject.FindProperty("line2HW");

        previousRotationAngleDot1 = label.rotationAngleDot1;
        previousRotationAngleDot2 = label.rotationAngleDot2;
        previousHeidthWeidthLine1 = label.line1HeightWeidth;
        previousHeidthWeidthLine2 = label.line2HeightWeidth;
        previousAnchorPos = label.anchorPos;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(labelAnchorPosProp, new GUIContent("Label Anchor Pos"));

        EditorGUILayout.PropertyField(dottPoint1, new GUIContent("Rotation Point 1"));
        EditorGUILayout.PropertyField(rotationAnglePropertyDot1, new GUIContent("Rotation Angle Dot 1"));
        EditorGUILayout.PropertyField(dottPoint2, new GUIContent("Rotation Point 2"));
        EditorGUILayout.PropertyField(rotationAnglePropertyDot2, new GUIContent("Rotation Angle Dot 2"));

        EditorGUILayout.PropertyField(line1Height_Weidth, new GUIContent("line 1 height weidth edit"));
        EditorGUILayout.PropertyField(line1HeightWeidthVectorProp, new GUIContent("line 1 height weidth"));
        EditorGUILayout.PropertyField(line2Height_Weidth, new GUIContent("line 2 height weidth edit"));
        EditorGUILayout.PropertyField(line2HeightWeidthVectorProp, new GUIContent("line 2 height weidth"));

        // Display the enum property
        //label.anchorPos = (Label.AncPos)EditorGUILayout.EnumPopup("Label Anchor Position", label.anchorPos);


        serializedObject.ApplyModifiedProperties();

        if (label != null && (label.rotationAngleDot1 != previousRotationAngleDot1
            || label.rotationAngleDot2 != previousRotationAngleDot2
            || label.line1HeightWeidth != previousHeidthWeidthLine1
            || label.line2HeightWeidth != previousHeidthWeidthLine2
            || label.anchorPos != previousAnchorPos
            ))
        {
            label.RotateToAngleDot1(label.rotationAngleDot1);
            previousRotationAngleDot1 = label.rotationAngleDot1;
            label.RotateToAngleDot2(label.rotationAngleDot2);
            previousRotationAngleDot2 = label.rotationAngleDot2;
            label.ChangeLine1HeightWeidth(label.line1HeightWeidth);
            previousHeidthWeidthLine1 = label.line1HeightWeidth;
            label.ChangeLine2HeightWeidth(label.line2HeightWeidth);
            previousHeidthWeidthLine2 = label.line2HeightWeidth;
            previousAnchorPos = label.anchorPos;

            switch (label.anchorPos)
            {
                case Label.AncPos.left:
                    label.ChangeAnchorPosLable(0);
                    break;
                case Label.AncPos.right:

                    label.ChangeAnchorPosLable(1);
                    break;
                case Label.AncPos.top:

                    label.ChangeAnchorPosLable(2);
                    break;
                case Label.AncPos.bottom:

                    label.ChangeAnchorPosLable(3);
                    break;
            }
        }


    }
}
