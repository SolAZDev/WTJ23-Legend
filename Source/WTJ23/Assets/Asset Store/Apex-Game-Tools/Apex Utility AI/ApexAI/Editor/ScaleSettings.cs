﻿/* Copyright © 2014 Apex Software. All rights reserved. */
namespace Apex.AI.Editor
{
    using UnityEngine;

    public sealed class ScaleSettings
    {
        public static readonly ScaleSettings FullScale = new ScaleSettings(1f);
#if UNITY_5 || UNITY_2017
        private const float connectorLineBaseWidth = 4f;
#else
        private const float connectorLineBaseWidth = 2f;
#endif

        private float _scale;
        private UserSettings _settings;

        public float selectorResizeMargin;
        public float connectorLineWidth;
        public float viewMinWidth;

        public float anchorAreaWidth;
        public float dragHandleWidth;
        public float toggleAreaWidth;

        public ScaleSettings(float currentScale)
        {
            _settings = UserSettings.instance;
            UpdateScale(currentScale);
        }

        public float scale
        {
            get { return _scale; }
        }

        public float snapCellSize
        {
            get { return Mathf.Round(_settings.snapCellSize * _scale); }
        }

        public float titleHeight
        {
            get { return Mathf.Round(_settings.titleHeight * _scale); }
        }

        public float qualifierHeight
        {
            get { return Mathf.Round(_settings.qualifierHeight * _scale); }
        }

        public float actionHeight
        {
            get { return Mathf.Round(_settings.actionHeight * _scale); }
        }

        public float scorerHeight
        {
            get { return Mathf.Round(_settings.scorerHeight * _scale); }
        }

        public float aiLinkBodyHeight
        {
            get { return Mathf.Round(_settings.qualifierHeight * _scale); }
        }

        public void UpdateScale(float newScale)
        {
            _scale = newScale;
            selectorResizeMargin = 4f * _scale;
            connectorLineWidth = connectorLineBaseWidth * _scale;
            viewMinWidth = 100f * _scale;

            anchorAreaWidth = 20f * _scale;
            dragHandleWidth = 20f * _scale;
            toggleAreaWidth = 20f * _scale;
        }
    }
}
