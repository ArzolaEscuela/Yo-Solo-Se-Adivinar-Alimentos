using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public static class ProjectStrings
    {
        public const string Yes = "Si";
        public const string No = "No";

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
            public const string Subtitle = "Una Versión Escolar Del Popular Juego De 20 Preguntas";
            public const string ButtonText = "Empezar";
        }

        public static class StartScreen
        {
            public const string Title = "Empecemos...";
            public const string Subtitle = "Piensa En Algún Alimento";
            public const string ButtonText = "Listo";
        }

        public static class AnswerNotFound_GetNewAnswer
        {
            public const string Title = "Wow, No Sé En Que Estabas Pensando\n\nTu Ganas";
            public const string Subtitle = "¿En Qué Estabas Pensando?";
            public const string Placeholder = "Escribe tu Respuesta Aquí";
            public const string ButtonText = "Agregar Mi Respuesta";
        }

        public static class AnswerNotFound_GetNewQuestion
        {
            public const string NewQuestionTemplate = "¿Que Pregunta Agregarías Para Distinguir \"{0}\" De \"{1}\"?\n\n(No Importa Si La Respuesta Es Si Ó No)";
            public const string Subtitle = "Ejemplo: \"¿Tu Alimento Es De Color Amarillo?\"";
            public const string Placeholder = "Escribe tu nueva pregunta aquí.";
            public const string ButtonText = "Agregar Mi Pregunta";
        }

        public static class AnswerNotFound_GetYesNoQuestionAnswer
        {
            public const string YesNoSubtitleTemplate = "(Si Tu Respuesta Fuera {0}, Tu Responderías Que...)";
        }

        public static class ThankYou
        {
            public const string Title = "Gracias Por Jugar";
            public const string ButtonText = "Iniciar Nueva Partida";
        }

        public static class AnswerFound
        {
            public const string Title = "¡Lo Sabía!";
            public const string Subtitle = "Denle Una Galleta Al Adivinador De Alimentos";
            public const string ButtonText = "Iniciar Nueva Partida";
        }

        public static class GuessScreen
        {
            public const string GuessTempalte = "Tu Alimento Es...\n\n¿{0}?";
        }
    }
}
