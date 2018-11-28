﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigurationSettings.ConfigSettings
{
    public static class AppConfigSetting //: ConfigSetting
    {
        //저장위치 - C:\Users\사용자명\AppData\Local\프로젝트명\프로젝트버전\프로젝트명.config

        public static string projectName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        public static string folderPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static string tempPath = System.IO.Path.GetDirectoryName(folderPath);
        public static string configPathAndName = System.IO.Path.Combine(tempPath, projectName + ".config");

        //설정 파일 열기
        public static Configuration OpenConfiguration(string configFile)
        {
            Configuration config = null;

            if (String.IsNullOrWhiteSpace(configFile))
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            else
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = configFile;
                config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            return config;
        }
        /// <summary>
        /// 설정 추가하기
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="configFile"></param>
        public static void SetAppConfig(string key, string val, string configFile)
        {
            try
            {
                Configuration config = OpenConfiguration(configFile);

                if (config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    config.AppSettings.Settings[key].Value = val;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, val);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public static void SetAppConfig(string key, string val)
        {
            SetAppConfig(key, val, configPathAndName);
        }

        //설정 가져오기
        public static string GetAppConfig(string key, string configFile)
        {
            Configuration config = OpenConfiguration(configFile);
            string val = String.Empty;

            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                val = config.AppSettings.Settings[key].Value;
            }
            return val;
        }

        public static string GetAppConfig(string key)
        {
            return GetAppConfig(key, configPathAndName);
        }

        //설정 삭제하기
        public static void RemoveAppConfig(string key, string configFile)
        {

            Configuration config = OpenConfiguration(configFile);

            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Remove(key);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
        }
        public static void RemoveAppConfig(string key)
        {
            RemoveAppConfig(key, configPathAndName);
        }


    }
}
