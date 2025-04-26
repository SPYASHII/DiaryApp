using MainComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDatabase.Interfaces
{
    public interface IDataConverter<UType, DType>
    {
        User Convert(UType user);
        UType Convert(User user);
        Diary Convert(DType diary);
        DType Convert(Diary diary);
    }
}
