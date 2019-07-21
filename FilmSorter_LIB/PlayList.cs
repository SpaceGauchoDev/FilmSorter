using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class PlayList
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1;
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mPlayListID;
        private int mTotalRunTimeMins;
        private string mTheme;
        private int mAuthorUserID;
        private List<Film> mFilms;

        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetID() { return mPlayListID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        public PlayList(Admin.PlayListData pData)
        {
            mPlayListID = mLastID + 1;
            mLastID = mPlayListID;

            mTheme = pData.Theme;
            mAuthorUserID = pData.AuthorUserID;
            mFilms = pData.Films;

            // calculate mTotalRunTimeMins here
            mTotalRunTimeMins = 0;
        }

        #endregion
    }
}
