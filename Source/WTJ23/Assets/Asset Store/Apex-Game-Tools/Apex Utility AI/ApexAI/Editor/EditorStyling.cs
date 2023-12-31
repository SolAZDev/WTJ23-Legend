﻿/* Copyright © 2014 Apex Software. All rights reserved. */
namespace Apex.AI.Editor
{
    using Apex.Editor;
    using UnityEditor;
    using UnityEngine;

    public static class EditorStyling
    {
        public static readonly GUIContent changeTypeTooltip = new GUIContent(string.Empty, "Change Type");
        public static readonly GUIContent setRootTooltip = new GUIContent(string.Empty, "Set as Root");

        public static void InitScaleAgnosticStyles()
        {
            //While the gui styles themselves only need to be initialized once, all textures must be reassigned between playmodes due to Unity's weird "null" behaviour.
            //We just use one of the textured styles to check init state
            if (Canvas.normalSelector != null)
            {
                if (!Canvas.normalSelector.normal.background)
                {
                    SetTextures();
                }

                return;
            }

            Canvas.Init();
            Skinned.Init();

            SetTextures();
        }

        private static void SetTextures()
        {
            Canvas.SetTextures();
            Skinned.SetTextures();
        }

        public static ScaledStyles GetScaledStyles()
        {
            return new ScaledStyles();
        }

        public static class Skinned
        {
            public static GUIStyle propertyBox
            {
                get;
                private set;
            }

            public static GUIStyle smallNumberField
            {
                get;
                private set;
            }

            public static GUIStyle fixedButton
            {
                get;
                private set;
            }

            public static GUIStyle boldTitle
            {
                get;
                private set;
            }

            public static GUIStyle inspectorTitle
            {
                get;
                private set;
            }

            public static GUIStyle disabledText
            {
                get;
                private set;
            }

            public static GUIStyle wrappedItalicText
            {
                get;
                private set;
            }

            public static GUIStyle viewButtonSmall
            {
                get;
                private set;
            }

            public static GUIStyle setRootButtonSmall
            {
                get;
                private set;
            }

            public static GUIStyle wrappedTextArea
            {
                get;
                private set;
            }

            public static void Init()
            {
                var normalText = SharedStyles.BuiltIn.normalText;

                smallNumberField = new GUIStyle(EditorStyles.textField)
                {
                    stretchWidth = false,
                    alignment = TextAnchor.MiddleRight
                };

                propertyBox = new GUIStyle(GUI.skin.box)
                {
                    stretchWidth = true,
                    padding = new RectOffset(4, 4, 6, 6)
                };

                fixedButton = new GUIStyle(GUI.skin.button)
                {
                    stretchWidth = false
                };

                disabledText = new GUIStyle(normalText);
                disabledText.normal.textColor = new Color(88f / 255f, 89f / 255f, 91f / 255f);

                boldTitle = new GUIStyle(normalText)
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontStyle = FontStyle.Bold,
                };

                inspectorTitle = new GUIStyle(normalText)
                {
                    fontStyle = FontStyle.Bold
                };

                wrappedItalicText = new GUIStyle(normalText)
                {
                    fontStyle = FontStyle.Italic,
                    wordWrap = true
                };

                wrappedTextArea = new GUIStyle(GUI.skin.textArea)
                {
                    wordWrap = true
                };

                viewButtonSmall = new GUIStyle(SharedStyles.smallButtonBase);

                setRootButtonSmall = new GUIStyle(SharedStyles.smallButtonBase);
            }

            public static void SetTextures()
            {
                viewButtonSmall.normal.background = UIResources.ViewIcon.texture;
                setRootButtonSmall.normal.background = UIResources.SetRootButtonSmall.texture;
            }
        }

        public static class Canvas
        {
            public static GUIStyle normalHeader
            {
                get;
                private set;
            }

            public static GUIStyle rootSelectorNormal
            {
                get;
                private set;
            }

            public static GUIStyle rootSelectorActive
            {
                get;
                private set;
            }

            public static GUIStyle normalSelector
            {
                get;
                private set;
            }

            public static GUIStyle activeSelector
            {
                get;
                private set;
            }

            public static GUIStyle normalQualifier
            {
                get;
                private set;
            }

            public static GUIStyle activeQualifier
            {
                get;
                private set;
            }

            public static GUIStyle highScoreQualifier
            {
                get;
                private set;
            }

            public static GUIStyle highScoreQualifierSelected
            {
                get;
                private set;
            }

            public static GUIStyle lowScoreQualifier
            {
                get;
                private set;
            }

            public static GUIStyle lowScoreQualifierSelected
            {
                get;
                private set;
            }

            public static GUIStyle normalAction
            {
                get;
                private set;
            }

            public static GUIStyle activeAction
            {
                get;
                private set;
            }

            public static GUIStyle highScoreAction
            {
                get;
                private set;
            }

            public static GUIStyle highScoreActionSelected
            {
                get;
                private set;
            }

            public static GUIStyle lowScoreAction
            {
                get;
                private set;
            }

            public static GUIStyle lowScoreActionSelected
            {
                get;
                private set;
            }

            public static GUIStyle normalScorerBackground
            {
                get;
                private set;
            }

            public static GUIStyle visualizedEntityContainer
            {
                get;
                private set;
            }

            public static GUIStyle smallButtonIcon
            {
                get;
                private set;
            }

            public static GUIStyle viewButtonIcon
            {
                get;
                private set;
            }

            public static void Init()
            {
                normalHeader = new GUIStyle(EditorStyles.label)
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = SharedStyles.defaultFontSize,
                    wordWrap = false
                };

                normalHeader.normal.textColor = SharedStyles.defaultTextColor;

                normalSelector = new GUIStyle();
                normalSelector.border = new RectOffset(4, 4, 4, 2);

                activeSelector = new GUIStyle()
                {
                    border = new RectOffset(6, 6, 6, 2),
                    overflow = new RectOffset(2, 2, 2, 2)
                };

                rootSelectorNormal = new GUIStyle();
                rootSelectorNormal.border = new RectOffset(4, 4, 4, 2);

                rootSelectorActive = new GUIStyle()
                {
                    border = new RectOffset(6, 6, 6, 2),
                    overflow = new RectOffset(2, 2, 2, 2)
                };

                normalQualifier = new GUIStyle();

                activeQualifier = new GUIStyle();
                activeQualifier.border = new RectOffset(2, 2, 2, 2);

                highScoreQualifier = new GUIStyle();
                highScoreQualifier.border = new RectOffset(3, 1, 1, 3);

                highScoreQualifierSelected = new GUIStyle();
                highScoreQualifierSelected.border = new RectOffset(5, 2, 2, 5);

                lowScoreQualifier = new GUIStyle();
                lowScoreQualifier.border = new RectOffset(3, 1, 1, 3);

                lowScoreQualifierSelected = new GUIStyle();
                lowScoreQualifierSelected.border = new RectOffset(5, 2, 2, 5);

                normalAction = new GUIStyle();
                normalAction.border = new RectOffset(2, 2, 2, 2);

                activeAction = new GUIStyle();
                activeAction.border = new RectOffset(2, 2, 2, 2);

                highScoreAction = new GUIStyle();
                highScoreAction.border = new RectOffset(3, 1, 1, 3);

                highScoreActionSelected = new GUIStyle();
                highScoreActionSelected.border = new RectOffset(5, 2, 2, 5);

                lowScoreAction = new GUIStyle();
                lowScoreAction.border = new RectOffset(3, 1, 1, 3);

                lowScoreActionSelected = new GUIStyle();
                lowScoreActionSelected.border = new RectOffset(5, 2, 2, 5);

                normalScorerBackground = new GUIStyle();
                normalScorerBackground.overflow = new RectOffset(-3, 0, 0, 0);

                visualizedEntityContainer = new GUIStyle();
                visualizedEntityContainer.border = new RectOffset(2, 2, 2, 2);

                smallButtonIcon = new GUIStyle()
                {
                    stretchWidth = false,
                    alignment = TextAnchor.MiddleCenter,
                    imagePosition = ImagePosition.ImageOnly
                };

                viewButtonIcon = new GUIStyle();
            }

            public static void SetTextures()
            {
                normalSelector.normal.background = UIResources.SelectorBackground.texture;
                activeSelector.normal.background = UIResources.SelectorSelectedBackground.texture;
                rootSelectorNormal.normal.background = UIResources.SelectorRootBackground.texture;
                rootSelectorActive.normal.background = UIResources.SelectorRootSelectedBackground.texture;
                normalQualifier.normal.background = UIResources.QualifierBackground.texture;
                activeQualifier.normal.background = UIResources.QualifierSelectedBackground.texture;
                highScoreQualifier.normal.background = UIResources.QualifierScoredBackground.texture;
                highScoreQualifierSelected.normal.background = UIResources.QualifierScoredSelectedBackground.texture;
                lowScoreQualifier.normal.background = UIResources.QualifierUnscoredBackground.texture;
                lowScoreQualifierSelected.normal.background = UIResources.QualifierUnscoredSelectedBackground.texture;
                normalAction.normal.background = UIResources.ActionBackground.texture;
                activeAction.normal.background = UIResources.ActionSelectedBackground.texture;
                highScoreAction.normal.background = UIResources.ActionScoredBackground.texture;
                highScoreActionSelected.normal.background = UIResources.ActionScoredSelectedBackground.texture;
                lowScoreAction.normal.background = UIResources.ActionUnscoredBackground.texture;
                lowScoreActionSelected.normal.background = UIResources.ActionUnscoredSelectedBackground.texture;
                normalScorerBackground.normal.background = UIResources.ScorerBackground.texture;
                visualizedEntityContainer.normal.background = UIResources.VisualizedEntityBackground.texture;
                viewButtonIcon.normal.background = UIResources.ViewAIIcon.texture;
            }
        }

        public class ScaledStyles
        {
            private bool _initialized;

            public GUIStyle viewTitle
            {
                get;
                private set;
            }

            public GUIStyle viewTitleActive
            {
                get;
                private set;
            }

            public GUIStyle rootViewTitle
            {
                get;
                private set;
            }

            public GUIStyle rootViewTitleActive
            {
                get;
                private set;
            }

            public GUIStyle normalBoxText
            {
                get;
                private set;
            }

            public GUIStyle activeBoxText
            {
                get;
                private set;
            }

            public GUIStyle disabledBoxText
            {
                get;
                private set;
            }

            public GUIStyle activeDisabledBoxText
            {
                get;
                private set;
            }

            public GUIStyle normalScorer
            {
                get;
                private set;
            }

            public GUIStyle scoreText
            {
                get;
                private set;
            }

            public void Initialize(float scale)
            {
                if (_initialized)
                {
                    return;
                }

                _initialized = true;
                viewTitle = new GUIStyle(EditorStyles.label)
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = SharedStyles.defaultFontSize,
                    wordWrap = false
                };

                viewTitle.normal.textColor = SharedStyles.defaultTextColor;

                viewTitleActive = new GUIStyle(viewTitle)
                {
                    fontStyle = FontStyle.Bold
                };

                rootViewTitle = new GUIStyle(viewTitle);
                rootViewTitle.normal.textColor = new Color(84f / 255f, 141f / 255f, 202f / 255f);

                rootViewTitleActive = new GUIStyle(rootViewTitle)
                {
                    fontStyle = FontStyle.Bold
                };

                normalBoxText = new GUIStyle(EditorStyles.label)
                {
                    alignment = TextAnchor.MiddleLeft,
                    fontSize = SharedStyles.defaultFontSize,
                    wordWrap = false
                };

                normalBoxText.normal.textColor = SharedStyles.defaultTextColor;

                activeBoxText = new GUIStyle(normalBoxText)
                {
                    fontStyle = FontStyle.Bold
                };

                disabledBoxText = new GUIStyle(normalBoxText);
                disabledBoxText.normal.textColor = new Color(88f / 255f, 89f / 255f, 91f / 255f);

                activeDisabledBoxText = new GUIStyle(disabledBoxText)
                {
                    fontStyle = FontStyle.Bold
                };

                normalScorer = new GUIStyle(EditorStyles.label)
                {
                    alignment = TextAnchor.MiddleLeft,
                    wordWrap = false,
                    fontSize = SharedStyles.defaultFontSize
                };

                normalScorer.normal.textColor = SharedStyles.defaultTextColor;

                scoreText = new GUIStyle(EditorStyles.label)
                {
                    alignment = TextAnchor.MiddleRight,
                    fontSize = SharedStyles.defaultFontSize,
                    wordWrap = false
                };

                scoreText.normal.textColor = new Color(0f, 161f / 255f, 75f / 255f);

                ScaleStyles(scale);
            }

            public void ScaleStyles(float zoom)
            {
                var scaledFont = Mathf.RoundToInt(Mathf.Max(SharedStyles.defaultFontSize * zoom, 2f));
                scoreText.fontSize = scaledFont;
                normalScorer.fontSize = scaledFont;
                disabledBoxText.fontSize = scaledFont;
                activeBoxText.fontSize = scaledFont;
                normalBoxText.fontSize = scaledFont;
                viewTitleActive.fontSize = scaledFont;
                viewTitle.fontSize = scaledFont;
                rootViewTitleActive.fontSize = scaledFont;
                rootViewTitle.fontSize = scaledFont;

                normalScorer.padding = new RectOffset(20, 0, 0, 0).Scale(zoom);
                scoreText.padding = new RectOffset(7, 2, 1, 2).Scale(zoom);
            }
        }
    }
}
