﻿namespace Shikhans.Domain.Enums
{
    /// <summary>
    /// Типы ячеек
    /// </summary>
    public enum CellType : byte
    {
        None = 0,

        /// <summary>
        /// Река
        /// </summary>
        River = 1,

        /// <summary>
        /// Каменоломня
        /// </summary>
        Quarry = 2,

        /// <summary>
        /// Горная река
        /// </summary>
        MountainRiver = 3,

        /// <summary>
        /// Камень
        /// </summary>
        Stone = 11,

        /// <summary>
        /// Плотина
        /// </summary>
        Dam = 12,

        /// <summary>
        /// Разлом
        /// </summary>
        Rift = 13,

        /// <summary>
        /// Крепость-гора
        /// </summary>
        Fortress = 14,

        /// <summary>
        /// Сердце-гора
        /// </summary>
        Heart = 15,

        /// <summary>
        /// Лошадь-гора
        /// </summary>
        Horse = 16,

        /// <summary>
        /// Птица-гора
        /// </summary>
        Bird = 17,
    }
}