///****************************************************************************
//// Name:        dfttsmobiletest.CSharp with DFTTS SDK v 2.0.0
//// Purpose:
//// Author:      Digital Future
//// Modified by:
//// Created:     12/27/2007
//// RCS-ID:
//// Copyright:   (C) Digital Future 2007-2008. All rights reserved.
//// Licence:     see license document
//***************************************************************************/

///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
//IMPORTANT! IMPORTANT! IMPORTANT! IMPORTANT! IMPORTANT! IMPORTANT! IMPORTANT!
//****************************************************************************
//
//1) Make sure you have the correct voice db and license file paths in Region ""Private Variables ..."
//AND the 2 files are loaded onto the device/emulator!
//2) Make sure you have dfttsmobile.dll, vt_eng.dll and swift.dll in the application directory!!!
//3) Make sure file vt_eng.dll IS the correct file for your chosen voice name and DB size!
//(vt_eng.dll is located in folder Dll\[your target platform (PocketPC or Smartphone)]\ARMV4\[voice name])
//4) If you want to use voices/languages other than Paul or Kate, you MUST install the needed voice
//onto the device/emulator, by running the EXE install file WHILE device/emulator is connected to ACTIVESYNC!
///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace UtilitiesPpc
{
    public class DFTTS
    {
        private IntPtr hWnd;

        public DFTTS(IntPtr hWnd, bool maleVoice)
        {
            this.hWnd = hWnd;
            byte[] bNeoSpeechLicFilePath;
            byte[] bNeoSpeechDBFolderPath;

            InitDFTTSEngineReturnValue result;
            short[] psiLoadedEngines = new short[1];
            short[] psiLoadedEnginesReturnValues = new short[1];

            string fullyQualifiedName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            string strProgramFilesDir = Path.GetDirectoryName(Path.GetDirectoryName(fullyQualifiedName));

            string sNeoSpeechDBFolderPath;
            if (maleVoice)
            {
                sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS_Male\\Paul32M";
            }
            else
            {
                sNeoSpeechDBFolderPath = strProgramFilesDir + "\\DFTTS\\Kate32M";
            }

            string sNeoSpeechLicFilePath = sNeoSpeechDBFolderPath + "\\verification.txt";

            //IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            bNeoSpeechLicFilePath = new byte[sNeoSpeechLicFilePath.Length + 1];
            bNeoSpeechDBFolderPath = new byte[sNeoSpeechDBFolderPath.Length + 1];

            ascii.GetBytes(sNeoSpeechDBFolderPath.ToCharArray(), 0, sNeoSpeechDBFolderPath.Length, bNeoSpeechDBFolderPath, 0);
            ascii.GetBytes(sNeoSpeechLicFilePath.ToCharArray(), 0, sNeoSpeechLicFilePath.Length, bNeoSpeechLicFilePath, 0);
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //How to change the engine and voice name:
            /*SetCurrentDFTTSVoiceEngineType((int)VoiceEngineType.CEPSTRAL);

            string sCepVoiceName = "David";
            byte[] bCepVoiceName = new byte[sCepVoiceName.Length + 1];
            ascii.GetBytes(sCepVoiceName.ToCharArray(), 0, sCepVoiceName.Length, bCepVoiceName, 0);

            //IGNORED FOR NEOSPEECH WINCE WHERE ONLY 1 VOICE CAN BE INSTALLED PER DEVICE
            SetCurrentDFTTSVoiceName(bCepVoiceName);*/

            //Deprecated as of v2.0.0

            //result = (InitDFTTSEngineReturnValue)InitDFTTSEngine(hWnd, bNeoSpeechDBFolderPath, bNeoSpeechLicFilePath);

            InitDFTTSEngineEx2(hWnd,
                bNeoSpeechDBFolderPath,
                bNeoSpeechLicFilePath,
                psiLoadedEngines,
                psiLoadedEnginesReturnValues);

            for (int intI = 0; intI <= psiLoadedEngines.Length - 1; intI++)
            {

                string sEngineName = string.Empty;

                if (psiLoadedEngines[intI] == (short)VoiceEngineType.NEOSPEECHVOICETEXT)
                {

                    sEngineName = "NEOPSEECHVOICETEXT Engine Load Result: \n";

                }
                else if (psiLoadedEngines[intI] == (short)VoiceEngineType.CEPSTRAL)
                {

                    sEngineName = "CEPSTRAL Engine Load Result: \n";

                }

                result = (InitDFTTSEngineReturnValue)psiLoadedEnginesReturnValues[intI];

                switch (result)
                {

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_CHANNEL_MEM_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to secure channel memory.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_ACOU_MODEL_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for the Acoustic Model.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_BREAK_INDEX_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for the Break Index.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_MORPHEME_ANALYSIS_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for the Morpheme Analysis.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_PATH_DIFFERENT:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Tried to load the synthesizer database with different values of db_path in " + "case of using multiple synthesizer databases.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_PITCH_LOC_INFO_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for Pitch Location Information.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_PROS_MODEL_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for Prosody Model.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_SPEECH_DB_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for Speech Database.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_TEXT_PREP_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for the Text Pre-Processing.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_DB_UNIT_SEL_FAIL:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Failed to load DB for Unit Selection.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_ERROR_OTHER:


                        MessageBox.Show(sEngineName + "InitDFTTSEngine Error: Unspecified error.");
                        break;

                    case InitDFTTSEngineReturnValue.INIT_DFTTS_ENGINE_SUCCESS:


                        //MessageBox.Show(sEngineName + "Success!");
                        break;

                }

            }

        }

        ~DFTTS()
        {
            UninitDFTTSEngine();
        }

        #region "P/Invoke declarations"

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern void SetCurrentDFTTSVoiceEngineType(int vetVoiceEngineType);


        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentDFTTSVoiceEngineType();

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern void SetCurrentDFTTSVoiceName(byte[] szVoiceName);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int InitDFTTSEngine(IntPtr hwndWinOwner, byte[] szNeoSpeechDBFolderPath, byte[] szNeoSpeechLicFilePath);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern void InitDFTTSEngineEx2(IntPtr hwndWinOwner, byte[] szNeoSpeechDBFolderPath, byte[] szNeoSpeechLicFilePath, short[] psiLoadedEngines, short[] psiLoadedEnginesReturnValues);


        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int UninitDFTTSEngine();

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int LoadDFTTSUserDict(int iDictIndex, byte[] szDictFileName);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int UnloadDFTTSUserDict(int iDictIndex);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSSpeak(IntPtr hwndWinOwner, byte[] szText, int iPitch, int iSpeed, int iVolume, int iPause, int iDictID, int ttTextType);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSPause();

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSResume();

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSStop();

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSExportToFile(byte[] szText, int iPitch, int iSpeed, int iVolume, int iPause, int iDictID, int ttTextType, byte[] szFilePath, ref IntPtr FileFormat);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int DFTTSExportToFileEx(byte[] szText, int iPitch, int iSpeed, int iVolume, int iPause, int iDictID, int ttTextType, byte[] szFilePath, int ffFileFormat, byte[] szAudioEncoding,
        int iAudioSamplingRate, int iAudioChannels);

        [DllImport("dfttsmobile.dll", CharSet = CharSet.Auto)]
        public static extern int GetDFTTSEngineInfo(int vetVType, int ttspParam, int[] iValue, byte[] szNeoSpeechLicFilePath);


        #endregion



        #region "API Enums"

        public enum VoiceEngineType
        {

            NEOSPEECHVOICETEXT,
            CEPSTRAL

        }

        public enum InitDFTTSEngineReturnValue
        {

            INIT_DFTTS_ENGINE_SUCCESS,
            INIT_DFTTS_ENGINE_ERROR_DB_PATH_DIFFERENT,
            INIT_DFTTS_ENGINE_ERROR_CHANNEL_MEM_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_MORPHEME_ANALYSIS_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_BREAK_INDEX_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_TEXT_PREP_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_ACOU_MODEL_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_UNIT_SEL_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_PROS_MODEL_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_SPEECH_DB_FAIL,
            INIT_DFTTS_ENGINE_ERROR_DB_PITCH_LOC_INFO_FAIL,
            INIT_DFTTS_ENGINE_ERROR_OTHER

        }

        public enum UninitDFTTSEngineReturnValue
        {

            UNINIT_DFTTS_ENGINE_SUCCESS

        }


        public enum LoadUserDictReturnValue
        {

            LOAD_USER_DICT_SUCCESS,
            LOAD_USER_DICT_ERROR_DICTIDX_NOT_VALID,
            LOAD_USER_DICT_ERROR_DICT_ALREADY_LOADED,
            LOAD_USER_DICT_ERROR_NO_DICT_FILE_OR_ENTRY,
            LOAD_USER_DICT_ERROR_OTHER

        }

        public enum UnloadUserDictReturnValue
        {

            UNLOAD_USER_DICT_SUCCESS,
            UNLOAD_USER_DICT_ERROR_DICTIDX_NOT_VALID,
            UNLOAD_USER_DICT_ERROR_DICT_UNLOADED,
            UNLOAD_USER_DICT_ERROR_OTHER

        }

        public enum DFTTSTextType
        {

            DFTTS_TEXT_TYPE_PLAIN,
            DFTTS_TEXT_TYPE_XML

        }

        public enum DFTTSSpeakReturnValue
        {

            DFTTS_SPEAK_SUCCESS,
            DFTTS_SPEAK_ERROR_CHANNEL_MEM_FAIL,
            DFTTS_SPEAK_ERROR_TEXT_NULL,
            DFTTS_SPEAK_ERROR_TEXT_ZERO_LEN,
            DFTTS_SPEAK_ERROR_DB_NOT_LOADED,
            DFTTS_SPEAK_ERROR_SET_SOUND_CARD_FAIL,
            DFTTS_SPEAK_ERROR_OTHER

        }

        public enum DFTTSPauseReturnValue
        {

            DFTTS_PAUSE_SUCCESS

        }

        public enum DFTTSResumeReturnValue
        {

            DFTTS_RESUME_SUCCESS

        }


        public enum DFTTSStopReturnValue
        {

            DFTTS_STOP_SUCCESS

        }

        public enum DFTTSExportReturnValue
        {

            DFTTS_EXPORT_SUCCESS,
            DFTTS_EXPORT_ERROR_FORMAT_NOT_SUPPORTED,
            DFTTS_EXPORT_ERROR_CHANNEL_MEM_FAIL,
            DFTTS_EXPORT_ERROR_TEXT_NULL,
            DFTTS_EXPORT_ERROR_TEXT_ZERO_LEN,
            DFTTS_EXPORT_ERROR_DB_NOT_LOADED,
            DFTTS_EXPORT_ERROR_GEN_FILE_FAIL,
            DFTTS_EXPORT_ERROR_BUFFER_NULL,
            DFTTS_EXPORT_ERROR_THREAD_IN_USE,
            DFTTS_EXPORT_ERROR_OTHER

        }

        public enum DFTTSParamInfoReturnValue
        {

            DFTTS_PARAM_INFO_SUCCESS,
            DFTTS_PARAM_INFO_ERROR_ENGINE_NOT_SUPPORTED,
            DFTTS_PARAM_INFO_ERROR_PARAM_NOT_SUPPORTED,
            DFTTS_PARAM_INFO_ERROR_INVALID_REQUEST,
            DFTTS_PARAM_INFO_ERROR_NULL_VALUE,
            DFTTS_PARAM_INFO_ERROR_SHORT_LENGTH_VALUE,
            DFTTS_PARAM_INFO_ERROR_UNKNOWN

        }

        public enum DFTTSParamType
        {

            DFTTS_BUILD_DATE,
            DFTTS_VERIFY_CODE,
            DFTTS_MAX_CHANNEL,
            DFTTS_DB_DIRECTORY,
            DFTTS_LOAD_SUCCESS_CODE,
            DFTTS_MAX_SPEAKER,
            DFTTS_DEF_SPEAKER,
            DFTTS_CODEPAGE,
            DFTTS_DB_ACCESS_MODE,
            DFTTS_FIXED_POINT_SUPPORT,
            DFTTS_SAMPLING_FREQUENCY,
            DFTTS_MAX_PITCH_RATE,
            DFTTS_DEF_PITCH_RATE,
            DFTTS_MIN_PITCH_RATE,
            DFTTS_MAX_SPEED_RATE,
            DFTTS_DEF_SPEED_RATE,
            DFTTS_MIN_SPEED_RATE,
            DFTTS_MAX_VOLUME,
            DFTTS_DEF_VOLUME,
            DFTTS_MIN_VOLUME,
            DFTTS_MAX_SENT_PAUSE,
            DFTTS_DEF_SENT_PAUSE,
            DFTTS_MIN_SENT_PAUSE

        }

        //NeoSpeech VoiceText (TM) Audio Format
        public enum NeoSpeechVoiceTextAudioFormat
        {

            VT_FILE_API_FMT_S16PCM = 0,
            VT_FILE_API_FMT_ALAW = 1,
            VT_FILE_API_FMT_MULAW = 2,
            VT_FILE_API_FMT_DADPCM = 3,
            VT_FILE_API_FMT_S16PCM_WAVE = 4,
            VT_FILE_API_FMT_U08PCM_WAVE = 5,
            VT_FILE_API_FMT_IMA_WAVE = 6,
            VT_FILE_API_FMT_ALAW_WAVE = 7,
            VT_FILE_API_FMT_MULAW_WAVE = 8,
            VT_FILE_API_FMT_MULAW_AU = 9

        }


        #endregion

        #region "Private Variables (!YOU NEED TO CHANGE THE PATHS TO MATCH YOUR PATHS!)"

        private System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();

        #endregion


        public void SayIt(string text)
        {
            DFTTSSpeakReturnValue result;

            byte[] bText;
            bText = new byte[text.Length + 1];
            ascii.GetBytes(text.ToCharArray(), 0, text.Length, bText, 0);

            result = (DFTTSSpeakReturnValue)DFTTSSpeak(hWnd, bText, -1, -1, -1, -1, -1, (int)DFTTSTextType.DFTTS_TEXT_TYPE_PLAIN);

            switch (result)
            {

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_CHANNEL_MEM_FAIL:


                    MessageBox.Show("DFTTSSpeak Error: Failed to secure channel memory.");
                    break;

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_DB_NOT_LOADED:


                    MessageBox.Show("DFTTSSpeak Error: Voice DB not loaded.");
                    break;

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_OTHER:


                    MessageBox.Show("DFTTSSpeak Error: Unspecified error.");
                    break;

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_SET_SOUND_CARD_FAIL:


                    MessageBox.Show("DFTTSSpeak Error: Failed to set sound card.");
                    break;

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_TEXT_NULL:


                    MessageBox.Show("DFTTSSpeak Error: The provided text is NULL.");
                    break;

                case DFTTSSpeakReturnValue.DFTTS_SPEAK_ERROR_TEXT_ZERO_LEN:


                    MessageBox.Show("DFTTSSpeak Error: The provided text is of zero length.");
                    break;

            }
        }
    }
}
