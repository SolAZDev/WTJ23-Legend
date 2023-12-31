﻿/* Copyright © 2014 Apex Software. All rights reserved. */
namespace Apex.AI.Editor
{
    using Apex.Editor;
    using UnityEngine;

    public sealed class MouseState
    {
        public bool isMouseUp;

        public bool isMouseDown;

        public bool isMouseDrag;

        public bool isMouseWheel;

        public bool isLeftButton;

        public bool isRightButton;

        public bool isMiddleButton;

        public void Update(Event evt)
        {
            isRightButton = evt.button == MouseButton.right;
            isLeftButton = evt.button == MouseButton.left;
            isMiddleButton = evt.button == MouseButton.middle;

            isMouseDown = evt.type == EventType.MouseDown;
            isMouseUp = evt.type == EventType.MouseUp;
            isMouseDrag = evt.type == EventType.MouseDrag;
            isMouseWheel = evt.type == EventType.ScrollWheel;
        }
    }
}
