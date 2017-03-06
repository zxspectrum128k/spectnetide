﻿namespace Spect.Net.Spectrum.Ula
{
    /// <summary>
    /// This interface represents a renderer that can display a
    /// pixel in a virtual screen device
    /// </summary>
    public interface IScreenPixelRenderer
    {
        /// <summary>
        /// The ULA signs that it's time to start a new frame
        /// </summary>
        void StartNewFrame();

        /// <summary>
        /// Renders the (<paramref name="x"/>, <paramref name="y"/>) pixel
        /// on the screen with the specified <paramref name="colorIndex"/>
        /// </summary>
        /// <param name="x">Horizontal coordinate</param>
        /// <param name="y">Vertical coordinate</param>
        /// <param name="colorIndex">Index of the color (0x00..0x0F)</param>
        void RenderPixel(int x, int y, int colorIndex);

        /// <summary>
        /// Signs that the current frame is rendered and ready to be displayed
        /// </summary>
        void DisplayFrame();
    }
}