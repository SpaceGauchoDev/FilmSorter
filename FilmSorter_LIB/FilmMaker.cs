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
        public string GetFullName() { return mFullName; }

        // we validate business rules for this class of object
        public static Admin.StringBool Validate(Admin.FilmMakerData pData)
        {
            Admin.StringBool result;
            result.Txt = "Error: ";
            result.IsSuccess = true;

            // FilmMaker can't die before they are born
            DateTime unset = new DateTime();
            if (pData.DOD <= pData.DOB && pData.DOD != unset)
            {
                result.Txt += "Film Maker DOD (Date Of Death) can't be earlier than DOB (Date of Birth). ";
                result.IsSuccess = false;
            }

            // FullName name cant start or end with a space
            if (pData.FullName[0] == ' ' || pData.FullName[pData.FullName.Length - 1] == ' ')
            {
                result.Txt += "Film Maker Full Name can't start or end with a space. ";
                result.IsSuccess = false;
            }

            return result;
        }

        // we add incoming tags to this object's mTags if it didnt have them already
        public void AddTags(List<Tag> pTags)
        {
            for (int i = 0; i < pTags.Count; i++)
            {
                if (HasTag(pTags[i]) == null)
                {
                    mTags.Add(pTags[i]);
                }
            }
        }

        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================
        
        // we look for the supplied tag in this object's mTags list
        private Tag HasTag(Tag pTag)
        {
            Tag t = null;
            if (mTags.Count > 0)
            {
                int i = 0;
                while (i < mTags.Count && t == null)
                {
                    if (mTags[i].GetID() == pTag.GetID())
                    {
                        t = mTags[i];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return t;
        }

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
