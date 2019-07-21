using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSorter_LIB
{
    public class FileInfo
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        private static int mLastID = -1;
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================

        private int mFileInfoID;
        private int mPixelHeight;
        private int mPixelWidth;
        private int mFileSizeMB;
        private Admin.StorageDevices mStorageDevice;
        private string mFilePath;
        #endregion

        #region PUBLIC METHODS

        // PUBLIC METHODS ===============================================================================
        public int GetID() { return mFileInfoID; }


        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        public FileInfo()
        {
            mFileInfoID = mLastID + 1;
            mLastID = mFileInfoID;

            mPixelHeight = 0;
            mPixelWidth = 0;
            mFileSizeMB = 0;
            mFilePath = "";
            mStorageDevice = Admin.StorageDevices.NotSet;
        }

        public FileInfo(Admin.FileInfoData pData)
        {
            mFileInfoID = mLastID + 1;
            mLastID = mFileInfoID;

            mPixelHeight = pData.PixelHeight;
            mPixelWidth = pData.PixelWidth;
            mFileSizeMB = pData.FileSizeMB;
            mFilePath = pData.FilePath;
            mStorageDevice = pData.StorageDevice;
        }

        #endregion
    }
}
