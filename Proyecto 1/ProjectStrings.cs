using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public static class ProjectStrings
    {
        public static class Colors
        {
            public const string MAIN = "#FF0B222C";

            private static string[] COLORS = new[]
            {
                "#FFB71C1C", // Red
                "#FF004D40", // Green
                "#FF1A237E", // Blue
                "#FF00838F", // Cyan
                "#FF7B1FA2", // Purple
                "#FFBF360C", // Orange
                "#FF212121", // Gray
            };

            public static string RandomColor => COLORS.GetRandomElement();
        }

        public static class TitleScreen
        {
            public const string Title = "Yo Solo Sé Adivinar Alimentos";
            public const string Subtitle = "Una Versión Escolar del Popular Juego de 20 Preguntas";
            public const string ButtonText = "Empezar";
        }

        public static class StartScreen
        {
            public const string Title = "Empecemos...";
            public const string Subtitle = "Piensa en algún alimento.";
            public const string ButtonText = "Listo";
        }

    }
}
