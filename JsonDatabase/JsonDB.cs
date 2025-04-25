using JsonDatabase.Models;
using SerializationDatabase;

namespace JsonDatabase
{
    public class JsonDB : ISerializationDBAccess<JsUser, JsDiary>
    {
        public bool FindUser(string login)
        {
            throw new NotImplementedException();
        }

        bool ISerializationDBAccess<JsUser, JsDiary>.TryLoadDiary(int id, out JsDiary diary)
        {
            throw new NotImplementedException();
        }

        bool ISerializationDBAccess<JsUser, JsDiary>.TryLoadUser(string login, out JsUser user)
        {
            throw new NotImplementedException();
        }

        (bool uSuc, bool dSuc) ISerializationDBAccess<JsUser, JsDiary>.TrySave(JsUser user, JsDiary diary)
        {
            throw new NotImplementedException();
        }

        bool ISerializationDBAccess<JsUser, JsDiary>.TrySave(JsDiary diary)
        {
            throw new NotImplementedException();
        }
    }
}
