using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.DataAccess.Helper.Interfaces
{
    public interface IDatabaseHelper
    {
        void OpenConnection();

        void CloseConnection();

        DataTable ExecuteSProcedure(string nameProc, params object[] paramObjects);
    }
}
