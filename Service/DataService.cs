using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaS.Service.Interface;
using Windows.Storage;
using System.IO;
using System.Xml.Serialization;

namespace SaS.Service
{
    public class DataService : IDataService
    {
        async public Task SerializeObjectToFileAsync<T>(T objectToSerialize, string fileName)
        {
            StorageFile targetFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (Stream stream = await targetFile.OpenStreamForWriteAsync())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, objectToSerialize);
            }
        }

        async public Task<T> DeserializeObjectFromFileAsync<T>(string filePath)
        {
            T targetObject = default(T);
            
            StorageFile targetFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filePath);
            using (Stream stream = await targetFile.OpenStreamForReadAsync())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                targetObject = (T)serializer.Deserialize(stream);
            }

            return targetObject;
        }
    }
}
