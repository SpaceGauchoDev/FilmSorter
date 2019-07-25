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

        public enum ObjectTypes {FilmMaker, Tag, Film, PlayList, User, FileInfo};
        public enum Roles {NotSet, Administrator, DataEntry, PlaylistMaker};       
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
        private void Init()
        {
            mFilms = new List<Film>();
            mFilmMakers = new List<FilmMaker>();
            mUsers = new List<User>();
            mTags = new List<Tag>();
            mPlayLists = new List<PlayList>();
        }
        // attempt to create and add a new Tag object in the system
        private StringBool InstanciateTag(TagData pData)
        {
            StringBool result;
            result.Txt = "";
            result.IsSuccess = true;

            // check for empty data fields
            if(pData.DisplayName == "" || pData.Description == "")
            {
                result.IsSuccess = false;
                result.Txt = "Error: One or more data fields are empty.";
                return result;
            }

            // check for same object already in system
            if (GetTag(pData.DisplayName) != null)
            {
                result.IsSuccess = false;
                result.Txt = "Error: Tag with the same Display Name already exists in the system.";
                return result;
            }

            // validate business rules
            StringBool validation = Tag.Validate(pData);
            if (validation.IsSuccess)
            {
                // if we reach here, all validations have been satisfied 
                // and we can instanciate the new object
                Tag t = new Tag(pData);
                result.Txt = "New Tag created sucesfully";
            }
            else
            {
                // busniess rules not met
                result.IsSuccess = false;
                result.Txt = validation.Txt;
            }

            return result;
        }

        //search Tag ID
        private Tag GetTag(int pTagID)
        {
            Tag t = null;
            //if the array is initialized and populated
            if (mTags.Count > 0)
            {
                int i = 0;
                while (t == null && i < mTags.Count)
                {
                    if (mTags[i].GetID() == pTagID)
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

        //search Tag by DisplayName
        private Tag GetTag(string pDisplayName)
        {
            Tag t = null;
            //if the array is initialized and populated
            if (mTags.Count > 0)
            {
                int i = 0;
                while (t == null && i < mTags.Count)
                {
                    if (mTags[i].GetDisplayName() == pDisplayName)
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

        // add tags to object types that support it
        private void AddTags(int pId, List<Tag> pTags, ObjectTypes pObjectType)
        {
            switch (pObjectType)
            {
                case ObjectTypes.FilmMaker:
                    GetFilmMaker(pId).AddTags(pTags);
                    break;
                case ObjectTypes.Film:
                    break;
                case ObjectTypes.PlayList:
                    break;
                default:
                    break;
            }
        }

        // attempt to create and add a new FilmMaker object in the system
        private StringBool InstanciateFilmMaker(FilmMakerData pData)
        {
            StringBool result;
            result.Txt = "";
            result.IsSuccess = true;

            // check for empty data fields
            // DOB is mandatory for new FilmMaker but DOD can be unset
            // unset DOD will be interpreted as the FilmMaker still being alive
            DateTime unset = new DateTime();
            if (pData.FullName == "" || pData.Gender == Genders.NotSet || pData.DOB == unset)
            {
                result.IsSuccess = false;
                result.Txt = "Error: One or more data fields are empty.";
                return result;
            }

            // check for same object already in system
            if (GetFilmMaker(pData.FullName) != null)
            {
                result.IsSuccess = false;
                result.Txt = "Error: Film Maker with the same Full Name already exists in the system.";
                return result;
            }

            // validate business rules
            StringBool validation = FilmMaker.Validate(pData);
            if (validation.IsSuccess)
            {
                // if we reach here, all validations have been satisfied 
                // and we can instanciate the new object
                FilmMaker t = new FilmMaker(pData);
                result.Txt = "New Film Maker created sucesfully";
            }
            else
            {
                // busniess rules not met
                result.IsSuccess = false;
                result.Txt = validation.Txt;
            }

            return result;
        }


        //search FilmMaker by ID
        private FilmMaker GetFilmMaker(int pFilmMakerID)
        {
            FilmMaker f = null;
            //if the array is initialized and populated
            if (mFilmMakers.Count > 0)
            {
                int i = 0;
                while (f == null && i < mFilmMakers.Count)
                {
                    if (mFilmMakers[i].GetID() == pFilmMakerID)
                    {
                        f = mFilmMakers[i];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return f;
        }

        //search FilmMaker by FullName
        private FilmMaker GetFilmMaker(string pFullName)
        {
            FilmMaker f = null;
            //if the array is initialized and populated
            if (mFilmMakers.Count > 0)
            {
                int i = 0;
                while (f == null && i < mFilmMakers.Count)
                {
                    if (mFilmMakers[i].GetFullName() == pFullName)
                    {
                        f = mFilmMakers[i];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return f;
        }




        #endregion

        #region CONSTRUCTORS
        // CONSTRUCTORS ==============================================================================

        private Admin()
        {
            Init();
        }
        #endregion

    }
}
