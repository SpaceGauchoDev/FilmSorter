using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; //CultureInfo langEsp = new CultureInfo("es-ES", false);

namespace FilmSorter_LIB
{
    public class Admin
    {
        #region CLASS DECLARATIONS   
        // CLASS DECLARATIONS===========================================================================
        public static Admin inst;
        public static Admin Inst
        {
            get
            {
                if (inst == null)
                {
                    inst = new Admin();
                }
                return inst;
            }
        }
        #endregion

        #region MEMBER DECLARATIONS   
        // MEMBER DECLARATIONS===========================================================================
        private List<Film> mFilms;
        private List<FilmMaker> mFilmMakers;
        private List<Tag> mTags;
        private List<User> mUsers;
        private List<PlayList> mPlayLists; 


        #endregion

        #region ENUMS
        // ENUMS=========================================================================================

        public enum Roles {NotSet, Administrator, DataEntry, PlaylistMaker}       
        public enum Genders {NotSet, Male, Female, Other};
        public enum StorageDevices {NotSet, Laptop, DesktopPC, LiveActionEHDD, AnimatedEHDD};
        public enum Languages{  NotSet, English, French, Spanish, German, Hindi, Mandarin, Japanese,
                                Italian, Russian, Other, Arabic, Korean, Hebrew, Cantonese, Portuguese,
                                Swedish, Latin, Ukrainian, Danish, Persian};


        #endregion

        #region STRUCTS 
        // STRUCTS=======================================================================================
        
        public struct StringBool
        {
            public string Txt;
            public bool IsSuccess;

            public StringBool(string pTxt, bool pIsSuccess)
            {
                Txt = pTxt;
                IsSuccess = pIsSuccess;
            }
        }

        public struct FilmData
        {
            public string Title;
            public string AltTitle;
            public DateTime ReleaseDate;
            public int RunTimeMins;
            public bool IsLiveAction;
            public string CountryOfOrigin;
            public List<Languages> SpokenLanguages;

            public FilmData(string pTitle, string pAltTitle, DateTime pReleaseDate, int pRunTimeMins, 
                            bool pLiveAction, string pCountryOfOrigin, List<Languages> pSpokenLanguages)
            {
                Title = pTitle;
                AltTitle = pAltTitle;
                ReleaseDate = pReleaseDate;
                RunTimeMins = pRunTimeMins;
                IsLiveAction = pLiveAction;
                CountryOfOrigin = pCountryOfOrigin;
                SpokenLanguages = pSpokenLanguages;
            }
        }

        public struct FilmMakerData
        {
            public string FullName;
            public DateTime DOB;
            public DateTime DOD;
            public Genders Gender;

            public FilmMakerData(string pFullName, DateTime pDOB, DateTime pDOD, Genders pGender)
            {
                FullName = pFullName;
                DOB = pDOB;
                DOD = pDOD;
                Gender = pGender;
            }
        }

        public struct UserData
        {
            public string UserName;
            public string Password;
            public Roles Role;

            public UserData(string pUsername, string pPassword, Roles pRol)
            {
                UserName = pUsername;
                Password = pPassword;
                Role = pRol;
            }
        }

        public struct PlayListData
        {
            public List<Film> Films;
            public string Theme;
            public int AuthorUserID;

            public PlayListData(List<Film> pFilms, string pTheme, int pAuthorUserID)
            {
                Films = pFilms;
                Theme = pTheme;
                AuthorUserID = pAuthorUserID;
            }
        }

        public struct TagData
        {
            public string DisplayName;
            public string Description;
            public bool IsFilmRelevant;
            public bool IsFilmMakerRelevant;
            public object MiscData;

            public TagData( string pDisplayName, string pDescription, bool pIsFilmRelevant, 
                            bool pIsFilmMakerRelevant, object pMiscData)
            {
                DisplayName = pDisplayName;
                Description = pDescription;
                IsFilmRelevant = pIsFilmRelevant;
                IsFilmMakerRelevant = pIsFilmMakerRelevant;
                MiscData = pMiscData;
            }
        }

        public struct FileInfoData
        {
            public List<Languages> Subs;
            public int PixelHeight;
            public int PixelWidth;
            public int FileSizeMB;
            public StorageDevices StorageDevice;
            public string FilePath;

            public FileInfoData(List<Languages> pSubs, int pPixelHeight, int pPixelWidth, 
                                int pFileSizeMB, StorageDevices pStorage, string pFilePath)
            {
                Subs = pSubs;
                PixelHeight = pPixelHeight;
                PixelWidth = pPixelWidth;
                FileSizeMB = pFileSizeMB;
                StorageDevice = pStorage;
                FilePath = pFilePath;
            }
        }
        #endregion

        #region PUBLIC METHODS
        // PUBLIC METHODS ===============================================================================





        #endregion

        #region PRIVATE METHODS  
        // PRIVATE METHODS ==============================================================================


        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        private Admin()
        {
            mFilms = new List<Film>();
            mFilmMakers = new List<FilmMaker>();
            mUsers = new List<User>();
            mTags = new List<Tag>();
            mPlayLists = new List<PlayList>();
        }
        #endregion

    }
}
