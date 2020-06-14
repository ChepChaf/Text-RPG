using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

public class DialogGraphView : GraphView
{
    public DialogGraphView(DialogGraph dialogGraph)
    {
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        AddElement(GetEntrypointNode());
    }

    public void CreateNewDialogueNode(string nodeName, Vector2 position)
    {
        AddElement(CreateNode(nodeName, position));
    }

    public DialogNode CreateNode(string nodeName, Vector2 position)
    {
        var dialogNode = new DialogNode()
        {
            title = nodeName,
            GUID = Guid.NewGuid().ToString(),
            dialogText = nodeName
        };

        var previousPort = GetPortInstance(dialogNode, Direction.Input, Port.Capacity.Multi);
        previousPort.portName = "Input";

        dialogNode.outputContainer.Add(previousPort);

        dialogNode.RefreshExpandedState();
        dialogNode.RefreshPorts();

        dialogNode.SetPosition(new Rect(position, new Vector2(200, 150)));

        return dialogNode;
    }

    private Port GetPortInstance(DialogNode node, Direction nodeDirection,
            Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, nodeDirection, capacity, typeof(float));
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        var startPortView = startPort;

        ports.ForEach((port) =>
        {
            var portView = port;
            if (startPortView != portView && startPortView.node != portView.node)
                compatiblePorts.Add(port);
        });

        return compatiblePorts;
    }

    public DialogNode GetEntrypointNode()
    {
        var entrypointNode = new DialogNode()
        {
            title = "ROOT",
            dialogText = "ENTRYPOINT",
            GUID = Guid.NewGuid().ToString(),
            entryPoint = true
        };

        var nextPort = GetPortInstance(entrypointNode, Direction.Output);
        nextPort.portName = "Next";

        entrypointNode.outputContainer.Add(nextPort);

        entrypointNode.capabilities &= ~Capabilities.Movable;
        entrypointNode.capabilities &= ~Capabilities.Deletable;

        entrypointNode.RefreshExpandedState();
        entrypointNode.RefreshPorts();

        entrypointNode.SetPosition(new Rect(new Vector2(20, 250), new Vector2(200, 150)));

        return entrypointNode;
    }
}
