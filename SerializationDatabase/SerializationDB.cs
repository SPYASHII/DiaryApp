using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainComponents.Interfaces.DB;
using MainComponents.Models;
using SerializationDatabase.Interfaces;

namespace SerializationDatabase
{
    public class SerializationDB<UType, DType> : IDatabaseAccess
    {
        private IDataConverter<UType, DType> _dataConverter;
        private ISerializationDBAccess<UType, DType> _dbAccess;

        public SerializationDB(ISerializationDBAccess<UType, DType> dbAccess, IDataConverter<UType, DType> dataConverter)
        {
            _dbAccess = dbAccess;
            _dataConverter = dataConverter;
        }
        public bool TryLoadDiary(int id, out Diary? diary)
        {
            bool result = _dbAccess.TryLoadDiary(id, out DType? diaryConv);

            if (result)
                diary = _dataConverter.Convert(diaryConv);
            else
                diary = null;

            return result;
        }

        public bool TryLoadUser(string login, out User? user)
        {
            bool result = _dbAccess.TryLoadUser(login, out UType? userConv);

            if (result)
                user = _dataConverter.Convert(userConv);
            else
                user = null;

            return result;
        }

        public (bool uSuc, bool dSuc) TrySave(User user, Diary diary)
        {
            UType userConv = _dataConverter.Convert(user);
            DType diaryConv = _dataConverter.Convert(diary);

            var result = _dbAccess.TrySave(userConv, diaryConv);

            return result;
        }
        public bool TrySave(Diary diary)
        {
            DType diaryConv = _dataConverter.Convert(diary);

            bool result = _dbAccess.TrySave(diaryConv);

            return result;
        }
        public bool FindUser(string login) => _dbAccess.FindUser(login);

        public int GetDiaryIds() =>
            _dbAccess.GetDiaryIds();


        public int GetUserIds() =>
            _dbAccess.GetUserIds();

    }
}
