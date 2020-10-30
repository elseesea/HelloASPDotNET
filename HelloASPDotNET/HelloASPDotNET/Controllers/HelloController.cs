using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {

        private static Dictionary<string, string> WorldGreetings = new Dictionary<string, string> ()
        {
            { "english", "Hello" },
            { "french", "Bonjour" },
            { "spanish", "Hola" },
            { "danish", "Velkommen" },
            { "icelandic", "Velkominn" }
        };

        [HttpGet]
        public IActionResult Index()
        {

            string html = "<form method='post' action='/helloworld/welcome'>" +
                "<input type='text' name='name' />" +
                "<label for= 'language-select'></label>" +
                "<select name = 'language' id='language-select'>" +
                "<option value = 'english'>English</option>" +
                "<option value = 'french'>French</option>" +
                "<option value = 'spanish'>Spanish</option>" +
                "<option value = 'danish'>Danish</option>" +
                "<option value = 'icelandic'>Icelandic</option>" +
                "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");
        }

        [HttpPost("welcome")]
        public IActionResult Welcome(string name = "World", string language = "english")
        {
            return Content("<h1>" + CreateMessage(name, language) + "</h1>", "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            return (WorldGreetings[language] + " " + name);
        }
    }
}
