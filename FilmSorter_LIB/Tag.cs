using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class Tag
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1;
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mTagID;
        private string mDisplayName;
        private string mDescription;
        private bool mIsFilmRelevant;
        private bool mIsFilmMakerRelevant;
        private object mMiscData;

        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetID() { return mTagID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        public Tag()
        {
            mTagID = mLastID + 1;
            mLastID = mTagID;

            mDisplayName = "";
            mDescription = "";
            mIsFilmRelevant = false;
            mIsFilmMakerRelevant = false;
            mMiscData = new object();
        }

        public Tag(Admin.TagData pData)
        {
            mTagID = mLastID + 1;
            mLastID = mTagID;

            mDisplayName = pData.DisplayName;
            mDescription = pData.Description;
            mIsFilmRelevant = pData.IsFilmRelevant;
            mIsFilmMakerRelevant = pData.IsFilmMakerRelevant;
            mMiscData = pData.MiscData;
        }

        #endregion
    }
}
