using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationDatabase;
using JsonDatabase.Models;
using MainComponents.Interfaces.DB;

namespace JsonDatabase
{
    public class JsonDataBaseBuilder : IDataBaseBuilder
    {
        private string _diaryStoragePath;
        private string _userStoragePath;
        private IDatabaseAccess _dbAccess;
        public JsonDataBaseBuilder(string diaryStoragePath, string userStoragePath)
        {
            _diaryStoragePath = diaryStoragePath;
            _userStoragePath = userStoragePath;

            BuildDbAccess();
        }
        private void BuildDbAccess()
        {
            var jsonDb = new JsonDB();
            var jsonConverter = new JsonDataConverter();

            _dbAccess = new SerializationDB<JsUser, JsDiary>(jsonDb, jsonConverter);
        }
        public IDatabaseAccess GetDatabaseAccess() => _dbAccess;
    }
}
