using pk3DS.Core.CTR;
using pk3DS.WinForms.Text;
using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace pk3DS.WinForms
{
    /// <summary>
    /// Windows-forms friendly wrapper for GARC functions
    /// </summary>
    public static class GarcUtil
    {
        private static ProgressBar Progress;
        private static Label Label;

        private static void GARC_FileCountDetermined(object sender, GARC.FileCountDeterminedEventArgs e)
        {
            Progress ??= new ProgressBar();
            if (Progress.InvokeRequired)
            {
                Progress.Invoke((MethodInvoker)delegate { Progress.Minimum = 0; Progress.Step = 1; Progress.Value = 0; Progress.Maximum = e.Total; });
            }
            else { Progress.Minimum = 0; Progress.Step = 1; Progress.Value = 0; Progress.Maximum = e.Total; }
            Label ??= new Label();
            if (Label.InvokeRequired)
                Label.Invoke((MethodInvoker)delegate { Label.Visible = true; });
        }

        private static void GARC_PackProgressed(object sender, GARC.PackProgressedEventArgs e)
        {
            if (Progress.InvokeRequired)
            {
                Progress.Invoke((MethodInvoker)(() => Progress.PerformStep()));
            }
            else { Progress.PerformStep(); }
            string update = $"{(float)e.Current / (float)e.Total:P2} - {e.Current}/{e.Total} - {e.CurrentFile}";
            if (Label.InvokeRequired)
            {
                Label.Invoke((MethodInvoker)delegate { Label.Text = update; });
            }
            else { Label.Text = update; }
        }

        private static void GARC_UnpackProgressed(object sender, GARC.UnpackProgressedEventArgs e)
        {
            #region Step
            if (Progress.InvokeRequired) Progress.Invoke((MethodInvoker)(() => Progress.PerformStep()));
            else Progress.PerformStep();

            string update = $"{((double)e.Current / e.Total):P2} - {e.Current}/{e.Total}";
            if (Label.InvokeRequired)
            {
                Label.Invoke((MethodInvoker)delegate { Label.Text = update; });
            }
            else { Label.Text = update; }
            #endregion
        }

        public static bool PackGARC(string folderPath, string garcPath, int version, int bytesPadding, ProgressBar pBar1 = null, Label label = null, bool supress = false)
        {
            Progress = pBar1;
            Label = label;
            GARC.FileCountDetermined += GARC_FileCountDetermined;
            GARC.PackProgressed += GARC_PackProgressed;
            try
            {
                var filectr = GARC.PackGARC(folderPath, garcPath, version, bytesPadding);
                if (filectr > 0)
                {
                    // We're done.
                    SystemSounds.Exclamation.Play();
                    if (!supress) WinFormsUtil.Alert(Strings.Garc_PackSuccessful, string.Format(Strings.Garc_PackSuccessfulDetail, filectr));
                }
                if (label != null)
                {
                    if (label.InvokeRequired)
                        label.Invoke((MethodInvoker)(() => label.Visible = false));
                    else
                        label.Visible = false;
                }

                return true;
            }
            catch (DirectoryNotFoundException)
            {
                if (!supress) WinFormsUtil.Error(Strings.Garc_FolderNotExist);
            }
            catch (Exception e)
            {
                WinFormsUtil.Error(Strings.Garc_PackFailed, e.ToString());
            }
            finally
            {
                GARC.FileCountDetermined -= GARC_FileCountDetermined;
                GARC.PackProgressed -= GARC_PackProgressed;
            }
            return false;
        }

        public static bool UnpackGARC(string garcPath, string outPath, bool skipDecompression, ProgressBar pBar1 = null, Label label = null, bool supress = false)
        {
            Progress = pBar1;
            Label = label;
            GARC.FileCountDetermined += GARC_FileCountDetermined;
            GARC.UnpackProgressed += GARC_UnpackProgressed;
            try
            {
                var fileCount = GARC.GarcUnpack(garcPath, outPath, skipDecompression);
                if (fileCount > 0)
                {
                    SystemSounds.Exclamation.Play();
                    if (!supress) WinFormsUtil.Alert(Strings.Garc_UnpackSuccessful, string.Format(Strings.Garc_UnpackSuccessfulDetail, fileCount));
                }

                if (label == null)
                    return true;
                if (label.InvokeRequired)
                    label.Invoke((MethodInvoker)delegate { label.Visible = false; });
                else
                    label.Visible = false;
                return true;
            }
            catch (FileNotFoundException)
            {
                WinFormsUtil.Alert(Strings.Garc_FileNotExist);
            }
            finally
            {
                GARC.FileCountDetermined -= GARC_FileCountDetermined;
                GARC.UnpackProgressed -= GARC_UnpackProgressed;
            }
            return false;
        }
    }
}
