using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS.Service.Interface
{
    public interface IDataService
    {
        /// <summary>
        /// Serializa un objeto dado en un archivo del localStorage
        /// de la aplicación para su posterior de-serialización
        /// y utilización.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto que se va a serializar.</typeparam>
        /// <param name="objectToSerialize">Objeto a serializar.</param>
        /// <param name="fileName">Ruta relativa donde se guardará el archivo que contiene al objeto.</param>
        /// <returns></returns>
        Task SerializeObjectToFileAsync<T>(T objectToSerialize, string fileName);

        /// <summary>
        /// Recupera un objeto serializado en un archivo del localStorage
        /// de la aplicación.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto que se va a deserializar.</typeparam>
        /// <param name="filePath">Ruta relativa al archivo que contiene al objeto.</param>
        /// <returns>El objeto si se pudo deserializar, o null si se produce algún fallo.</returns>
        Task<T> DeserializeObjectFromFileAsync<T>(string filePath);

        /// <summary>
        /// Serializa un texto arbitrario a un archivo en el localStorade
        /// de la aplicación.
        /// </summary>
        /// <param name="text">Texto a serializar.</param>
        /// <param name="filename">Nombre y extensión del archivo objetivo.</param>
        /// <returns></returns>
        Task SaveTextToFileAsync(string text, string filename);

        /// <summary>
        /// Lee un archivo de texto guardado en el localStorage y
        /// lo devuelve como <see cref="String"/>.
        /// </summary>
        /// <param name="filename">Nombre y extensión del archivo objetivo.</param>
        /// <returns>El texto contenido en el archivo solicitado.</returns>
        Task<string> ReadTextFromFile(string filename);
    }
}
