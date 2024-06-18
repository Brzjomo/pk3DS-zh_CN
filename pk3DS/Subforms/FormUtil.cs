using System.Collections;
using System.Windows.Forms;

namespace pk3DS.WinForms
{
    public static class FormUtil
    {
        // Utility (Shared)
        internal static void SetForms(int species, ComboBox cb, string[][] AltForms)
        {
            cb.Items.Clear();
            string[] forms = AltForms[species];
            if (forms.Length < 2)
            {
                cb.Items.Add("");
                cb.Enabled = false;
            }
            else
            {
                foreach (string s in forms)
                    cb.Items.Add(s);
                cb.Enabled = true;
            }
            cb.SelectedIndex = 0;
        }

        // test
        internal static void SetForms(ComboBox cb, string[] specieslist, bool ifRemoveFirst)
        {
            cb.Items.Clear();
            if (ifRemoveFirst)
            {
                ArrayList list = new ArrayList();
                foreach (string s in specieslist)
                {
                    if (s != "")
                    {
                        list.Add(s);
                    }
                }
                foreach (string s in list)
                    cb.Items.Add(s);
            } else
            {
                foreach (string s in specieslist)
                    cb.Items.Add(s);
            }
            
            cb.Enabled = true;
            cb.SelectedIndex = 0;
        }
    }
}
