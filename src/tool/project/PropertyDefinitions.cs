﻿using System;
using System.Collections.Generic;

namespace Uno.ProjectFormat
{
    public class PropertyDefinitions : Dictionary<string, Tuple<PropertyType, string>>
    {
        public static readonly PropertyDefinitions Items = new PropertyDefinitions
        {
            {"BuildCondition", PropertyType.String},
            {"BuildDirectory", PropertyType.Path, "build"},
            {"CacheDirectory", PropertyType.Path, ".uno"},
            {"OutputDirectory", PropertyType.Path, "$(BuildDirectory)/@(Target)/@(Configuration:ToLower)"},
            {"RootNamespace", PropertyType.String, "$(QIdentifier)"},
            {"Version", PropertyType.String, Environment.GetEnvironmentVariable("npm_package_version") ?? "0.1.0"},
            {"VersionCode", PropertyType.Integer, 1},
            {"Title", PropertyType.String, "$(Name)"},
            {"Icon", PropertyType.Path},
            {"URL", PropertyType.URL},
            {"Description", PropertyType.String},
            {"Copyright", PropertyType.String, "Copyright (C) " + DateTime.Now.Year + " $(Publisher)"},
            {"Publisher", PropertyType.String, "[Publisher]"},
            {"UnoCoreReference", PropertyType.Bool, true},
            {"IsTransitive", PropertyType.Bool, false},
            {"Mobile.KeepAlive", PropertyType.Bool, false},
            {"Mobile.ShowStatusbar", PropertyType.Bool, true},
            {"Mobile.RunsInBackground", PropertyType.Bool, true},
            {"Mobile.Orientations", PropertyType.String, Orientations.Auto},
            {"Android.ApplicationLabel", PropertyType.String, "$(Title)"},
            {"Android.Architectures.Debug", PropertyType.String, "armeabi-v7a"},
            {"Android.Architectures.Release", PropertyType.String, "armeabi-v7a\narm64-v8a"},
            {"Android.Defines", PropertyType.String},
            {"Android.VersionCode", PropertyType.Integer, "$(VersionCode)"},
            {"Android.VersionName", PropertyType.String, "$(Version)"},
            {"Android.Package", PropertyType.String},
            {"Android.Description", PropertyType.String, "$(Description)"},
            {"Android.Theme", PropertyType.String},
            {"Android.Icons.LDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Icons.MDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Icons.HDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Icons.XHDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Icons.XXHDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Icons.XXXHDPI", PropertyType.Path, "$(Icon)"},
            {"Android.Key.Store", PropertyType.Path},
            {"Android.Key.Alias", PropertyType.String},
            {"Android.Key.StorePassword", PropertyType.String},
            {"Android.Key.AliasPassword", PropertyType.String},
            {"Android.Geo.ApiKey", PropertyType.String},
            {"Android.NDK.PlatformVersion", PropertyType.Integer},
            {"Android.SDK.BuildToolsVersion", PropertyType.String},
            {"Android.SDK.CompileVersion", PropertyType.Integer},
            {"Android.SDK.MinVersion", PropertyType.Integer},
            {"Android.SDK.TargetVersion", PropertyType.Integer},
            {"iOS.BundleIdentifier", PropertyType.String},
            {"iOS.BundleName", PropertyType.String, "$(Title)"},
            {"iOS.BundleVersion", PropertyType.String, "$(Version)"},
            {"iOS.BundleShortVersionString", PropertyType.String, "$(Version)"},
            {"iOS.StatusBarHidden", PropertyType.Bool, "!$(Mobile.ShowStatusbar)"},
            {"iOS.StatusBarStyle", PropertyType.String, "Default"},
            {"iOS.Defines", PropertyType.String},
            {"iOS.DeploymentTarget", PropertyType.String, "9.0"},
            {"iOS.DevelopmentTeam", PropertyType.String},
            {"iOS.Icons.iPhone_20_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_20_3x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_29_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_29_3x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_40_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_40_3x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_60_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPhone_60_3x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_20_1x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_20_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_29_1x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_29_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_40_1x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_40_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_76_1x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_76_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iPad_83.5_2x", PropertyType.Path, "$(Icon)"},
            {"iOS.Icons.iOS_Marketing_1024_1x", PropertyType.Path, "$(Icon)"},
            {"iOS.LaunchScreen.ContentMode", PropertyType.String, "scaleAspectFit"},
            {"iOS.LaunchScreen.Image", PropertyType.Path, "$(iOS.Icons.iPhone_60_3x)"},
            {"iOS.LaunchScreen.Width", PropertyType.Integer, 60},
            {"iOS.LaunchScreen.Height", PropertyType.Integer, 60},
            {"iOS.LaunchScreen.BackgroundColor.Red", PropertyType.String},
            {"iOS.LaunchScreen.BackgroundColor.Green", PropertyType.String},
            {"iOS.LaunchScreen.BackgroundColor.Blue", PropertyType.String},
            {"iOS.LaunchScreen.BackgroundColor.Alpha", PropertyType.String},
            {"DotNet.Defines", PropertyType.String},
            {"Native.Defines", PropertyType.String},
            {"Mac.Icon", PropertyType.Path},
            {"Windows.Icon", PropertyType.Path},
        };

        public static readonly Dictionary<string, string> RenamedItems = new Dictionary<string, string>
        {
            {"DefaultNamespace", "RootNamespace"},
            {"BuildDir", "BuildDirectory"},
            {"CacheDir", "CacheDirectory"},
            {"VersionCount", "VersionCode"},
            {"ReferenceUnoCore", "UnoCoreReference"},
            {"iOS.Icons.iOS-Marketing_1024_1x", "iOS.Icons.iOS_Marketing_1024_1x"},
        };

        public void Add(string property, PropertyType type, object defaultValue = null)
        {
            Add(property, Tuple.Create(type, defaultValue is bool
                    ? defaultValue.ToString().ToLower() :
                defaultValue?.ToString()));
        }
    }
}
