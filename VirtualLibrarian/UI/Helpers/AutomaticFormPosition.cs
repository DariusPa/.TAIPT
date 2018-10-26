using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrarian.Helpers
{
    public static class AutomaticFormPosition
    {
        public delegate Form LoadingFormDelegate(Form form);

        //delegates for separate loading methods
        public static LoadingFormDelegate loadAutoPositionDelegate = LoadAutoPosition;
        public static LoadingFormDelegate loadAutoFormStateDelegate = LoadAutoFormState;
        public static LoadingFormDelegate loadAutoFormSizeDelegate = LoadAutoFormSize;

        public static LoadingFormDelegate loadStartingPositionDelegate = LoadStartingPosition;
        public static LoadingFormDelegate loadStartingSizeDelegate = LoadStartingFormSize;
        public static LoadingFormDelegate loadStartingStateDelegate = LoadStartingFormState;

        public static LoadingFormDelegate loadUISizeDelegate = LoadUISize;


        //all loading method delegate
        public static LoadingFormDelegate loadingFormDelegate = loadAutoPositionDelegate
                                                                + loadAutoFormStateDelegate
                                                                + LoadAutoFormSize;

        //load starting application form state delegate
        public static LoadingFormDelegate loadStartingFormDelegate = loadStartingPositionDelegate
                                                                    + loadStartingStateDelegate
                                                                    + loadStartingSizeDelegate;

        //load UI form status delegate
        public static LoadingFormDelegate loadUIFormDelegate = loadAutoPositionDelegate
                                                                + loadAutoFormStateDelegate
                                                                + loadUISizeDelegate;

        //is run, when app is starting
        public static Form LoadStartingFormSize(Form form)
        {
            form.Size = Properties.Settings.Default.StartingWindowSize;
            return form;
        }

        public static Form LoadStartingFormState(Form form)
        {
            form.WindowState = Properties.Settings.Default.StartingWindowState;
            return form;
        }

        public static Form LoadStartingPosition(Form form)
        {
            form.Location = Properties.Settings.Default.StartingWindowLocation;
            return form;
        }

        //methods, keeping track of form position, state, size while the application is running
        public static Form LoadAutoPosition(Form form)
        {
            form.Location = Properties.Settings.Default.WindowLocation;
            return form;
        }

        public static Form LoadAutoFormState(Form form)
        {
            form.WindowState = Properties.Settings.Default.WindowState;
            return form;
        }

        public static Form LoadAutoFormSize(Form form)
        {
            form.Size = Properties.Settings.Default.WindowSize;
            return form;
        }

        public static void SaveFormStatus(Form form)
        {
            Properties.Settings.Default.WindowState = form. WindowState;
            Properties.Settings.Default.WindowLocation = form.Location;
            if (form.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowLocation = form.Location;
                Properties.Settings.Default.WindowSize = form.Size;
            }
            else
            {
                Properties.Settings.Default.WindowLocation = form.RestoreBounds.Location;
                Properties.Settings.Default.WindowSize = form.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
        }

        public static Form LoadUISize(Form form)
        {
            form.Size = Properties.Settings.Default.UIWindowSize;
            return form;
        }
    }
}
