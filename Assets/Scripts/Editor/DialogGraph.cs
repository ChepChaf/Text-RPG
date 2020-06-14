using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System;
using UnityEditor.UIElements;

public class DialogGraph : EditorWindow
{
    private DialogGraphView _graphView;

    [MenuItem("Graph/Create Dialogue Graph")]
    public static void CreateGraphViewWindow()
    {
        var window = GetWindow<DialogGraph>();
        window.titleContent = new GUIContent("Dialogue graph");
    }

    private void ConstructGraphView()
    {
        _graphView = new DialogGraphView(this)
        {
            name = "Dialogue Graph"
        };

        _graphView.StretchToParentSize();
        rootVisualElement.Add(_graphView);
    }

    private void OnEnable()
    {
        ConstructGraphView();
        GenerateToolbar();
    }

    private void GenerateToolbar()
    {
        var toolbar = new Toolbar();

        toolbar.Add(new Button( () => _graphView.CreateNewDialogueNode("Dialogue Node", new Vector2(250, 250))) { text = "New Node" });

        rootVisualElement.Add(toolbar);
    }

    private void OnDisable()
    {
        rootVisualElement.Remove(_graphView);
    }
}