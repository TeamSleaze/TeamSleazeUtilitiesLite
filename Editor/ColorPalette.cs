using System.Collections.Generic;
using UnityEngine;

namespace TeamSleaze.UtilitiesLite
{
    [System.Serializable]
    public class ColorDesign
    {
        public string KeyChar;
        public Color TextColor;
        public Color BackgroundColor;
        public TextAnchor TextAlignment;
        public FontStyle FontStyle;
        public bool UpperCase;
    }

    public class ColorPalette : ScriptableObject
    {
        public List<ColorDesign> ColorDesigns = new List<ColorDesign>();
    }
}