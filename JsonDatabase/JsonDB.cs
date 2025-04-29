using JsonDatabase.Models;
using MainComponents.Interfaces.Constants;
using SerializationDatabase.Interfaces;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using System.Diagnostics;
using MainComponents.Models;

namespace JsonDatabase
{
    public class JsonDB : ISerializationDBAccess<JsUser, JsDiary>
    {
        private readonly DirectoryInfo _userFilesDir;
        private readonly DirectoryInfo _diaryFilesDir;

        private readonly DirectoryInfo _dbDir;

        private readonly JsonSerializer _serializer;
        public JsonDB(IDatabasePath databasePath)
        {
            _dbDir = new DirectoryInfo(databasePath.DataBasePath);

            _userFilesDir = _dbDir.CreateSubdirectory(nameof(JsUser)); 
            _diaryFilesDir = _dbDir.CreateSubdirectory(nameof(JsDiary));

            _serializer = new JsonSerializer();
        }
        public bool FindUser(string login)
        {
            return FindUser(login, out JsUser? user);
        }
        bool FindUser(string login, out JsUser? user)
        {
            var userFiles = _userFilesDir.GetFiles();

            bool found = false;
            user = null;

            foreach (var file in userFiles)
            {
                TryLoad<JsUser>(file.FullName, out user);

                if (user?.Login == login)
                {
                    found = true; 
                    break;
                }

            }

            return found;
        }
        bool FindDiary(int id, out FileInfo? file)
        {
            var diaryFiles = _diaryFilesDir.GetFiles();

            file = diaryFiles.FirstOrDefault(k => k.Name == id.ToString());

            bool found;

            found = file != null;

            return found;
        }
        bool ISerializationDBAccess<JsUser, JsDiary>.TryLoadDiary(int id, out JsDiary? diary)
            => TryLoadDiary(id, out diary);

        bool ISerializationDBAccess<JsUser, JsDiary>.TryLoadUser(string login, out JsUser? user)
            => TryLoadUser(login, out user);
        bool TryLoadUser(string login, out JsUser? user)
        {
            return FindUser(login, out user);
        }
        bool TryLoadDiary(int id, out JsDiary? diary)
        {
            bool result = FindDiary(id, out FileInfo? file);

            if (result)
            {
                result = TryLoad<JsDiary>(file.FullName, out diary);
            }
            else
            {
                diary = null;
            }

            return result;
        }
        bool TryLoad<T>(string filePath, out T? loaded)
        {
            bool isSuccess = true;

            try
            {
                SerializerLoad<T>(filePath, out loaded);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                loaded = default;
                isSuccess = false;
            }

            return isSuccess;
        }
        (bool uSuc, bool dSuc) ISerializationDBAccess<JsUser, JsDiary>.TrySave(JsUser user, JsDiary diary)
        {
            bool uSuc = TrySave(user);
            bool dSuc = TrySave(diary);

            return (uSuc, dSuc);
        }
        bool TrySave(JsUser user)
        {
            string filePath = GetFilePath(user);

            bool isSuccess = true;

            isSuccess = TrySave<JsUser>(user, filePath);

            return isSuccess;
        }
        bool TrySave(JsDiary diary)
        {
            string filePath = GetFilePath(diary);

            bool isSuccess;

            isSuccess = TrySave<JsDiary>(diary, filePath);

            return isSuccess;
        }
        bool ISerializationDBAccess<JsUser, JsDiary>.TrySave(JsDiary diary) => TrySave(diary);
        bool TrySave<T>(T toSave, string filePath)
        {
            bool isSuccess = true;

            try
            {
                SerializerSave<T>(toSave, filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                isSuccess = false;
            }

            return isSuccess;
        }
        private string GetFileName(JsDiary diary) => diary.Id.ToString();
        private string GetFileName(JsUser user) => user.Id.ToString();
        private string GetFilePath(JsDiary diary)
        {
            string fileName = GetFileName(diary); 

            string path = Path.Combine(_diaryFilesDir.FullName, fileName);

            return path;
        }
        private string GetFilePath(JsUser user)
        {
            string fileName = GetFileName(user);

            string path = Path.Combine(_userFilesDir.FullName, fileName);

            return path;
        }
        private void SerializerSave<T>(T toSerialize, string filePath)
        {
            try
            {
                using (var sw = new StreamWriter(filePath, false))
                using (var jw = new JsonTextWriter(sw))
                {
                    _serializer.Serialize(jw, toSerialize);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void SerializerLoad<T>(string filePath, out T? deserialized)
        {
            try
            {
                using (var sr = new StreamReader(filePath))
                using (var jr = new JsonTextReader(sr))
                {
                    deserialized = _serializer.Deserialize<T>(jr);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetUserIds()
        {
            int ids = 0;

            var files = _userFilesDir.GetFiles();

            foreach (var file in files)
            {
                ids++;
            }

            return ids;
        }

        public int GetDiaryIds()
        {
            int ids = 0;

            var files = _userFilesDir.GetFiles();

            foreach (var file in files)
            {
                ids++;
            }

            return ids;
        }
    }
}
