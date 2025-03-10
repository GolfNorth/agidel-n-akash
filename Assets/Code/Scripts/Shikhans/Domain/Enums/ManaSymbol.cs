using System;

namespace Shikhans.Domain.Enums
{
    /// <summary>
    /// Символ маны
    /// </summary>
    [Flags]
    public enum ManaSymbol
    {
        /// <summary>
        /// Нет символа
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Символ Агидель на верхней стороне
        /// </summary>
        AgidelTop = 1 << 0,

        /// <summary>
        /// Символ Агидель на нижней стороне
        /// </summary>
        AgidelBottom = 1 << 1,

        /// <summary>
        /// Символ Агидель на левой стороне
        /// </summary>
        AgidelLeft = 1 << 2,

        /// <summary>
        /// Символ Агидель на правой стороне
        /// </summary>
        AgidelRight = 1 << 3,

        /// <summary>
        /// Символ Агидель в верхнем левом углу
        /// </summary>
        AgidelTopLeft = 1 << 4,

        /// <summary>
        /// Символ Агидель в верхнем правом углу
        /// </summary>
        AgidelTopRight = 1 << 5,

        /// <summary>
        /// Символ Агидель в нижнем левом углу
        /// </summary>
        AgidelBottomLeft = 1 << 6,

        /// <summary>
        /// Символ Агидель в нижнем правом углу
        /// </summary>
        AgidelBottomRight = 1 << 7,

        // Символы Акаша
        /// <summary>
        /// Символ Акаша на верхней стороне
        /// </summary>
        AkashaTop = 1 << 8,

        /// <summary>
        /// Символ Акаша на нижней стороне
        /// </summary>
        AkashaBottom = 1 << 9,

        /// <summary>
        /// Символ Акаша на левой стороне
        /// </summary>
        AkashaLeft = 1 << 10,

        /// <summary>
        /// Символ Акаша на правой стороне
        /// </summary>
        AkashaRight = 1 << 11,

        /// <summary>
        /// Символ Акаша в верхнем левом углу
        /// </summary>
        AkashaTopLeft = 1 << 12,

        /// <summary>
        /// Символ Акаша в верхнем правом углу
        /// </summary>
        AkashaTopRight = 1 << 13,

        /// <summary>
        /// Символ Акаша в нижнем левом углу
        /// </summary>
        AkashaBottomLeft = 1 << 14,

        /// <summary>
        /// Символ Акаша в нижнем правом углу
        /// </summary>
        AkashaBottomRight = 1 << 15
    }
}