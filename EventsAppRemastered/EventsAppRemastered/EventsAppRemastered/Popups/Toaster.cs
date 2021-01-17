using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsAppRemastered.Popups {
    public static class Toaster {

        public static void Toast(string msg) {
            CrossToastPopUp.Current.ShowToastMessage(msg);
        }
    }
}
