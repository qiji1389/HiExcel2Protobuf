﻿using System;

namespace Excel2Protobuf.Lib
{
    public static class Settings
    {
        /// <summary>
        /// Protobuf 导出文件夹
        /// </summary>
        public static string ProtobufOutput_Folder = string.Empty;

        /// <summary>
        /// Excel文件夹
        /// </summary>
        public static string SourceExcel_Folder = string.Empty;

        /// <summary>
        /// 编译器路径
        /// </summary>
        public static string Compiler_Path = string.Empty;

        /// <summary>
        /// protobuf dll
        /// </summary>
        public static readonly string Protobuf_Dll_Path = Environment.CurrentDirectory + @"\Google.Protobuf.dll";

        /// <summary>
        /// protoc路径
        /// </summary>
        public static readonly string Protoc_Path = Environment.CurrentDirectory + @"\protoc-3.8.0-win64\bin\protoc.exe";

        /// <summary>
        /// Proto文件存放目录
        /// </summary>
        internal static readonly string proto_folder = "\\proto";

        /// <summary>
        /// 语言存放目录
        /// </summary>
        internal static readonly string code_folder = "\\code";

        /// <summary>
        /// 数据存放目录
        /// </summary>
        internal static readonly string dat_folder = "\\data";

        //导出语言文件夹
        internal static readonly string csharp_folder = "\\csharp";
        internal static readonly string csharp_dll_folder = "\\csharp_dll";
        internal static readonly string cpp_folder = "\\cpp";
        internal static readonly string go_folder = "\\go";
        internal static readonly string java_folder = "\\java";
        internal static readonly string python_folder = "\\python";
    }
}