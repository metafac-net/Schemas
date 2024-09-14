﻿using System;

namespace MetaFac.Schemas
{
    [Flags]
    public enum ItemState
    {
        /// <summary>
        /// Active. Emitted during generation.
        /// </summary>
        Active = 0,

        /// <summary>
        /// Hidden. Not emitted during generation. Useful for pre-allocating items.
        /// </summary>
        Hidden = 0x01,

        /// <summary>
        /// Deprecated. Emitted during generation. Will be deleted in the future.
        /// </summary>
        Deprecated = 0x02,

        /// <summary>
        /// Deleted. Not emitted during generation.
        /// </summary>
        Deleted = Hidden | Deprecated,
    }
}
