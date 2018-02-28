using System;
using System.Linq;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace MAST_UI_Portable
{
    public class SmokeHelper : ScreenBase
    {
        public SmokeHelper(Platform platform, AppManager manager) : base(platform, manager)
        {

        }
        public void CheckAllElemOnAuthScreen()
        {
            if (OnAndroid)
            {
                for (int col = 0; col < AuthDictionary.QueriesAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(AuthDictionary.QueriesAndroid.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < AuthDictionary.QueriesIos.Count; col++)
                {

                    appManager.App.WaitForElement(AuthDictionary.QueriesIos.ElementAt(col).Value);
                }
            }


        }

        public void CheсkAllelemOnNameReg()
        {
            if (OnAndroid)
            {
                for (int col = 0; col < RegistrDictionary.QueriesNameAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesNameAndroid.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < RegistrDictionary.QueriesNameIos.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesNameIos.ElementAt(col).Value);
                }
            }

            
        }

        public void CheсkAllelemOnPhoneReg()
        {
            //appManager.RegistrHelper.GoToEneterNameLastNameScreen();
            if (OnAndroid)
            {
                for (int col = 0; col < RegistrDictionary.QueriesPhoneAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesPhoneAndroid.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < RegistrDictionary.QueriesPhoneIos.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesPhoneIos.ElementAt(col).Value);
                }
            }
            
        }

        public void CheсkAllelemOnEmailReg()
        {
            //appManager.RegistrHelper.GoToEneterNameLastNameScreen();
            if (OnAndroid)
            {
                for (int col = 0; col < RegistrDictionary.QueriesEmailAndriod.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesEmailAndriod.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < RegistrDictionary.QueriesEmailIos.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesEmailIos.ElementAt(col).Value);
                }
            }
            
        }

        public void CheсkAllelemOnPassReg()
        {
            //appManager.RegistrHelper.GoToEneterPass();
            if (OnAndroid)
            {
                for (int col = 0; col < RegistrDictionary.QueriesPassAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesPassAndroid.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < RegistrDictionary.QueriesPassIos.Count; col++)
                {

                    appManager.App.WaitForElement(RegistrDictionary.QueriesPassIos.ElementAt(col).Value);
                }
            }
            
        }

        public void CheсkAllelemOnCreatPost()
        {
            //appManager.RegistrHelper.GoToEneterPass();
            if (OnAndroid)
            {
                for (int col = 0; col < CreatePostDictionary.QueriesAndroid.Count; col++)
                {

                    appManager.App.WaitForElement(CreatePostDictionary.QueriesAndroid.ElementAt(col).Value);
                }
            }
            if (OniOS)
            {
                for (int col = 0; col < CreatePostDictionary.QueriesIos.Count; col++)
                {

                    appManager.App.WaitForElement(CreatePostDictionary.QueriesIos.ElementAt(col).Value);
                }
            }

        }


    }
}
    
