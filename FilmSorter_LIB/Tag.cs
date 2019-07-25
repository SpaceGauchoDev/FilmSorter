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
        private static int mMaxChar = 20;
        private static int mMinChar = 2;
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
        public string GetDisplayName() { return mDisplayName; }

        // we validate business rules for this class of object
        public static Admin.StringBool Validate(Admin.TagData pData)
        {
            Admin.StringBool result;
            result.Txt = "Error: ";
            result.IsSuccess = true;

            // display name cant start or end with a space
            if (pData.DisplayName[0] == ' ' || pData.DisplayName[pData.DisplayName.Length - 1] == ' ')
            {
                result.Txt += "Tag Display Name can't start or end with a space. ";
                result.IsSuccess = false;
            }

            // display name cant be less than mMinChar characters long or more than mMaxChar
            if (pData.DisplayName.Length < mMinChar || pData.DisplayName.Length > mMaxChar)
            {
                result.Txt += "Tag Display Name must be between 2 and 20 characters long. ";
                result.IsSuccess = false;
            }

            return result;
        }



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
