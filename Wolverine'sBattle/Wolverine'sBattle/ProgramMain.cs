﻿using System;

namespace Wolverine_sBattle_MyFirstRPGGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class ProgramMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameBaseEngine())
                game.Run();
        }
    }
#endif
}
