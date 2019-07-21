using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class User
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1;
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mUserID;
        private string mUserPassword;
        private string mUserName;
        private Admin.Roles mRole;
        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetID() { return mUserID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================
        public User(Admin.UserData pData)
        {
            mUserID = mLastID + 1;
            mLastID = mUserID;

            mUserName = pData.UserName;
            mUserPassword = pData.Password;
            mRole = pData.Role;
        }

        #endregion
    }
}
