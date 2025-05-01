using MainComponents.Interfaces.Controllers;
using MainComponents.Interfaces.DB;
using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainComponents.Controllers
{
    public class DataController : IDataController
    {
        private readonly IDatabaseAccess _dbAccess;
        private User? _currentUser;
        private Diary? _currentDiary;

        private int _nextUserId;
        private int _nextDiaryId;
        public DataController(IDatabaseAccess dbAccess)
        {
            _dbAccess = dbAccess;

            GetAvailibleUserId();
            GetAvailibleDiaryId();
        }
        public void ClearCurrentData()
        {
            _currentUser = null;
            _currentDiary = null;
        }

        public bool CreateUser(string login, string password)
        {
            Diary newDiary = new Diary(_nextDiaryId);
            User newUser = new User(_nextUserId, newDiary.Id);

            newUser.Login = login;
            newUser.Password = password;

            bool result = SaveData(newUser, newDiary);

            if (result)
            {
                _nextUserId++;
                _nextDiaryId++;
            }

            return result;
        }

        public bool GetCurrentDiary(out Diary? diary)
        {
            bool result = true;

            if (_currentDiary == null)
            {
                result = LoadDiary();
            }

            diary = _currentDiary;

            return result;
        }

        public bool GetCurrentUser(out User? user)
        {
            bool result = true;

            user = _currentUser;
            
            result = user != null;

            return result;
        }

        public bool LoadDiary()
        {
            bool result = false;

            if (_currentUser != null)
            {
                result = _dbAccess.TryLoadDiary(_currentUser.Diary_Id, out _currentDiary);
            }

            return result;
        }

        public bool LoadUser(string login)
        {
            return _dbAccess.TryLoadUser(login, out _currentUser);
        }

        public bool SaveData()
        {
            bool result = false;
            if (_currentUser != null && _currentDiary != null)
                result = SaveData(_currentUser, _currentDiary);

            return result;
        }
        bool SaveData(User user, Diary diary)
        {
            var result = _dbAccess.TrySave(user, diary);

            //TODO: надо сделать методы DELETE чтобы удалять User/Diary при неудаче создания

            return result.uSuc && result.dSuc;
        }

        public bool SaveDiaryData()
        {
            bool result = false;

            if (_currentDiary != null)
                result = _dbAccess.TrySave(_currentDiary);

            return result;
        }

        //TODO: Лучше продумать сохранение в этом контроллере
        public bool SaveUserData()
        {
            throw new NotImplementedException(); 
        }

        public bool UserExists(string login)
        {
            return _dbAccess.FindUser(login);
        }
        private void GetAvailibleUserId()
        {
            var ids = _dbAccess.GetUserIds();

            _nextUserId = ids + 1;
        }
        private void GetAvailibleDiaryId()
        {
            var ids = _dbAccess.GetDiaryIds();

            _nextDiaryId = ids + 1;
        }
    }
}
