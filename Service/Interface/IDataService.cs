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
    }
}
