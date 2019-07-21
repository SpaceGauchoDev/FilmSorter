using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class FilmMaker
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1; 
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mFilmMakerID; 
        private string mFullName;
        private DateTime mDOB;
        private DateTime mDOD;
        private Admin.Genders mGender;
        private List<Tag> mTags;

        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetID() { return mFilmMakerID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        public FilmMaker()
        {
            mFilmMakerID = mLastID + 1;
            mLastID = mFilmMakerID;

            mFullName = "";
            mDOB = new DateTime();
            mDOD = new DateTime();
            mGender = Admin.Genders.NotSet;

            mTags = new List<Tag>();
        }

        public FilmMaker(Admin.FilmMakerData pData)
        {
            mFilmMakerID = mLastID + 1;
            mLastID = mFilmMakerID;

            mFullName = pData.FullName;
            mDOB = pData.DOB;
            mDOD = pData.DOD;
            mGender = pData.Gender;

            mTags = new List<Tag>();
        }
        #endregion
    }
}
