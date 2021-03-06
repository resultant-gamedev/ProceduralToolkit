﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using Random = UnityEngine.Random;

namespace ProceduralToolkit
{
    /// <summary>
    /// Class for generating random data. Contains extensions for arrays and other classes.
    /// </summary>
    public static class RandomE
    {
        #region Vectors

        /// <summary>
        /// Returns a random point on a circle with radius 1
        /// </summary>
        public static Vector2 onUnitCircle2 { get { return PTUtils.PointOnCircle2(1, Random.Range(0, 360f)); } }

        /// <summary>
        /// Returns a random point on a circle with radius 1
        /// </summary>
        public static Vector2 onUnitCircle3XY { get { return PTUtils.PointOnCircle3XY(1, Random.Range(0, 360f)); } }

        /// <summary>
        /// Returns a random point on a circle with radius 1
        /// </summary>
        public static Vector2 onUnitCircle3XZ { get { return PTUtils.PointOnCircle3XZ(1, Random.Range(0, 360f)); } }

        /// <summary>
        /// Returns a random point on a circle with radius 1
        /// </summary>
        public static Vector2 onUnitCircle3YZ { get { return PTUtils.PointOnCircle3YZ(1, Random.Range(0, 360f)); } }

        /// <summary>
        /// Returns a random point inside a unit square
        /// </summary>
        public static Vector2 insideUnitSquare
        {
            get { return Range(new Vector2(-0.5f, -0.5f), new Vector2(0.5f, 0.5f)); }
        }

        /// <summary>
        /// Returns a random point on the perimeter of a unit square
        /// </summary>
        public static Vector2 onUnitSquare { get { return PointOnRect(new Rect(-0.5f, -0.5f, 1, 1)); } }

        /// <summary>
        /// Returns a random point inside a unit cube
        /// </summary>
        public static Vector3 insideUnitCube
        {
            get { return Range(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, 0.5f, 0.5f)); }
        }

        /// <summary>
        /// Returns a random point on a line segment defined by <paramref name="a"/> and <paramref name="b"/>
        /// </summary>
        public static Vector2 PointOnSegment(Vector2 a, Vector2 b)
        {
            return a + (b - a)*Random.value;
        }

        /// <summary>
        /// Returns a random point on a line segment defined by <paramref name="a"/> and <paramref name="b"/>
        /// </summary>
        public static Vector3 PointOnSegment(Vector3 a, Vector3 b)
        {
            return a + (b - a)*Random.value;
        }

        /// <summary>
        /// Returns a random point inside <paramref name="rect"/>
        /// </summary>
        public static Vector2 PointInRect(Rect rect)
        {
            return Range(rect.min, rect.max);
        }

        /// <summary>
        /// Returns a random point on the perimeter of <paramref name="rect"/>
        /// </summary>
        public static Vector2 PointOnRect(Rect rect)
        {
            float perimeter = 2*rect.width + 2*rect.height;
            float value = Random.value*perimeter;
            if (value < rect.width)
            {
                return rect.min + new Vector2(value, 0);
            }
            value -= rect.width;
            if (value < rect.height)
            {
                return rect.min + new Vector2(rect.width, value);
            }
            value -= rect.height;
            if (value < rect.width)
            {
                return rect.min + new Vector2(value, rect.height);
            }
            return rect.min + new Vector2(0, value - rect.width);
        }

        /// <summary>
        /// Returns a random point inside <paramref name="bounds"/>
        /// </summary>
        public static Vector3 PointInBounds(Bounds bounds)
        {
            return Range(bounds.min, bounds.max);
        }

        #endregion Vectors

        #region Colors

        /// <summary>
        /// Returns a random color between black [inclusive] and white [inclusive]
        /// </summary>
        public static Color color { get { return new Color(Random.value, Random.value, Random.value); } }

        /// <summary>
        /// Returns a color with random hue and maximum saturation and value in HSV model
        /// </summary>
        public static ColorHSV colorHSV { get { return new ColorHSV(Random.value, 1, 1); } }

        /// <summary>
        /// Returns a gradient between two random colors
        /// </summary>
        public static Gradient gradient { get { return ColorE.Gradient(color, color); } }

        /// <summary>
        /// Returns a gradient between two random HSV colors
        /// </summary>
        public static Gradient gradientHSV { get { return ColorE.Gradient(colorHSV, colorHSV); } }

        /// <summary>
        /// Returns a color with random hue and given <paramref name="saturation"/> and <paramref name="value"/>
        /// </summary>
        public static ColorHSV ColorHue(float saturation, float value, float alpha = 1)
        {
            return new ColorHSV(Random.value, saturation, value, alpha);
        }

        /// <summary>
        /// Returns a color with random saturation and given <paramref name="hue"/> and <paramref name="value"/>
        /// </summary>
        public static ColorHSV ColorSaturation(float hue, float value, float alpha = 1)
        {
            return new ColorHSV(hue, Random.value, value, alpha);
        }

        /// <summary>
        /// Returns a color with random value and given <paramref name="hue"/> and <paramref name="saturation"/>
        /// </summary>
        public static ColorHSV ColorValue(float hue, float saturation, float alpha = 1)
        {
            return new ColorHSV(hue, saturation, Random.value, alpha);
        }

        /// <summary>
        /// Returns a analogous palette based on a color with random hue
        /// </summary>
        public static List<ColorHSV> AnalogousPalette(
            float saturation = 1,
            float value = 1,
            float alpha = 1,
            int count = 2,
            bool withComplementary = false)
        {
            return ColorHue(saturation, value, alpha).GetAnalogousPalette(count, withComplementary);
        }

        /// <summary>
        /// Returns a triadic palette based on a color with random hue
        /// </summary>
        public static List<ColorHSV> TriadicPalette(
            float saturation = 1,
            float value = 1,
            float alpha = 1,
            bool withComplementary = false)
        {
            return ColorHue(saturation, value, alpha).GetTriadicPalette(withComplementary);
        }

        /// <summary>
        /// Returns a tetradic palette based on a color with random hue
        /// </summary>
        public static List<ColorHSV> TetradicPalette(float saturation = 1, float value = 1, float alpha = 1)
        {
            return ColorHue(saturation, value, alpha).GetTetradicPalette();
        }

        #endregion Colors

        #region Strings

        /// <summary>
        /// Returns a random alphanumeric 8-character string
        /// </summary>
        public static string string8 { get { return PTUtils.alphanumerics.GetRandom(8); } }

        /// <summary>
        /// Returns a random alphanumeric 16-character string
        /// </summary>
        public static string string16 { get { return PTUtils.alphanumerics.GetRandom(16); } }

        /// <summary>
        /// Returns a random lowercase letter
        /// </summary>
        public static char lowercaseLetter { get { return PTUtils.lowercase.GetRandom(); } }

        /// <summary>
        /// Returns a random uppercase letter
        /// </summary>
        public static char uppercaseLetter { get { return PTUtils.uppercase.GetRandom(); } }

        #endregion Strings

        /// <summary>
        /// Returns a random element
        /// </summary>
        public static T GetRandom<T>(this List<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            if (items.Count == 0)
            {
                throw new ArgumentException("Empty array");
            }
            return items[Random.Range(0, items.Count)];
        }

        /// <summary>
        /// Returns a random element
        /// </summary>
        public static T GetRandom<T>(this T[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            if (items.Length == 0)
            {
                throw new ArgumentException("Empty array");
            }
            return items[Random.Range(0, items.Length)];
        }

        /// <summary>
        /// Returns a random element
        /// </summary>
        public static T GetRandom<T>(T item1, T item2, params T[] items)
        {
            int index = Random.Range(0, items.Length + 2);
            if (index == 0)
            {
                return item1;
            }
            if (index == 1)
            {
                return item2;
            }
            return items[index - 2];
        }

        /// <summary>
        /// Returns a random value from dictionary
        /// </summary>
        public static TValue GetRandom<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }
            var keys = dictionary.Keys;
            if (keys.Count == 0)
            {
                throw new ArgumentException("Empty dictionary");
            }
            return dictionary[new List<TKey>(keys).GetRandom()];
        }

        /// <summary>
        /// Returns a random element with chances for roll of each element based on <paramref name="weights"/>
        /// </summary>
        /// <param name="weights">Positive floats representing chances</param>
        public static T GetRandom<T>(this List<T> list, List<float> weights)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (list.Count == 0)
            {
                throw new ArgumentException("Empty array");
            }
            if (weights == null)
            {
                throw new ArgumentNullException("weights");
            }
            if (weights.Count == 0)
            {
                throw new ArgumentException("Empty weights");
            }
            if (list.Count != weights.Count)
            {
                throw new ArgumentException("Array sizes must be equal");
            }

            if (list.Count == 1)
            {
                return list[0];
            }

            var cumulative = new List<float>(weights);
            for (int i = 1; i < cumulative.Count; i++)
            {
                cumulative[i] += cumulative[i - 1];
            }

            float random = Random.Range(0, cumulative[cumulative.Count - 1]);
            int index = cumulative.FindIndex(a => a >= random);
            if (index == -1)
            {
                throw new ArgumentException("Weights must be positive");
            }
            return list[index];
        }

        /// <summary>
        /// Returns a random character from string
        /// </summary>
        public static char GetRandom(this string chars)
        {
            if (string.IsNullOrEmpty(chars))
            {
                throw new ArgumentException("Empty string");
            }
            return chars[Random.Range(0, chars.Length)];
        }

        /// <summary>
        /// Returns a random string consisting of characters from that string
        /// </summary>
        public static string GetRandom(this string chars, int length)
        {
            if (string.IsNullOrEmpty(chars))
            {
                throw new ArgumentException("Empty string");
            }
            var randomString = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                randomString.Append(chars[Random.Range(0, chars.Length)]);
            }
            return randomString.ToString();
        }

        /// <summary>
        /// Returns a random element and removes it from list
        /// </summary>
        public static T PopRandom<T>(this List<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            if (items.Count == 0)
            {
                throw new ArgumentException("Empty array");
            }
            var index = Random.Range(0, items.Count);
            var item = items[index];
            items.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Fisher–Yates shuffle
        /// </summary>
        /// <remarks>
        /// https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
        /// </remarks>
        public static void Shuffle<T>(this T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            for (int i = 0; i < array.Length; i++)
            {
                int j = Random.Range(i, array.Length);
                T tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }
        }

        /// <summary>
        /// Fisher–Yates shuffle
        /// </summary>
        /// <remarks>
        /// https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
        /// </remarks>
        public static void Shuffle<T>(this List<T> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            for (int i = 0; i < array.Count; i++)
            {
                int j = Random.Range(i, array.Count);
                T tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }
        }

        /// <summary>
        /// Returns true with probability from <paramref name="percent"/>
        /// </summary>
        /// <param name="percent">between 0.0 [inclusive] and 1.0 [inclusive]</param>
        public static bool Chance(float percent)
        {
            if (percent == 0) return false;
            if (percent == 1) return true;
            return Random.value < percent;
        }

        /// <summary>
        /// Returns a random vector between <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive]
        /// </summary>
        public static Vector2 Range(Vector2 min, Vector2 max)
        {
            return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }

        /// <summary>
        /// Returns a random vector between <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive]
        /// </summary>
        public static Vector3 Range(Vector3 min, Vector3 max)
        {
            return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        }

        /// <summary>
        /// Returns a random vector between <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive]
        /// </summary>
        public static Vector4 Range(Vector4 min, Vector4 max)
        {
            return new Vector4(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z),
                Random.Range(min.w, max.w));
        }

        /// <summary>
        /// Returns a random float number between and <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive].
        /// Ensures that there will be only specified amount of variants.
        /// </summary>
        public static float Range(float min, float max, int variants)
        {
            if (variants < 2)
            {
                throw new ArgumentException("Variants must be greater than one");
            }
            return Mathf.Lerp(min, max, Random.Range(0, variants)/(variants - 1f));
        }

        /// <summary>
        /// Returns a random vector between and <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive].
        /// Ensures that there will be only specified amount of variants.
        /// </summary>
        public static Vector2 Range(Vector2 min, Vector2 max, int variants)
        {
            return new Vector2(Range(min.x, max.x, variants), Range(min.y, max.y, variants));
        }

        /// <summary>
        /// Returns a random vector between and <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive].
        /// Ensures that there will be only specified amount of variants.
        /// </summary>
        public static Vector3 Range(Vector3 min, Vector3 max, int variants)
        {
            return new Vector3(Range(min.x, max.x, variants), Range(min.y, max.y, variants),
                Range(min.z, max.z, variants));
        }

        /// <summary>
        /// Returns a random vector between and <paramref name="min"/> [inclusive] and <paramref name="max"/> [inclusive].
        /// Ensures that there will be only specified amount of variants.
        /// </summary>
        public static Vector4 Range(Vector4 min, Vector4 max, int variants)
        {
            return new Vector4(Range(min.x, max.x, variants), Range(min.y, max.y, variants),
                Range(min.z, max.z, variants), Range(min.w, max.w, variants));
        }
    }
}