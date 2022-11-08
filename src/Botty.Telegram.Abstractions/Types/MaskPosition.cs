using Botty.Telegram.Abstractions.Enums;

namespace Botty.Telegram.Abstractions.Types
{
    /// <summary>
    /// This object describes the position on faces where a mask should be placed by default
    /// </summary>
    public class MaskPosition
    {
        /// <summary>
        /// The part of the face relative to which the mask should be placed
        /// </summary>
        public MaskPositionPoint Point { get; }

        /// <summary>
        /// Shift by X-axis measured in widths of the mask scaled to the face size, from left to right
        /// </summary>
        public float XShift { get; }

        /// <summary>
        /// Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom
        /// </summary>
        public float YShift { get; }

        /// <summary>
        /// Mask scaling coefficient
        /// </summary>
        public float Scale { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="point">The part of the face</param>
        /// <param name="xShift">X shift</param>
        /// <param name="yShift">Y shift</param>
        /// <param name="scale">Scale</param>
        public MaskPosition(
            MaskPositionPoint point,
            float xShift,
            float yShift,
            float scale)
        {
            Point = point;
            XShift = xShift;
            YShift = yShift;
            Scale = scale;
        }
    }
}
