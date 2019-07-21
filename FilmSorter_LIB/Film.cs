using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class Film
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1;
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mFilmID;
        private string mTitle;
        private string mAltTitle;
        private DateTime mReleaseDate;
        private int mRunTimeMins;
        private bool mLiveAction;
        private string mCountryOfOrigin;
        private List<Admin.Languages> mSpokenLanguages;
        private List<FilmMaker> mDirectedBy;
        private List<FilmMaker> mWrittenBy;
        private List<FilmMaker> mStarredBy;
        private List<Tag> mTags;

        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetId() { return mFilmID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        public Film()
        {
            mFilmID = mLastID + 1;
            mLastID = mFilmID;

            mTitle = "";
            mAltTitle = "";
            mReleaseDate = new DateTime();
            mRunTimeMins = 0;
            mLiveAction = true;
            mSpokenLanguages = new List<Admin.Languages>();
            mCountryOfOrigin = "";

            mDirectedBy = new List<FilmMaker>();
            mWrittenBy = new List<FilmMaker>();
            mStarredBy = new List<FilmMaker>();
            mTags = new List<Tag>();
        }

        public Film(Admin.FilmData pData)
        {
            mFilmID = mLastID + 1;
            mLastID = mFilmID;

            mTitle = pData.Title;
            mAltTitle = pData.AltTitle;
            mReleaseDate = pData.ReleaseDate;
            mRunTimeMins = pData.RunTimeMins;
            mLiveAction = pData.IsLiveAction;
            mCountryOfOrigin = pData.CountryOfOrigin;
            mSpokenLanguages = pData.SpokenLanguages;

            mDirectedBy = new List<FilmMaker>();
            mWrittenBy = new List<FilmMaker>();
            mStarredBy = new List<FilmMaker>();
            mTags = new List<Tag>();
        }

        #endregion
    }
}
